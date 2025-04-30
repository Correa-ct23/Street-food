angular.module('miApp')
.controller('CocineroController', function($scope, PedidoService, $location) {
  // Recuperar los pedidos pendientes
  $scope.pedidosPendientes = PedidoService.getPedidos();
  $scope.noHayPedidos = $scope.pedidosPendientes.length === 0;
  $scope.estimado = false;
  // Actualizar el estado cuando cambian los pedidos
  $scope.$watch('pedidosPendientes', function(newVal) {
    $scope.noHayPedidos = newVal.length === 0;
  });

  // Función para estimar el tiempo y asignarlo al pedido
  $scope.estimarTiempo = function(tiempoEstimado, pedido) {
    if (tiempoEstimado && tiempoEstimado > 0) {
      pedido.tiempoEstimado = tiempoEstimado;
      alert('Tiempo estimado confirmado: ' + tiempoEstimado + ' minutos');
      $scope.estimado = true;
      PedidoService.actualizarPedido(pedido);
    } else {
      alert('Por favor, ingresa un tiempo estimado válido.');
    }
  };

  // Función para marcar el pedido como preparado
  $scope.actualizarPedido = function(pedido) {
    if (!pedido.tiempoEstimado || pedido.tiempoEstimado <= 0) {
      alert('Debes confirmar el tiempo estimado antes de marcarlo como preparado.');
      return;
    }
    pedido.estado = 'preparado';  // Cambiar el estado del pedido
    PedidoService.actualizarPedido(pedido);  // Actualizar el pedido en el servicio
    // Eliminar el pedido de la lista pendiente si ya está preparado
    $scope.pedidosPendientes = $scope.pedidosPendientes.filter(p => p.id !== pedido.id);
  };

  $scope.logout = function() {
    AuthService.logout();
    $location.path('/');  // Redirige a la página de login
  };
});
