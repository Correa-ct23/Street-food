angular.module('miApp', ['ngRoute'])
.config(function($routeProvider) {
  $routeProvider
    .when('/', {
      templateUrl: 'views/login.html',
      controller: 'LoginController'
    })
    .when('/cliente', {
      templateUrl: 'views/cliente.html',
      controller: 'ClienteController'
    })
    .when('/cocinero', {
      templateUrl: 'views/cocinero.html',
      controller: 'CocineroController'
    })
    .when('/domiciliario', {
      templateUrl: 'views/domiciliario.html',
      controller: 'DomiciliarioController'
    })
    .when('/admin', {
      templateUrl: 'views/admin.html',
      controller: 'AdminController'
    })
    .otherwise({
      redirectTo: '/'
    });
});
