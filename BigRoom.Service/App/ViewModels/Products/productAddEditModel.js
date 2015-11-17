window.vm.productAddEdit = (function (ko, serverProxy, mediator) {
    return function(id) {
        
        var self, initData, initSelectList;
        self = this;

        self.isNew = false;
        self.name = ko.observable();
        self.description = ko.observable();
        self.selectedCategory = ko.observable();
        self.price = ko.observable();
        self.shippingPrice = ko.observable();
        self.status = ko.observable();

        initData = function (serverData) {
            self.name(serverData.Name);
            self.description(serverData.Description);
            self.selectedCategory(serverData.CategoryId);
            self.price(serverData.Price);
            self.shippingPrice(serverData.ShippingPrice);
            self.status(serverData.Status);
        };

        self.statuses = ko.observableArray(['Active', 'Inactive']);
        self.categories = ko.observableArray();

        initSelectList = function(serverData) {
            self.categories(serverData);
        };

        self.save = function () {
            if (self.name() && self.description() && self.selectedCategory() && self.price() && self.shippingPrice()) {
                var product = {};
                product.id = id;
                product.name = self.name();
                product.description = self.description();
                product.category = self.selectedCategory();
                product.price = self.price();
                product.shippingPrice = self.shippingPrice();
                product.status = self.status();
                if (self.isNew) {
                    mediator.publish("ProductAddEditModel.addProduct", product, self);
                } else {
                    mediator.publish("ProductAddEditModel.editProduct", product, self);
                }
            }
        };

        serverProxy.getCategories(initSelectList);

        if (id) {
            self.isNew = false;
            serverProxy.getProduct(id, initData);
        } else {
            self.isNew = true;
        }
    }
})(ko, util.serverProxy, mediator);