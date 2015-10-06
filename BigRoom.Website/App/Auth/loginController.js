(function () {
    angular
        .module("BigRoomApp")
        .controller("LoginController", LoginController);

    LoginController.$inject = ["$http", "store", "$state", "baseService"];

    function LoginController($http, store, $state, baseService) {
        var loginCtrl = this;

        loginCtrl.user = {};

        loginCtrl.login = function(user) {
            $http.post(baseService.url + "api/v1/spa/auth", user)
                .then(function (response) {
                        console.log(response);
                        store.set("jwt", response.data.AccessToken);
                        $state.go("home");
                    }, function(error) {
                        console.log(error);
                    }
                );
        };
    }
})();