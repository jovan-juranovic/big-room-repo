(function() {
    angular
        .module("BigRoomApp")
        .controller("CategoriesController", CategoriesController);

    CategoriesController.$inject = ["categoriesService"];

    function CategoriesController(categoriesService) {
        var categoriesCtrl = this;

        categoriesCtrl.disabled = undefined;

        categoriesCtrl.enable = function () {
            $scope.disabled = false;
        };

        categoriesCtrl.disable = function () {
            $scope.disabled = true;
        };

        categoriesCtrl.clear = function () {
            $scope.category.selected = undefined;
        };

        categoriesCtrl.category = {};
        categoriesCtrl.categories = [];

        initData = function() {
            categoriesService
                .getCategories()
                .then(function(serverData) {
                        categoriesCtrl.categories = serverData.data;
                        return categoriesCtrl.categories;
                    }
                );
        };

        initData();
    };
})();