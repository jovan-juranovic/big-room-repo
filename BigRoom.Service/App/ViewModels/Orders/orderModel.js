window.vm.order = (function (ko, serverProxy, utility, toastr) {
    return function () {

        var self, initData, OrderFactory, updateData;
        self = this;

        self.orders = ko.observableArray();

        OrderFactory = function (serverItem) {
            var that = this;
            that.id = serverItem.Id;
            that.title = serverItem.Title;
            that.comment = serverItem.Comment;
            that.date = serverItem.PostingDate;
            that.product = serverItem.ProductName;
            that.user = serverItem.UserEmail;
            that.rating = serverItem.Rating;
        };

        initData = function (serverData) {
            utility.initDataTable("orders-table", self.orders, serverData, OrderFactory);
        };

        serverProxy.getOrders(initData);

    };
})(ko, util.serverProxy, util.utility, toastr);

ko.applyBindings(window.vm.order);