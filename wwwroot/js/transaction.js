let selectedPrice = 0;
let selectedUnit = "";
let availableQuantity = 0;

$("#productId").change(function () {
    const productId = $(this).val();
    if (!productId) return;

    $.get(`/Product/GetProduct?id=${productId}`, function (data) {
        selectedPrice = parseFloat(data.price);
        selectedUnit = data.unit;
        availableQuantity = parseInt(data.initialQuantity);

        $("#unit").val(selectedUnit);
        calculateTotal();
        validateQuantity();
    });
});

$("#quantity").on("input", function () {
    calculateTotal();
    validateQuantity();
});

function calculateTotal() {
    const quantity = parseFloat($("#quantity").val() || 0);
    const total = (quantity * selectedPrice).toFixed(2);
    $("#totalPrice").val(total);
}

function validateQuantity() {
    const quantityInput = $("#quantity");
    const quantity = parseInt(quantityInput.val() || 0);

    quantityInput.removeClass("is-invalid");
    $("#quantityFeedback").remove();

    if (quantity < 0) {
        quantityInput.addClass("is-invalid");
        quantityInput.after(`<div id="quantityFeedback" class="invalid-feedback">
            <i class="fas fa-exclamation-triangle"></i> Quantity cannot be negative.
        </div>`);
        return;
    }

    if (quantity > availableQuantity) {
        quantityInput.addClass("is-invalid");
        quantityInput.after(`<div id="quantityFeedback" class="invalid-feedback">
            <i class="fas fa-exclamation-triangle"></i> Quantity exceeds available stock (${availableQuantity} units available).
        </div>`);
    }
}

function updateProductDropdown() {
    $.get("/Transaction/GetAllProducts", function (products) {
        const $dropdown = $("#productId");
        $dropdown.empty();
        $dropdown.append(`<option value="">-- Select Product --</option>`);

        products.forEach(product => {
            const outOfStockText = product.initialQuantity === 0 ? " (Out of Stock)" : "";
            $dropdown.append(`
                <option value="${product.id}"
                        price="${product.price}"
                        unit="${product.unit}"
                        available="${product.initialQuantity}">
                    ${product.name}${outOfStockText}
                </option>
            `);
        });
    });
}



$("#transactionForm").submit(function (e) {
    e.preventDefault();

    const rawDate = $("#transactionDate").val();
    const today = new Date().toISOString().split("T")[0];

    if (rawDate > today) {
        $("#message").html(`<div class="alert alert-warning">Transaction date cannot be in the future.</div>`);
        return;
    }

    const formattedDate = rawDate ? new Date(rawDate).toISOString() : null;

    const formData = {
        productId: parseInt($("#productId").val()),
        quantity: parseInt($("#quantity").val()),
        date: formattedDate
    };

    $.ajax({
        type: "POST",
        url: "/Transaction/Create",
        contentType: "application/json",
        data: JSON.stringify(formData),
        success: function (response) {
            if (response.success) {
                $("#message").html(`<div class="alert alert-success">${response.message}</div>`);
                $("#transactionForm")[0].reset();
                $("#totalPrice").val("");
                $("#unit").val("");
                updateProductDropdown();
            } else {
                $("#message").html(`<div class="alert alert-danger">${response.message}</div>`);
            }
        },
        error: function () {
            $("#message").html(`<div class="alert alert-danger">Unexpected error occurred.</div>`);
        }
    });
});
