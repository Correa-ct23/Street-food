angular.module('miApp')
.factory('AuthService', function() {
  var usuario = null;

  return {
    login: function(datos) {
      usuario = datos;
    },
    logout: function() {
      usuario = null;
    },
    getUsuario: function() {
      return usuario;
    }
  };
});
