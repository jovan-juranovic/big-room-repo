window.vm.user = (function (ko, serverProxy, utility, userAddEditFactory, mediator, toastr) {

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

    UserFactory.prototype.remove = function () {
        var userId = this.id;
        utility.dialog("", "Are you sure you want to delete user?", function() {
            serverProxy.deleteUser(userId, updateData);
        });
    };

    mediator.subscribe("UserAddEditModel.editUser", function (user, model) {
        serverProxy.editUser(user, function(serverData) {
            model.closeModal();
            updateData(serverData);
        });
    });

    updateData = function (serverData) {
        if (serverData.length > 0) {
            utility.reloadDataTable("users-table", self.users, serverData, UserFactory);
            toastr.success("User successfully updated!");
        } else {
            toastr.error("Error updating user!");
        }
    };

    initData = function (serverData) {
        utility.initDataTable("users-table", self.users, serverData, UserFactory);
    };

    serverProxy.getUsers(initData);

})(ko, util.serverProxy, util.utility, vm.userAddEdit, mediator, toastr);

ko.applyBindings(window.vm.user);