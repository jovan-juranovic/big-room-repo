(function () {
    angular
        .module("BigRoomApp")
        .controller("MenuController", MenuController);

    MenuController.$inject = ["$rootScope"];

    function MenuController($rootScope) {
        var menuCtrl = this;

        menuCtrl.counter = 0;

        $rootScope.$on("addToCart", function (event, data) {
            menuCtrl.counter++;
        });

        $rootScope.$on("removeFromCart", function (event, data) {
            menuCtrl.counter--;
        });
    };
})();