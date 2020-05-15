using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TF_PSA.BLL.DAOs;
using TF_PSA.PL;

namespace TF_PSA.BLL.Facades
{
    public class ItemFacade
    {

        private ItemDAO ItemDAO;

        public ItemFacade()
        {
            ItemDAO = new ItemDAO();
        }

        public Task<List<Item>> ListAllItens() => ItemDAO.ListAll();
        public Task<Item> EditItem(int ItemId) => ItemDAO.EditById(ItemId);
        public Task<Item> GetItem(int ItemId) => ItemDAO.GetItem(ItemId);
        public async Task CreateItem(Item item) => await ItemDAO.Create(item);
        public async Task DeleteItemById(int ItemId) => await ItemDAO.DeleteById(ItemId);
    }
}
