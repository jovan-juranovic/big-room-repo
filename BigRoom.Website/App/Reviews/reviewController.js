(function () {
    angular
        .module("BigRoomApp")
        .controller("ReviewController", ReviewController);

    ReviewController.$inject = ["$scope", "$stateParams", "reviewService", "toastr"];

    function ReviewController($scope, $stateParams, reviewService, toastr) {
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
            review.ProductId = $stateParams.id;
            console.log(review);

            reviewService.addReview(review).then(function(serverData) {
                console.log(serverData);
                if (serverData.status === 201) {
                    toastr.success('Succsesfully submited !', "Success");
                } else {
                    toastr.error(serverData.statusText, "Error");
                }
            });

            $scope.reviewForm.$setPristine();
            $scope.reviewForm.$setUntouched();
            reviewCtrl.review = {};
        };
    }
})();