window.vm.categoryAddEdit = (function (ko, serverProxy, mediator) {
    return function (id) {

        var self, initData;
        self = this;

        self.isNew = false;
        self.name = ko.observable();

        initData = function (serverData) {
            self.name(serverData.Name);
        };

        self.save = function() {
            if (self.name()) {
                var category = {};
                category.id = id;
                category.name = self.name();
                if (self.isNew) {
                    mediator.publish("CategoryAddEditModel.addCategory", category, self);
                } else {
                    mediator.publish("CategoryAddEditModel.editCategory", category, self);
                }
            }
        };

        if (id) {
            self.isNew = false;
            serverProxy.getCategory(id, initData);
        } else {
            self.isNew = true;
        }
    };
})(ko, util.serverProxy, mediator);