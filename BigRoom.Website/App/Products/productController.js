(function() {
    angular
        .module("BigRoomApp")
        .controller("ProductController", ProductController);

    ProductController.$inject = ["$routeParams", "productsService"];

    function ProductController($routeParams, productsService) {
        var prodCtrl = this;

        prodCtrl.product = {};

        initData = function() {
            productsService.getProduct($routeParams.id)
                .then(function(serverData) {
                    prodCtrl.product = serverData.data;
                    return prodCtrl.product;
                }
            );
        };

        initData();
    }
})();