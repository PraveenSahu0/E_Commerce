document.addEventListener("DOMContentLoaded", function () {
    const quantityInputs = document.querySelectorAll(".quantity-input");
    const placeOrderButton = document.getElementById("placeNewOrderId");

    function checkQuantities() {
        let hasItems = Array.from(quantityInputs).some(input => parseInt(input.value) > 0);
        placeOrderButton.style.backgroundColor = hasItems ? "#4CAF50" : "grey";
        placeOrderButton.disabled = !hasItems;
    }

    quantityInputs.forEach(input => {
        input.addEventListener("input", checkQuantities);
    });

    checkQuantities();
});

function updateTotal() {
    var totalPrice = 0;
    var products = document.getElementsByClassName('quantity-input');
    for (var i = 0; i < products.length; i++) {
        var productId = products[i].id.split('-')[1];
        var quantity = parseInt(products[i].value);
        var price = parseFloat(document.querySelector('input[name="orderItems[' + productId + '].Price"]').value);

        totalPrice += quantity * price;
    }
    document.getElementById('total-price').innerText = 'Total Price: $' + totalPrice.toFixed(2);
}