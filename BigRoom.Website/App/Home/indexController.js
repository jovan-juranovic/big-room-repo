(function() {
    angular
        .module("BigRoomApp")
        .controller("IndexController", IndexController);

    IndexController.$inject = ["$rootScope"];

    function IndexController($rootScope) {
        var indexCtrl = this;

        $rootScope.$on("addToCart", function (event, data) {
            console.log(data);
        });
    };
})();