angular
      .module('ClientesApp')
      .controller('clientesController', function ($scope, $http, $window) {
          $http({
              method: 'GET',
              url: 'http://localhost:49627/ClientesService.asmx/getClientes',
              dataType: 'jsonp'
          })
          .then(function (response) {
              $scope.clientes = response.data;
          });

          $scope.inserirCliente = function () {
              $http({
                  method: 'GET',
                  url: 'http://localhost:49627/ClientesService.asmx/insertCliente',
                  params: { 'Nome': $scope.Nome, 'Sobrenome': $scope.Sobrenome, 'dataNascimento': $scope.dataNascimento, 'ProfissaoId': 1 }
              })
              .then(function () {
                  $window.alert('Inserido com sucesso');
                  $window.location.href='/ListaCliente.html'
              });
          }

          $scope.editaCliente = function (idCliente) {
              $http({
                  method: 'GET',
                  url: 'http://localhost:49627/ClientesService.asmx/buscaCliente',
                  params: { 'idCliente': idCliente }
              })
          .then(function (response) {
              $scope.clientes = response.data;
          });
          }

          $scope.deletaCliente = function (idCliente) {
              $http({
                  method: 'GET',
                  url: 'http://localhost:49627/ClientesService.asmx/deleteCliente',
                  params: { 'idCliente': idCliente }
              })
              .then(function () {
                  $scope.validacao = 'true';
                  $window.alert('Deletado com sucesso');
                  $window.location.href = '/ListaCliente.html'
              });
          }
      });
angular
      .module('ClientesApp')
      .controller('profissaoController', function ($scope, $http) {
          $http({
              method: 'GET',
              url: 'http://localhost:49627/ClientesService.asmx/getProfissoes',
              dataType: 'jsonp'
          })
          .then(function (response) {
              $scope.profissoes = response.data;
          });
      });

