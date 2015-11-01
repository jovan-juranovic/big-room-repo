window.vm.category = (function (ko, serverProxy, utility, categoryAddEditFactory, mediator, toastr) {
    return function() {

        var self, initData, CategoryFactory, updateData;
        self = this;

        self.categories = ko.observableArray();

        CategoryFactory = function(serverItem) {
            var that = this;
            that.id = serverItem.Id;
            that.name = serverItem.Name;
        };

        CategoryFactory.prototype.edit = function() {
            utility.activateModalFromTemplate(new categoryAddEditFactory(this.id), "addEditCategory");
        };

        CategoryFactory.prototype.remove = function() {
            var categoryId = this.id;
            utility.dialog("", "Are you sure you want to delete category?", function() {
                serverProxy.deleteCategory(categoryId, updateData);
            });
        };

        mediator.subscribe("CategoryAddEditModel.editCategory", function (category, model) {
            serverProxy.editCategory(category, function (serverData) {
                model.closeModal();
                updateData(serverData);
            });
        });

        mediator.subscribe("CategoryAddEditModel.addCategory", function (category, model) {
            serverProxy.addCategory(category, function (serverData) {
                model.closeModal();
                updateData(serverData);
            });
        });

        updateData = function (serverData) {
            if (serverData.length > 0) {
                utility.reloadDataTable("categories-table", self.categories, serverData, CategoryFactory);
                toastr.success("Success executing action!");
            } else {
                toastr.error("Error executing action!");
            }
        };

        initData = function (serverData) {
            utility.initDataTable("categories-table", self.categories, serverData, CategoryFactory);
        };

        self.add = function() {
            utility.activateModalFromTemplate(new categoryAddEditFactory(), "addEditCategory");
        };

        serverProxy.getCategories(initData);

    };
})(ko, util.serverProxy, util.utility, vm.categoryAddEdit, mediator, toastr);

ko.applyBindings(window.vm.category);