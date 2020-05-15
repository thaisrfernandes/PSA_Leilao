using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TF_PSA.PL;

namespace TF_PSA.BLL.DAOs
{
    public class LanceDAO
    {
        private readonly LeilaoContext _context;

        public LanceDAO()
        {
            _context = new LeilaoContext();
        }

        public LeilaoContext GetContext() => _context;

        public async Task<List<Lance>> ListAll() => await _context.Lances.ToListAsync();
        public async Task Create(Lance NovoLance)
        {
            _context.Add(NovoLance);
            await _context.SaveChangesAsync();
        }

        public async Task<Lance> EditById(int LanceId) => await _context.Lances.FindAsync(LanceId);

        public async Task<Lance> GetLance(int LanceId) => await _context.Lances.FirstOrDefaultAsync(l => l.LanceId == LanceId);

        public async Task DeleteById(int LanceId)
        {
            var Lance = await _context.Lances.FirstOrDefaultAsync(l => l.LanceId == LanceId);
            _context.Lances.Remove(Lance);
            await _context.SaveChangesAsync();
        }
    }
}
