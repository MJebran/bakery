export function initialisePayPal(dotNetObject) {
    var description = document.querySelector('#smart-button-container #description');
    var amount = document.querySelector('#smart-button-container #amount');

    var purchase_units = [];
    purchase_units[0] = {};
    purchase_units[0].amount = {};

    paypal.Buttons({
        style: {
            color: 'gold',
            shape: 'rect',
            label: 'paypal',
            layout: 'vertical',

        },

        createOrder: function (data, actions) {

            purchase_units[0].description = description.value;
            purchase_units[0].amount.value = amount.value;

            return actions.order.create({
                purchase_units: purchase_units,
            });
        },

        onApprove: function (data, actions) {
            return actions.order.capture().then(function (orderData) {

                console.log('Capture result', orderData, JSON.stringify(orderData, null, 2));
                DotNet.invokeMethodAsync('Bakery.ClassLibrary', 'ReceiveDataFromJS', dotNetObject)
            });
        },

        onError: function (err) {
            console.log(err);
        }
    }).render('#paypal-button-container');
}

// export function onUpdate() {
//     initialisePayPal();
// }


