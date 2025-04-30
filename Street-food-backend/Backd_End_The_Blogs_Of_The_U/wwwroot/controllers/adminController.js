angular.module('miApp')
.controller('AdministradorController', function($scope) {
  // Lista inicial de productos (puede estar vacía o con algunos de ejemplo)
  $scope.productos = [
    { id: 1, nombre: 'Pizza', precio: 25000, imagen: 'img/pizza.jpg' },
    { id: 2, nombre: 'Hamburguesa', precio: 18000, imagen: 'img/hamburguesa.jpg' },
    { id: 3, nombre: 'Perro Caliente', precio: 15000, imagen: 'img/perro.jpg' },
    { id: 4, nombre: 'Salchipapas', precio: 12000, imagen: 'img/salchipapa.jpg' },
    { id: 5, nombre: 'Quesadillas', precio: 14000, imagen: 'img/quesadilla.jpg' },
    { id: 6, nombre: 'Alitas', precio: 20000, imagen: 'img/alitas.jpg' }
  ];
  

  $scope.nuevoProducto = []; // Objeto para crear o editar productos
  $scope.editando = false; // Saber si estoy en modo edición

  // Agregar nuevo producto
  $scope.agregarProducto = function() {
    if (!$scope.nuevoProducto.id || !$scope.nuevoProducto.nombre || !$scope.nuevoProducto.precio || !$scope.nuevoProducto.imagen) {
      alert('Por favor completa todos los campos.');
      return;
    }
    else
    {
      $scope.productos.push({
        id: $scope.nuevoProducto.id,
        nombre: $scope.nuevoProducto.nombre,
        precio: $scope.nuevoProducto.precio,
        imagen: $scope.nuevoProducto.imagen,
        });
        $scope.nuevoProducto = {}; // Limpiar el formulario
    }

  };

  // Cargar los datos del producto seleccionado para editar
  $scope.editarProducto = function(producto) {
    //update service
  };

  // Eliminar producto
  $scope.eliminarProducto = function(index) {
    //delete service
  };

    // Función para cerrar sesión
  $scope.logout = function() {
    AuthService.logout();
    $location.path('/'); // Redirige a la pantalla de login
  };
});
