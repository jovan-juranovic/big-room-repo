(function() {
    angular
        .module("BigRoomApp",
        [
            "angular-jwt",
            "angular-storage",
            "ui.router",
            "ngAnimate",
            "ngSanitize",
            "toaster",
            "ui.select",
            "ngRoute",
            "angular-loading-bar"
        ])
        .constant("baseService", { "url": "http://localhost:5300/" });
})();