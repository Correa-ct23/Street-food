angular.module('miApp')
.controller('DomiciliarioController', function($scope, PedidoService) {
  // Filtra los pedidos con estado "preparado" para mostrarlos al domiciliario
  $scope.pedidosPreparados = PedidoService.getPedidos().filter(p => p.estado === 'preparado');
  $scope.noHayPedidos = $scope.pedidosPreparados.length === 0;

  // Actualizar el estado cuando cambian los pedidos
  $scope.$watch('pedidosPreparados', function(newVal) {
    $scope.noHayPedidos = newVal.length === 0;
  });

  // Función para llevar el pedido, abre Google Maps con la ubicación del cliente
  $scope.llevarPedido = function(pedido) {
    // Reemplaza 'ubicacion_cliente' por la dirección real del cliente
    const direccionCliente = encodeURIComponent(pedido.direccion); // Suponiendo que la dirección esté guardada en el pedido
    window.open('https://www.google.com/maps?q=' + direccionCliente, '_blank');
    pedido.estado = 'en camino'; // Actualiza el estado del pedido a "en camino"
    PedidoService.actualizarPedido(pedido);
  };

  // Función para entregar el pedido
  $scope.entregarPedido = function(pedido) {
    PedidoService.eliminarPedido(pedido.id);
    $scope.pedidosPreparados = $scope.pedidosPreparados.filter(p => p.id !== pedido.id);
    alert('Pedido entregado exitosamente ✅');
  };

  $scope.logout = function() {
    AuthService.logout();
    $location.path('/');  // Redirige a la página de login
  };
});
