(function() {
    angular
        .module("BigRoomApp")
        .controller("WellController", WellController);

    function WellController() {
        var wellCtrl = this;

        wellCtrl.tab = 1;
        wellCtrl.showForm = false;

        wellCtrl.selectTab = function(setTab) {
            wellCtrl.tab = setTab;
        };

        wellCtrl.isSelected = function(checkTab) {
            return wellCtrl.tab === checkTab;
        };

        wellCtrl.setForm = function() {
            if (wellCtrl.showForm) {
                wellCtrl.showForm = false;
            } else {
                wellCtrl.showForm = true;
            }
        };
    }
})();