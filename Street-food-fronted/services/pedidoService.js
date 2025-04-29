angular.module('miApp')
.factory('PedidoService', function() {
  var pedidos = [];

  return {
    getPedidos: function() {
      return pedidos;
    },
    addPedido: function(pedido) {
      pedidos.push(pedido);
    },
    actualizarPedido: function(pedidoActualizado) {
      for (var i = 0; i < pedidos.length; i++) {
        if (pedidos[i].id === pedidoActualizado.id) {
          pedidos[i] = pedidoActualizado;
        }
      }
    },
    eliminarPedido: function(idPedido) { 
      for (var i = 0; i < pedidos.length; i++) {
        if (pedidos[i].id === idPedido) {
          pedidos.splice(i, 1); // elimina el pedido del array
          break;
        }
      }
    }
  };
});
