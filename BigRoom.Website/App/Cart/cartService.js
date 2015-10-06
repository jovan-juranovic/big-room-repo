(function () {
    angular
        .module("BigRoomApp")
        .factory("cartService", cartService);

    cartService.$inject = ["$http", "baseService"];

    function cartService($http, baseService) {

        var cartServiceFactory = {};

        var getCountries = function () {
            return $http.get(baseService.url + "api/v1/spa/countries", { skipAuthorization: true })
                .then(function(data) {
                        return data;
                    }, function(error) {
                        console.log(error);
                        return error;
                    }
                );
        };

        cartServiceFactory.getCountries = getCountries;

        return cartServiceFactory;
    }
})();