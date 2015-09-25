'use strict';
app.controller('homeController', ['$scope', '$http', 'categoriesService', function ($scope, $http, categoriesService) {

    function initData(serverData) {
        $scope.categories = serverData;
    }

    categoriesService.getCategories(initData);
}]);