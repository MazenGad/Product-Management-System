$("#productForm").submit(function (e) {
    e.preventDefault();

    var form = $("#productForm");

    if (!form.valid()) {
        return;
    }

    var formData = {
        name: $("input[name='Name']").val(),
        unit: $("input[name='Unit']").val(),
        price: parseFloat($("input[name='Price']").val()),
        initialQuantity: parseInt($("input[name='InitialQuantity']").val()),
        generatedCode: $("input[name='generatedCode']").val()
    };

    $.ajax({
        type: "POST",
        url: "/Product/Create",
        contentType: "application/json",
        data: JSON.stringify(formData),
        success: function (response) {
            if (response.success) {
                $("#message").html(`<div class="alert alert-success">${response.message}</div>`);
                form[0].reset();
                form.find(".text-danger").empty();
                $.get("/Product/GenerateCode", function (newCode) {
                    $("#GeneratedCode").val(newCode);
                });
            } else {
                $("#message").html(`<div class="alert alert-danger">${response.message}</div>`);
            }
        },
        error: function () {
            $("#message").html(`<div class="alert alert-danger">Unexpected error occurred.</div>`);
        }
    });
});
