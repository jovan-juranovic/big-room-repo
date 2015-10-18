(function() {
    angular
        .module("BigRoomApp")
        .controller("ProductController", ProductController);

    ProductController.$inject = ["$stateParams", "productsService", "store", "$rootScope", "toaster"];

    function ProductController($stateParams, productsService, store, $rootScope, toaster) {
        var prodCtrl = this;

        prodCtrl.product = {};

        prodCtrl.addToCart = function(product) {
            if (store.get("item_" + product.Id)) {
                toaster.pop({
                    type: "error",
                    title: "Error",
                    body: "Product is allready added to cart!",
                    showCloseButton: true
                });
            } else {
                store.set("item_" + product.Id, {
                    Id: product.Id,
                    Price: product.Price,
                    ShippingPrice: product.ShippingPrice,
                    Quantity: 1
                });
                $rootScope.$broadcast("addToCart", {});
                toaster.pop({
                    type: "success",
                    title: "Success",
                    body: "Product is successfuly added to cart!",
                    showCloseButton: true
                });
            };
        }

        initData = function() {
            productsService.getProduct($stateParams.id)
                .then(function(serverData) {
                    prodCtrl.product = serverData.data;
                    return prodCtrl.product;
                }
            );
        };

        initData();
    }
})();