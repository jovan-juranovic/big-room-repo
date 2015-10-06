(function () {
    angular
        .module("BigRoomApp")
        .controller("SignupController", SignupController);

    SignupController.$inject = ["$http", "store", "$state", "baseService"];

    function SignupController($http, store, $state, baseService) {
        var signupCtrl = this;

        signupCtrl.user = {};

        signupCtrl.createUser = function(user) {
            $http.post(baseService + "api/v1/spa/auth", user)
                .then(function(response) {
                        store.set("jwt", response.data.AccessToken);
                        $state.go("/home");
                    }, function(error) {
                        console.log(error);
                    }
                );
        };
    }
})();