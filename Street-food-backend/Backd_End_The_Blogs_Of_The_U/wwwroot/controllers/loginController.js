angular.module('miApp')
.controller('LoginController', function($scope, $location, AuthService) {
  $scope.usuario = { nombre: '', contrasena: ''};
  $scope.nuevoUsuario = { nombre: '', contrasena: '', rol: '', direccion: '' };
  $scope.mostrarRegistro = false;

  $scope.usuariosRegistrados = [
    { nombre: 'cliente', contrasena: '123', rol: 'cliente', direccion: 'Calle 123 #45-67' },
    { nombre: 'cocinero', contrasena: '123', rol: 'cocinero', direccion: 'Calle 123 #45-67' },
    { nombre: 'domiciliario', contrasena: '123', rol: 'domiciliario', direccion: 'Calle 123 #45-67' },
    { nombre: 'admin', contrasena: '123', rol: 'admin', direccion: 'Calle 123 #45-67' }
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
      rol: $scope.nuevoUsuario.rol,
      direccion: $scope.nuevoUsuario.direccion
    });
    alert('Usuario registrado con éxito ✅');

    // Opcionalmente: loguearlo y redirigirlo
    AuthService.login($scope.nuevoUsuario);
    $location.path('/' + $scope.nuevoUsuario.rol);
  };
});
