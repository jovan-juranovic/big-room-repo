window.vm.userAddEdit = (function (ko, serverProxy, mediator) {

    return function(id) {
        var self, initData;
        self = this;

        self.isNewUser = false;
        self.name = ko.observable();
        self.email = ko.observable();
        self.password1 = ko.observable();
        self.password2 = ko.observable();

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
                    if (self.password1() === self.password2()) {
                        user.password = self.password1();
                        mediator.publish("UserAddEditModel.addUser", user, self);
                    }
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