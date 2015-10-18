(function() {
    angular
        .module("BigRoomApp")
        .config(function ($urlRouterProvider, $stateProvider, jwtInterceptorProvider, $httpProvider) {

            $urlRouterProvider.otherwise("/home");

            $stateProvider.state("home", {
                url: "/home",
                templateUrl: "/app/views/home.html",
                controller: "IndexController",
                controllerAs: "indexCtrl"
            });

            $stateProvider.state("product", {
                url: "/product/:id",
                templateUrl: "/app/views/product.html",
                controller: "ProductController",
                controllerAs: "prodCtrl"
            });

            $stateProvider
                .state("cart", {
                    url: "/cart",
                    templateUrl: "/app/views/cart.html"
                })
                .state("cart-items", {
                    parent: "cart",
                    url: "/cart-items",
                    templateUrl: "/app/views/cart-items.html",
                    controller: "CartController",
                    controllerAs: "cartCtrl"
                })
                .state("customer-info", {
                    parent: "cart",
                    url: "/customer-info",
                    templateUrl: "/app/views/customer-info.html",
                    controller: "CustomerInfoController",
                    controllerAs: "customerCtrl"
                })
                .state("payment", {
                    parent: "cart",
                    url: "/payment",
                    templateUrl: "/app/views/payment.html",
                    controller: "PaymentController",
                    controllerAs: "paymentCtrl"
                });

            $stateProvider.state("orders", {
                url: "/orders",
                templateUrl: "/app/views/orders.html",
                controller: "OrderController",
                controllerAs: "orderCtrl"
            });

            $stateProvider.state("signup", {
                url: "/signup",
                controller: "SignupController",
                controllerAs: "signupCtrl",
                templateUrl: "/app/views/signup.html"
            });

            $stateProvider.state("login", {
                url: "/login",
                controller: "LoginController",
                controllerAs: "loginCtrl",
                templateUrl: "/app/views/login.html"
            });

            jwtInterceptorProvider.tokenGetter = function (store, jwtHelper) {
                var token = store.get('jwt');
                if (token && jwtHelper.isTokenExpired(token)) {
                    store.remove('jwt');
                    return undefined;
                }
                return token;
            };

            $httpProvider.interceptors.push('jwtInterceptor');
        })
        .run(function ($rootScope, $state, store) {
            $rootScope.$on('$stateChangeStart', function (e, to) {
                if (to.data && to.data.requiresLogin) {
                    if (!store.get('jwt')) {
                        e.preventDefault();
                        $state.go('login');
                    }
                }
            });
        })
        .controller("AppController", AppController);

        function AppController($scope) {
            $scope.$on('$routeChangeSuccess', function(e, nextRoute) {
                if (nextRoute.$$route && angular.isDefined(nextRoute.$$route.pageTitle)) {
                    $scope.pageTitle = nextRoute.$$route.pageTitle + ' | ngEurope Sample';
                }
            });
        }
})();