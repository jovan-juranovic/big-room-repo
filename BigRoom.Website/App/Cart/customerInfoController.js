(function () {
    angular
        .module("BigRoomApp")
        .controller("CustomerInfoController", CustomerInfoController);

    CustomerInfoController.$inject = ["cartService", "store"];

    function CustomerInfoController(cartService, store) {
        var customerCtrl = this;

        customerCtrl.countries = [];
        customerCtrl.customer = {};

        customerCtrl.addCustomer = function(customer) {
            store.set("customer", customer);
        };

        customerCtrl.removeItems = function() {
            store.remove("items");
        };

        initData = function() {
            cartService.getCountries()
                .then(function(serverData) {
                        customerCtrl.countries = serverData.data;
                        return customerCtrl.countries;
                    }
                );
        };

        initData();
    }
})();