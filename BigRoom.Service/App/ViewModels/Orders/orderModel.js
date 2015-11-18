window.vm.order = (function (ko, serverProxy, utility, orderInfoFactory, toastr) {
    return function () {

        var self, initData, OrderFactory, updateData;
        self = this;

        self.orders = ko.observableArray();

        OrderFactory = function (serverItem) {
            var that = this;
            that.id = serverItem.Id;
            that.orderNumber = serverItem.OrderNumber;
            that.orderDate = serverItem.OrderDate;
            that.comment = serverItem.Comment;
            that.subtotal = serverItem.Subtotal;
            that.shipping = serverItem.ShippingTotal;
            that.total = serverItem.Total;
            that.user = serverItem.Username;
        };

        OrderFactory.prototype.info = function() {
            utility.activateModalFromTemplate(new orderInfoFactory(this.id), "orderInfo");
        };

        initData = function (serverData) {
            utility.initDataTable("orders-table", self.orders, serverData, OrderFactory);
        };

        serverProxy.getOrders(initData);

    };
})(ko, util.serverProxy, util.utility, vm.orderInfo, toastr);

ko.applyBindings(window.vm.order);