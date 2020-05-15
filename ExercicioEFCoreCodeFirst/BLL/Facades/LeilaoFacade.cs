using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TF_PSA.BLL.DAOs;
using TF_PSA.PL;

namespace TF_PSA.BLL.Facades
{
    public class LeilaoFacade
    {
        private LeilaoDAO LeilaoDAO;

        public LeilaoFacade()
        {
            LeilaoDAO = new LeilaoDAO();
        }

        public Task<List<Leilao>> ListAllLeiloes() => LeilaoDAO.ListAll();
        public Task<Leilao> EditLeilao(int LeilaoId) => LeilaoDAO.EditById(LeilaoId);
        public Task<Leilao> GetLeilao(int LeilaoId) => LeilaoDAO.GetLeilao(LeilaoId);
        public async Task CreateLeilao(Leilao NovoLeilao) => await LeilaoDAO.Create(NovoLeilao);
        public async Task DeleteLeilaoById(int LeilaoId) => await LeilaoDAO.DeleteById(LeilaoId);

    }
}

