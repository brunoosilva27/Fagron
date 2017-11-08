using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;


namespace Business
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class ClientesService : System.Web.Services.WebService
    {
        private readonly Cliente _ClienteBusiness;
        private readonly Profissao _ProfissaoBusiness;

        public ClientesService()
        {
            _ClienteBusiness = new Cliente();
            _ProfissaoBusiness = new Profissao();
        }

        [WebMethod]
        public void getClientes()
        {
            List<Cliente> listaClientes = new List<Cliente>();
            listaClientes = _ClienteBusiness.retornaClientes();

            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(listaClientes));
        }

        [WebMethod]
        public void buscaCliente(int idCliente)
        {
            Cliente clientes = new Cliente();
            clientes = _ClienteBusiness.buscaCliente(idCliente);

            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(clientes));
        }

        [WebMethod]
        public void getProfissoes()
        {
            List<Profissao> listaProfissoes = new List<Profissao>();
            listaProfissoes = _ProfissaoBusiness.retornaProfissoes();

            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(listaProfissoes));
        }

        [WebMethod]
        public void insertCliente(string Nome,string Sobrenome,DateTime dataNascimento, int ProfissaoId)
        {
            _ClienteBusiness.insereCliente(Nome, Sobrenome, dataNascimento, ProfissaoId);
        }

        [WebMethod]
        public void deleteCliente(int idCliente)
        {
            _ClienteBusiness.deleteCliente(idCliente);
        }

    }
}
