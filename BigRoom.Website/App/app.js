(function() {
    angular
        .module("BigRoomApp", ["ngSanitize", "ui.select", "ngRoute", "angular-loading-bar"])
        .constant("baseService", { "url": "http://localhost:5300/" });
})();