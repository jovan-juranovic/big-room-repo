(function() {
    angular
        .module("BigRoomApp")
        .factory("productsService", productsService);

    productsService.$inject = ["$http", "baseService"];

    function productsService($http, baseService) {
        
        var productsServiceFactory = {};

        var getProductsFromCategory = function(categoryId) {
            return $http.get(baseService.url + "api/v1/spa/products/?categoryId=" + categoryId)
                .then(function(data) {
                        return data;
                    }, function(error) {
                        console.log(error);
                        return error;
                    }
                );
        };

        var getProducts = function () {
            return $http.get(baseService.url + "api/v1/spa/products")
                .then(function(data) {
                        return data;
                    }, function(error) {
                        console.log(error);
                        return error;
                    }
                );
        };

        var getProduct = function (productId) {
            return $http.get(baseService.url + "api/v1/spa/products/" + productId)
                .then(function(data) {
                        return data;
                    }, function(error) {
                        console.log(error);
                        return error;
                    }
                );
        };

        productsServiceFactory.getProductsFromCategory = getProductsFromCategory;
        productsServiceFactory.getProducts = getProducts;
        productsServiceFactory.getProduct = getProduct;

        return productsServiceFactory;
    }
})();