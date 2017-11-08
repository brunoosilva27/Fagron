using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Business
{
    public class Cliente
    {
        private readonly ClienteDAO _ClienteDAO;

        public Cliente()
        {
            _ClienteDAO = new ClienteDAO();
        }
        public int Id { get; set; }

        public string Nome { get; set; }

        public string SobreNome { get; set; }

        public int Idade { get; set; }

        public DateTime DataNascimento { get; set; }

        public int ProfissaoId { get; set; }

        public List<Cliente> retornaClientes()
        {
            List<Cliente> listaClientes = new List<Cliente>();
            listaClientes = DAOtoBusiness(_ClienteDAO.retornaClientes());
            return listaClientes;
        }

        public void insereCliente(string Nome,string Sobrenome,DateTime dataNascimento,int ProfissaoId)
        {
            objCliente objCliente = new objCliente();
            objCliente.Nome = Nome;
            objCliente.SobreNome = Sobrenome;
            objCliente.DataNascimento = dataNascimento;
            objCliente.ProfissaoId = ProfissaoId;
            objCliente.Idade = (DateTime.Now.Year - dataNascimento.Year);
            _ClienteDAO.insereCliente(objCliente);
        }

        public Cliente buscaCliente(int Cliente)
        {
            Cliente cliente = new Cliente();
            cliente = DAOtoBusiness(_ClienteDAO.buscaClientes(Cliente));
            return cliente;
        }

        public void deleteCliente(int idCliente)
        {
            _ClienteDAO.deletaCliente(idCliente);
        }

        private Cliente DAOtoBusiness(objCliente objCliente)
        {
            Cliente businessCliente = new Cliente();
            businessCliente.Id = objCliente.Id;
            businessCliente.Nome = objCliente.Nome;
            businessCliente.SobreNome = objCliente.SobreNome;
            businessCliente.Idade = objCliente.Idade;
            businessCliente.DataNascimento = objCliente.DataNascimento;
            businessCliente.ProfissaoId = objCliente.ProfissaoId;
            return businessCliente;
        }

        private List<Cliente> DAOtoBusiness(List<objCliente> listaClientes)
        {
            List<Cliente> listBusinessClientes = new List<Cliente>();
            foreach (objCliente item in listaClientes)
            {
                listBusinessClientes.Add(DAOtoBusiness(item));
            }

            return listBusinessClientes;
        }

    }
}