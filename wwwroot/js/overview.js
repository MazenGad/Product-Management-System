$(document).ready(function () {
    loadTransactions(); // Load all on start

    $("#filterDate").on("change", function () {
        loadTransactions($(this).val());
    });

    function loadTransactions(dateFilter = "") {
        $.get(`/Transaction/GetTransactions?date=${dateFilter}`, function (data) {
            let html = "";

            if (data.length === 0) {
                html = "<div class='alert alert-warning'>No transactions found.</div>";
            } else {
                html = `
                    <table class="table table-bordered table-striped">
                        <thead class="table-dark">
                            <tr>
                                <th>Product</th>
                                <th>Quantity</th>
                                <th>Unit</th>
                                <th>Total Price</th>
                                <th>Date</th>
                            </tr>
                        </thead>
                        <tbody>
                `;

                data.forEach(trx => {
                    html += `
                        <tr>
                            <td>${trx.productName}</td>
                            <td>${trx.quantity}</td>
                            <td>${trx.unit}</td>
                            <td>${trx.totalPrice.toFixed(2)}</td>
                            <td>${new Date(trx.date).toLocaleDateString()}</td>
                        </tr>
                    `;
                });

                html += "</tbody></table>";
            }

            $("#transactionTable").html(html);
        });
    }
});
