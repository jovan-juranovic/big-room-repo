window.vm.index = (function (ko, serverProxy) {
    return function () {

        var self, initData;
        self = this;

        self.reviewCount = ko.observable();
        self.userCount = ko.observable();
        self.productCount = ko.observable();
        self.orderCount = ko.observable();

        initData = function (serverData) {
            self.reviewCount(serverData.ReviewCount);
            self.userCount(serverData.UserCount);
            self.productCount(serverData.ProductCount);
            self.orderCount(serverData.OrderCount);
        };

        serverProxy.getCount(initData);

    };
})(ko, util.serverProxy);

ko.applyBindings(window.vm.index);