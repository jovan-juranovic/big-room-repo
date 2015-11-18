window.vm.orderInfo = (function (ko, serverProxy, mediator) {
    return function (id) {

        var self, initData;
        self = this;

        self.items = ko.observableArray();
        self.address1 = ko.observable();
        self.address2 = ko.observable();
        self.city = ko.observable();
        self.country = ko.observable();
        self.fullName = ko.observable();
        self.phone = ko.observable();
        self.region = ko.observable();
        self.zipCode = ko.observable();
        self.nameOnCard = ko.observable();
        self.cardNumber = ko.observable();
        self.expiration = ko.observable();

        initData = function (serverData) {
            self.address1(serverData.Customer.Address1);
            self.address2(serverData.Customer.Address2);
            self.city(serverData.Customer.City);
            self.country(serverData.Customer.CountryName);
            self.fullName(serverData.Customer.FullName);
            self.phone(serverData.Customer.Phone);
            self.region(serverData.Customer.Region);
            self.zipCode(serverData.Customer.ZipCode);
            self.nameOnCard(serverData.Payment.NameOnCard);
            self.cardNumber(serverData.Payment.CardNumber);
            self.expiration(serverData.Payment.Expiration);
            self.items(serverData.Items);
        };

        serverProxy.getOrder(id, initData);

    };
})(ko, util.serverProxy, mediator);