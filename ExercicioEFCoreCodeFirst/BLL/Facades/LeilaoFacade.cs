using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public LeilaoContext GetContext() => LeilaoDAO.GetContext();
        public Task<List<Leilao>> ListAllLeiloes() => LeilaoDAO.ListAll();
        public Task<Leilao> EditLeilao(int? LeilaoId) => LeilaoDAO.EditById(LeilaoId);
        public Task<Leilao> GetLeilao(int? LeilaoId) => LeilaoDAO.GetLeilao(LeilaoId);
        public async Task CreateLeilao(Leilao NovoLeilao) => await LeilaoDAO.Create(NovoLeilao);
        public async Task DeleteLeilaoById(int LeilaoId) => await LeilaoDAO.DeleteById(LeilaoId);
        public async Task UpdateLeilao(Leilao leilao) => await LeilaoDAO.UpdateLeilao(leilao);
        public bool LeilaoExits(int id) => LeilaoDAO.LeilaoExits(id);

        public async Task<Lance> DeterminaGanhador(Leilao leilao)
        {
            if (leilao.Categoria.ToString().Equals("Demanda"))
            {
                Lance lanceGanhador = GetContext().Lances                    
                    .Where(l => l.Valor > leilao.Preco)
                    .Where(l => l.Valor == leilao.Lances.Max<Lance>(z => z.Valor))
                    .FirstOrDefault();

                return lanceGanhador;
            }
            else
            {
                Lance lanceGanhador = GetContext().Lances
                    .Where(l => l.Valor > leilao.Preco)
                    .Where(l => l.Valor == leilao.Lances.Max<Lance>(z => z.Valor))
                    .FirstOrDefault();

                return lanceGanhador;
            }
        }
    }
}

