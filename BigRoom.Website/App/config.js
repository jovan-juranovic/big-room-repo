(function() {
    angular
        .module("BigRoomApp")
        .config(function($routeProvider) {

            $routeProvider.when("/home", {
                templateUrl: "/app/views/home.html",
                controller: "IndexController",
                controllerAs: "indexCtrl"
            });

            $routeProvider.when("/product/:id", {
                templateUrl: "/app/views/product.html",
                controller: "ProductController",
                controllerAs: "prodCtrl"
            });

            $routeProvider.otherwise({ redirectTo: "/home" });
        });
})();