(function() {
    angular
        .module("BigRoomApp")
        .controller("ProductsController", ProductsController);

    ProductsController.$inject = ["$state", "productsService"];

    function ProductsController($state, productsService) {
        var productsCtrl = this;

        productsCtrl.disabled = undefined;

        productsCtrl.enable = function () {
            $scope.disabled = false;
        };

        productsCtrl.disable = function () {
            $scope.disabled = true;
        };

        productsCtrl.clear = function () {
            $scope.category.selected = undefined;
        };

        productsCtrl.product = {};
        productsCtrl.products = [];

        productsCtrl.searchProducts = function(categoryId) {
            if (categoryId) {
                productsService
                    .getProductsFromCategory(categoryId)
                    .then(function(serverData) {
                            productsCtrl.products = serverData.data;
                            return productsCtrl.products;
                        }
                    );
            } else {
                productsService
                    .getProducts()
                    .then(function(serverData) {
                            productsCtrl.products = serverData.data;
                            return productsCtrl.products;
                        }
                    );
            }
        };

        productsCtrl.goToProduct = function(productId) {
            $state.go("product", { id: productId });
        };
    }
})();