(function () {
    angular
        .module("BigRoomApp")
        .factory("reviewService", reviewService);

    reviewService.$inject = ["$http", "baseService"];

    function reviewService($http, baseService) {

        var reviewServiceFactory = {};

        var addReview = function (review) {
            return $http.post(baseService.url + "api/v1/spa/reviews", review)
                .then(function(data) {
                        return data;
                    }, function(error) {
                        console.log(error);
                        return error;
                    }
                );
        };

        reviewServiceFactory.addReview = addReview;

        return reviewServiceFactory;
    };
})();