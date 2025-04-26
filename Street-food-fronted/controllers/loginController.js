angular.module('miApp')
.controller('LoginController', function($scope, $location, AuthService) {
  $scope.usuario = { nombre: '', contrasena: '' };
  $scope.nuevoUsuario = { nombre: '', contrasena: '', rol: '' };
  $scope.mostrarRegistro = false;

  $scope.usuariosRegistrados = [
    { nombre: 'cliente', contrasena: '123', rol: 'cliente' },
    { nombre: 'cocinero', contrasena: '123', rol: 'cocinero' },
    { nombre: 'domiciliario', contrasena: '123', rol: 'domiciliario' }
  ];

  $scope.login = function() {
    const user = $scope.usuariosRegistrados.find(u =>
      u.nombre === $scope.usuario.nombre && u.contrasena === $scope.usuario.contrasena
    );

    if (user) {
      AuthService.login(user);
      $location.path('/' + user.rol);
    } else {
      alert('Usuario o contraseña incorrectos');
    }
  };

  $scope.registrar = function() {
    $scope.usuariosRegistrados.push({
      nombre: $scope.nuevoUsuario.nombre,
      contrasena: $scope.nuevoUsuario.contrasena,
      rol: $scope.nuevoUsuario.rol
    });
    alert('Usuario registrado con éxito ✅');

    // Opcionalmente: loguearlo y redirigirlo
    AuthService.login($scope.nuevoUsuario);
    $location.path('/' + $scope.nuevoUsuario.rol);
  };
});
