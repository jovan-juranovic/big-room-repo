(function() {
    angular
        .module("BigRoomApp")
        .factory("categoriesService", categoriesService);

    categoriesService.$inject = ["$http", "baseService"];

    function categoriesService($http, baseService) {

        var categoriesServiceFactory = {};

        var getCategories = function() {
            return $http.get(baseService.url + "api/categories")
                .then(function(data) {
                        return data;
                    }, function(error) {
                        console.log(error);
                        return error;
                    }
                );
        };

        categoriesServiceFactory.getCategories = getCategories;

        return categoriesServiceFactory;
    };
})();