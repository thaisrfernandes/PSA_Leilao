using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TF_PSA.PL;

namespace TF_PSA.BLL.DAOs
{
    public class ItemDAO
    {
        private readonly LeilaoContext _context;

        public ItemDAO()
        {
            _context = new LeilaoContext();
        }

        public LeilaoContext GetContext()
        {
            return _context;
        }

        public async Task<List<Item>> ListAll() => await _context.Itens.ToListAsync();
        public async Task Create(Item novoItem)
        {
            _context.Add(novoItem);
            await _context.SaveChangesAsync();
        }

        public async Task<Item> EditById(int ItemId) => await _context.Itens.FindAsync(ItemId);

        public async Task<Item> GetItem(int ItemId) => await _context.Itens.FirstOrDefaultAsync(i => i.ItemId == ItemId);

        public async Task DeleteById(int ItemId)
        {
            var item = await _context.Itens.FirstOrDefaultAsync(i => i.ItemId == ItemId);
            _context.Itens.Remove(item);
            await _context.SaveChangesAsync();
        }
    }
}
