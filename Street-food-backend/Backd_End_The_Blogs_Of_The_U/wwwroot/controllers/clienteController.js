angular.module('miApp')
.controller('ClienteController', function($scope, PedidoService, $location, AuthService) {
  $scope.productos = [
    { nombre: 'Pizza', precio: 25000, imagen: 'img/pizza.jpg' },
    { nombre: 'Hamburguesa', precio: 18000, imagen: 'img/hamburguesa.jpg' },
    { nombre: 'Perro Caliente', precio: 15000, imagen: 'img/perro.jpg' },
    { nombre: 'Salchipapas', precio: 12000, imagen: 'img/salchipapa.jpg' },
    { nombre: 'Quesadillas', precio: 14000, imagen: 'img/quesadilla.jpg' },
    { nombre: 'Alitas', precio: 20000, imagen: 'img/alitas.jpg' }
  ];

  $scope.carrito = [];
  $scope.metodoPago = 'Efectivo';
  $scope.pedidos=PedidoService.getPedidos();
  $scope.pedidosPendientes = [];

  // Función para agregar productos al carrito
  $scope.agregarAlCarrito = function(producto) {
    // Buscar si el producto ya existe en el carrito
    const index = $scope.carrito.findIndex(item => item.nombre === producto.nombre);
    if (index === -1) {
      // Si no existe, agregarlo con cantidad 1
      $scope.carrito.push({ ...producto, cantidad: 1 });
    } else {
      // Si ya existe, incrementar la cantidad
      $scope.carrito[index].cantidad++;
    }
  };

  // Función para eliminar productos del carrito
  $scope.eliminarDelCarrito = function(producto) {
    const index = $scope.carrito.indexOf(producto);
    if (index > -1) {
      if ($scope.carrito[index].cantidad > 1) {
        // Decrementa la cantidad si hay más de uno
        $scope.carrito[index].cantidad--;
      } else {
        // Elimina el producto si su cantidad es 1
        $scope.carrito.splice(index, 1);
      }
    }
  };

  // Función para obtener el total del carrito, considerando la cantidad
  $scope.obtenerTotal = function() {
    return $scope.carrito.reduce((total, item) => total + (item.precio * item.cantidad), 0);
  };

  // Función para pagar el pedido
  $scope.pagar = function() {
    if ($scope.carrito.length === 0) {
      alert('Tu carrito está vacío.');
      return;
    }

    // Proceso de pago
    if ($scope.metodoPago === 'PSE') {
      window.open('https://pasarela-pagos.com', '_blank'); // ejemplo de pasarela de pagos
    } else {
      alert('Pago en efectivo confirmado');
    }

    var usuarioActual = AuthService.getUsuario();

    // Crear el nuevo pedido
    var nuevoPedido = {
      id: Date.now(), // ID único basado en la fecha
      productos: angular.copy($scope.carrito), // Copiar el carrito para enviarlo
      metodoPago: $scope.metodoPago,
      estado: 'pendiente', // Estado del pedido
      tiempoEstimado: null, // Inicialmente no se tiene un tiempo estimado
      direccion: usuarioActual.direccion
    };

    PedidoService.addPedido(nuevoPedido);
    // Vaciar el carrito y resetear el método de pago
    $scope.restablecerValores();
  };

  $scope.restablecerValores = function() {
    $scope.carrito = [];
    $scope.metodoPago = 'Efectivo';
    $scope.pagoRealizado = true;
  };

  $scope.obtenerTiempoEstimado = function() {
    // Aquí no es necesario obtener el tiempo estimado globalmente, ya que se maneja por pedido
    $scope.pedidosPendientes = PedidoService.getPedidos();
  };

  $scope.obtenerTiempoEstimado();

  // Función para cerrar sesión
  $scope.logout = function() {
    AuthService.logout();
    $location.path('/'); // Redirige a la pantalla de login
  };
});
