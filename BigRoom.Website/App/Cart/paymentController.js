(function () {
    angular
        .module("BigRoomApp")
        .controller("PaymentController", PaymentController);

    PaymentController.$inject = ["cartService", "store", "$state", "toaster", "$scope", "$filter"];

    function PaymentController(cartService, store, $state, toaster, $scope, $filter) {
        var paymentCtrl = this;

        paymentCtrl.order = {};

        paymentCtrl.order.payment = {};
        paymentCtrl.order.customer = {};
        paymentCtrl.order.items = [];

        paymentCtrl.exp = new Date();

        $scope.$watch("paymentCtrl.exp", function (value) {
            paymentCtrl.order.payment.Expiration = $filter('date')(new Date(value), 'MM/dd/yyyy');
        });

        paymentCtrl.placeOrder = function (card) {
            var cart = store.get("cart");
            paymentCtrl.order.payment = card;
            paymentCtrl.order.customer = store.get("customer");
            paymentCtrl.order.items = cart.cartItems;
            paymentCtrl.order.Subtotal = cart.subtotal;
            paymentCtrl.order.ShippingTotal = cart.shippingCost;

            console.log(paymentCtrl.order);
            cartService.placeOrder(paymentCtrl.order)
                .then(function(serverData) {
                    localStorage.clear();
                    $state.go("home");

                    toaster.pop({
                        type: "success",
                        title: "Success",
                        body: "Order successfuly placed! You can see order status or cancel an order in your orders dashboard.",
                        showCloseButton: true
                    });
                });
        };
    }
})();