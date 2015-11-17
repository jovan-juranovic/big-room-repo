window.vm.review = (function (ko, serverProxy, utility, toastr) {
    return function () {

        var self, initData, ReviewFactory, updateData;
        self = this;

        self.reviews = ko.observableArray();

        ReviewFactory = function (serverItem) {
            var that = this;
            that.id = serverItem.Id;
            that.title = serverItem.Title;
            that.comment = serverItem.Comment;
            that.date = serverItem.PostingDate;
            that.product = serverItem.ProductName;
            that.user = serverItem.UserEmail;
            that.rating = serverItem.Rating;
        };

        initData = function (serverData) {
            utility.initDataTable("reviews-table", self.reviews, serverData, ReviewFactory);
        };

        serverProxy.getReviews(initData);

    };
})(ko, util.serverProxy, util.utility, toastr);

ko.applyBindings(window.vm.review);