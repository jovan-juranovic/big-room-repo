(function () {
    angular
        .module("BigRoomApp")
        .controller("PaymentController", PaymentController);

    PaymentController.$inject = ["cartService", "store", "$state", "toastr", "$scope", "$filter", "$rootScope"];

    function PaymentController(cartService, store, $state, toastr, $scope, $filter, $rootScope) {
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
            var cart = JSON.parse(localStorage.getItem("cart"));
            paymentCtrl.order.payment = card;
            paymentCtrl.order.customer = JSON.parse(localStorage.getItem("customer"));
            paymentCtrl.order.items = cart.cartItems;
            paymentCtrl.order.Subtotal = cart.subtotal;
            paymentCtrl.order.ShippingTotal = cart.shippingCost;

            console.log(paymentCtrl.order);
            cartService.placeOrder(paymentCtrl.order)
                .then(function(serverData) {
                    var token = localStorage.getItem("jwt");
                    localStorage.clear();
                    $rootScope.$broadcast("removeAllFromCart", {});
                    if (token) {
                        localStorage.setItem("jwt", token);
                    }
                    toastr.success("Order successfuly placed!", "Success");
                    $state.go("home");
                });
        };
    }
})();