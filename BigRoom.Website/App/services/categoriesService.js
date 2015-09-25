'use strict';
app.factory('categoriesService', ['$http', function ($http) {

    var serviceBase = 'http://localhost:5300/';
    var categoriesServiceFactory = {};

    var getCategories = function(callback) {
        $http.get(serviceBase + "api/categories")
            .success(callback)
            .error(callback);
    };

    categoriesServiceFactory.getCategories = getCategories;

    return categoriesServiceFactory;

}]);