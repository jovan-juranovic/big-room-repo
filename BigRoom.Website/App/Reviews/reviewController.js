(function () {
    angular
        .module("BigRoomApp")
        .controller("ReviewController", ReviewController);

    ReviewController.$inject = ["$scope", "$routeParams", "reviewService", "toaster"];

    function ReviewController($scope, $routeParams, reviewService, toaster) {
        var reviewCtrl = this;

        reviewCtrl.review = {};

        reviewCtrl.ratings = [
            { code: "1", name: "1 Star" },
            { code: "2", name: "2 Stars" },
            { code: "3", name: "3 Stars" },
            { code: "4", name: "4 Stars" },
            { code: "5", name: "5 Stars" }
        ];

        reviewCtrl.addReview = function (review) {
            review.ProductId = $routeParams.id;
            console.log(review);

            reviewService.addReview(review).then(function(serverData) {
                console.log(serverData);
                if (serverData.status === 201) {
                    toaster.pop({
                        type: 'success',
                        title: 'Review',
                        body: 'Succsesfully submited!',
                        showCloseButton: true
                    });
                } else {
                    toaster.pop({
                        type: 'error',
                        title: 'Review',
                        body: serverData.statusText,
                        showCloseButton: true
                    });
                }
            });

            $scope.reviewForm.$setPristine();
            $scope.reviewForm.$setUntouched();
            reviewCtrl.review = {};
        };
    }
})();