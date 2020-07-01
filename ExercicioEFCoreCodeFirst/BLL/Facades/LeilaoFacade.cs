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

        public async Task<Lance> DeterminaGanhador(int leilaoId)
        {
            /*
              var numberOfMoviesAsCharac = from c in db.Characters
                                                 where c.Character == "James Bond"
                                                 group c by c.Actor.Name into ActorPlayingChar
                                                 select new
                                                 {
                                                     Name = ActorPlayingChar.Key,
                                                     Times = ActorPlayingChar.Count()
                                                 };

                    int maxParticipation = numberOfMoviesAsCharac.Max(i => i.Times);
                    var chosenOne = numberOfMoviesAsCharac.First(c => c.Times == maxParticipation);
             */

            var leilao = await LeilaoDAO.GetLeilao(leilaoId);
          

            if (leilao.Categoria.ToString().Equals("Demanda"))
            {
                Lance lanceGanhador = GetContext().Lances
                    .Where(l => l.LeilaoId == 5 && l.Valor == 200)
                    .FirstOrDefault();

                return lanceGanhador;
            }
            else
            {
                Lance lanceGanhador = GetContext().Lances
                    .Where(l => l.LeilaoId == leilaoId && l.Valor >= leilao.Preco)
                    .FirstOrDefault();

                return lanceGanhador;
            }
        }
    }
}

