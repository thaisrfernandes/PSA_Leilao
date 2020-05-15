using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TF_PSA.BLL.DAOs;
using TF_PSA.PL;

namespace TF_PSA.BLL.Facades
{
    public class LanceFacade
    {

        private LanceDAO LanceDAO;

        public LanceFacade()
        {
            LanceDAO = new LanceDAO();
        }

        public Task<List<Lance>> ListAllLances() => LanceDAO.ListAll();
        public Task<Lance> EditLance(int LanceId) => LanceDAO.EditById(LanceId);
        public Task<Lance> GetLance(int LanceId) => LanceDAO.GetLance(LanceId);
        public async Task CreateLance(Lance NovoLance) => await LanceDAO.Create(NovoLance);
        public async Task DeleteLanceById(int LanceId) => await LanceDAO.DeleteById(LanceId);

    }
}
