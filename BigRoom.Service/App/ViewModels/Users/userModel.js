window.vm.user = (function (ko, serverProxy, utility, userAddEditFactory, mediator) {

    var self, initData, UserFactory, updateData;
    self = this;

    self.users = ko.observableArray();

    UserFactory = function(serverItem) {
        var that = this;
        that.id = serverItem.Id;
        that.name = serverItem.Name;
        that.email = serverItem.Email;
    };

    UserFactory.prototype.edit = function () {
        utility.activateModalFromTemplate(new userAddEditFactory(this.id), "addEditUser");
    };

    mediator.subscribe("UserAddEditModel.editUser", function (user, model) {
        serverProxy.editUser(user, function(serverData) {
            model.closeModal();
            updateData(serverData);
        });
    });

    updateData = function(serverData) {
        utility.rebuildObservableArray(self.users, serverData, UserFactory);
    }

    initData = function(serverData) {
        utility.rebuildObservableArray(self.users, serverData, UserFactory);
        $('#users-table').DataTable({
            responsive: true
        });
    };

    serverProxy.getUsers(initData);

})(ko, util.serverProxy, util.utility, vm.userAddEdit, mediator);

ko.applyBindings(window.vm.user);