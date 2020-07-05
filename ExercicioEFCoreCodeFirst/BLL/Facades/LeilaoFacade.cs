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
        public async Task<Leilao> EditLeilao(int? LeilaoId) => await LeilaoDAO.EditById(LeilaoId);
        public async Task<Leilao> GetLeilao(int? LeilaoId) => await LeilaoDAO.GetLeilao(LeilaoId);
        public async Task CreateLeilao(Leilao NovoLeilao) => await LeilaoDAO.Create(NovoLeilao);
        public async Task DeleteLeilaoById(int LeilaoId) => await LeilaoDAO.DeleteById(LeilaoId);
        public async Task UpdateLeilao(Leilao leilao) => await LeilaoDAO.UpdateLeilao(leilao);
        public bool LeilaoExits(int id) => LeilaoDAO.LeilaoExits(id);
        public async Task PutLeilao(Leilao leilao) => await LeilaoDAO.PutLeilao(leilao);

        public async Task<IEnumerable<Item>> GetLeilaoItems(int leilaoId) {

            IEnumerable<Item> itens = await new ItemFacade().ListAllItens();
            return itens.Where(i => i.LeilaoId == leilaoId);

        }

        public async Task<IEnumerable<Lance>> GetLeilaoLances(int leilaoId)
        {
            IEnumerable<Lance> lances = await new LanceFacade().ListAllLances();
            return lances.Where(l => l.LeilaoId == leilaoId);
        }

        public async Task<Lance> DeterminaGanhador(Leilao leilao)
        {
            
            List<Lance> lances = await new LanceFacade().ListAllLances();

            if (TipoLeilao.Demanda == leilao.Categoria)
            {

                Console.WriteLine("leilao de demanda");
                Lance lanceGanhador = lances
                    .OrderByDescending(l => l.Valor)
                    .Where(l => l.LeilaoId == leilao.LeilaoId)
                    .Where(l => l.Valor > leilao.Preco)
                    .FirstOrDefault();

                return lanceGanhador;
            }
            else
            {
                Console.WriteLine("leilao de oferta");
                Lance lanceGanhador = lances
                    .OrderBy(l => l.Valor)
                    .Where(l => l.LeilaoId == leilao.LeilaoId)
                    .Where(l => l.Valor < leilao.Preco)
                    .FirstOrDefault();

                return lanceGanhador;
            }
        }
    }
}

