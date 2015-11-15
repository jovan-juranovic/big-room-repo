window.vm.product = (function (ko, serverProxy, utility, productAddEditFactory, mediator, toastr) {
    return function() {

        var self, initData, ProductFactory, updateData;
        self = this;

        self.products = ko.observableArray();

        ProductFactory = function(serverItem) {
            var that = this;
            that.id = serverItem.Id;
            that.name = serverItem.Name;
            that.description = serverItem.Description;
            that.category = serverItem.Category;
            that.price = serverItem.Price;
            that.shippingPrice = serverItem.ShippingPrice;
            that.status = serverItem.Status;
        };

        ProductFactory.prototype.edit = function() {
            utility.activateModalFromTemplate(new productAddEditFactory(this.id), "addEditProduct");
        };

        ProductFactory.prototype.remove = function() {
            var productId = this.id;
            utility.dialog("", "Are you sure you want to delete product?", function () {
                serverProxy.deleteProduct(productId, updateData);
            });
        };

        ProductFactory.prototype.info = function() {
            
        };

        self.add = function() {
            utility.activateModalFromTemplate(new productAddEditFactory(), "addEditProduct");
        };

        mediator.subscribe("ProductAddEditModel.editProduct", function (product, model) {
            serverProxy.editProduct(product, function (serverData) {
                model.closeModal();
                updateData(serverData);
            });
        });

        updateData = function (serverData) {
            if (serverData.length > 0) {
                utility.reloadDataTable("products-table", self.products, serverData, ProductFactory);
                toastr.success("Success executing action!");
            } else {
                toastr.error("Error executing action!");
            }
        };

        initData = function(serverData) {
            utility.initDataTable("products-table", self.products, serverData, ProductFactory);
        };

        serverProxy.getProducts(initData);

    };
})(ko, util.serverProxy, util.utility, vm.productAddEdit, mediator, toastr);

ko.applyBindings(window.vm.product);