using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Business
{
    public class Profissao
    {
        private readonly ProfissaoDAO _ProfissaoDAO;

        public Profissao()
        {
            _ProfissaoDAO = new ProfissaoDAO();
        }
        public int Id { get; set; }

        public string Descricao { get; set; }

        public List<Profissao> retornaProfissoes()
        {
            List<Profissao> listaProfissoes = new List<Profissao>();
            listaProfissoes = DAOtoBusiness(_ProfissaoDAO.retornaProfissoes());
            return listaProfissoes;
        }


        private Profissao DAOtoBusiness(objProfissao objProfissao)
        {
            Profissao businessProfissao = new Profissao();
            businessProfissao.Id = objProfissao.Id;
            businessProfissao.Descricao = objProfissao.Descricao;
            return businessProfissao;
        }

        private List<Profissao> DAOtoBusiness(List<objProfissao> listaProfissoes)
        {
            List<Profissao> listBusinessProfissoes = new List<Profissao>();
            foreach (objProfissao item in listaProfissoes)
            {
                listBusinessProfissoes.Add(DAOtoBusiness(item));
            }

            return listBusinessProfissoes;
        }
    }
}