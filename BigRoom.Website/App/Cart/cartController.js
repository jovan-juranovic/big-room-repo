(function () {
    angular
        .module("BigRoomApp")
        .controller("CartController", CartController);

    CartController.$inject = ["store", "$rootScope"];

    function CartController(store, $rootScope) {
        var cartCtrl = this;

        cartCtrl.cart = {};
        cartCtrl.cart.subtotal = 0;
        cartCtrl.cart.shippingCost = 0;
        cartCtrl.cart.cartItems = [];

        cartCtrl.calculate = function (id, qty) {
            angular.forEach(cartCtrl.cart.cartItems, function (value, key) {
                if (value.Id === id) {
                    var basePrice = JSON.parse(localStorage.getItem("item_" + id)).Price;
                    var baseShippingPrice = JSON.parse(localStorage.getItem("item_" + id)).ShippingPrice;
                    value.Price = qty * basePrice;
                    value.ShippingPrice = qty * baseShippingPrice;
                }
            });

            cartCtrl.cart.subtotal = 0;
            cartCtrl.cart.shippingCost = 0;

            angular.forEach(cartCtrl.cart.cartItems, function (value, key) {
                cartCtrl.cart.subtotal += value.Price;
                cartCtrl.cart.shippingCost += value.ShippingPrice;
            });
        };

        cartCtrl.removeItem = function(id) {
            angular.forEach(cartCtrl.cart.cartItems, function (value, key) {
                if (value.Id === id) {
                    cartCtrl.cart.cartItems.splice(key, 1);
                    store.remove("item_" + id);
                    $rootScope.$broadcast("removeFromCart", {});
                }
            });

            cartCtrl.cart.subtotal = 0;
            cartCtrl.cart.shippingCost = 0;

            angular.forEach(cartCtrl.cart.cartItems, function (value, key) {
                cartCtrl.cart.subtotal += value.Price;
                cartCtrl.cart.shippingCost += value.ShippingPrice;
            });
        };

        initData = function () {
            var array = [];
            for (var i = 0; i < localStorage.length; i++) {
                if (localStorage.key(i).substring(0, 4) === "item") {
                    var item = JSON.parse(localStorage.getItem(localStorage.key(i)));
                    item.Quantity = 1;
                    array.push(item);
                }
            }

            cartCtrl.cart.cartItems = array;
            angular.forEach(cartCtrl.cart.cartItems, function(value, key) {
                cartCtrl.cart.subtotal += value.Price;
                cartCtrl.cart.shippingCost += value.ShippingPrice;
            });
        };

        initData();
    }
})();