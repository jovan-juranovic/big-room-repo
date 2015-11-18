(function() {
    angular
        .module("BigRoomApp")
        .controller("IndexController", IndexController);

    IndexController.$inject = ["$rootScope", "productsService", "store"];

    function IndexController($rootScope, productsService, store) {
        var indexCtrl = this;

        $rootScope.$on("addToCart", function (event, data) {
            console.log(data);
        });

        indexCtrl.products = [];

        indexCtrl.shouldShowCart = function () {
            if (localStorage.length > 1) {
                return true;
            }
            if (localStorage.length === 1) {
                if (localStorage.getItem("jwt")) {
                    return false;
                }

                return true;
            }

            return false;
        };

        initData = function () {
            productsService.getTopProducts()
                .then(function (serverData) {
                    indexCtrl.products = serverData.data;
                    return indexCtrl.products;
                }
            );
        };

        initData();
    };
})();