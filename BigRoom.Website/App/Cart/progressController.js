(function () {
    angular
        .module("BigRoomApp")
        .controller("ProgressController", ProgressController);

    ProgressController.$inject = ["$state"];

    function ProgressController($state) {
        var progressCtrl = this;

        progressCtrl.isCustomerInfoPage = function() {
            if ($state.current.name === "customer-info") {
                return true;
            }
            return false;
        };

        progressCtrl.isPaymentMethodPage = function() {
            if ($state.current.name === "payment") {
                return true;
            }
            return false;
        };
    }
})();