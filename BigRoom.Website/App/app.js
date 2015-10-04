(function() {
    angular
        .module("BigRoomApp", ["ngAnimate", "ngSanitize", "toaster", "ui.select", "ngRoute", "angular-loading-bar"])
        .constant("baseService", { "url": "http://localhost:5300/" });
})();