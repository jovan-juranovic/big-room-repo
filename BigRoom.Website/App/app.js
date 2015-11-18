(function() {
    angular
        .module("BigRoomApp",
        [
            "angular-jwt",
            "angular-storage",
            "ui.router",
            "ngAnimate",
            "ngSanitize",
            "ui.select",
            "ngRoute",
            "angular-loading-bar",
            "toastr"
        ])
        .constant("baseService", { "url": "http://localhost:5300/" });
})();