window.vm.userAddEdit = (function (ko, serverProxy, mediator) {

    return function(id) {
        var self, initData;
        self = this;

        self.isNewUser = false;
        self.name = ko.observable();
        self.email = ko.observable();

        initData = function(serverData) {
            self.name(serverData.Name);
            self.email(serverData.Email);
        };

        self.save = function() {
            if (self.name() && self.email()) {
                var user = {};
                user.id = id;
                user.name = self.name();
                user.email = self.email();
                if (self.isNewUser) {

                } else {
                    mediator.publish("UserAddEditModel.editUser", user, self);
                }
            }
        }

        if (id) {
            self.isNewUser = false;
            serverProxy.getUser(id, initData);
        } else {
            self.isNewUser = true;
        }
    };

})(ko, util.serverProxy, mediator);