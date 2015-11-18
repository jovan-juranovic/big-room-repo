(function() {
    angular
        .module("BigRoomApp")
        .controller("ProductController", ProductController);

    ProductController.$inject = ["$stateParams", "productsService", "store", "$rootScope", "toastr"];

    function ProductController($stateParams, productsService, store, $rootScope, toastr) {
        var prodCtrl = this;

        prodCtrl.product = {};

        prodCtrl.addToCart = function(product) {
            if (localStorage.getItem("item_" + product.Id)) {
                toastr.error("Product is allready added to cart!", "Error");
            } else {
                localStorage.setItem("item_" + product.Id, JSON.stringify({
                    Id: product.Id,
                    Name: product.Name,
                    Price: product.Price,
                    ShippingPrice: product.ShippingPrice,
                    Quantity: 1
                }));
                $rootScope.$broadcast("addToCart", {});
                toastr.success("Product is successfuly added to cart!", "Success");
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