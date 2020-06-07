using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TF_PSA.PL;

namespace TF_PSA.BLL.DAOs
{
    public class LeilaoDAO
    {
        private readonly LeilaoContext _context;

        public LeilaoDAO()
        {
            _context = new LeilaoContext();
        }

        public LeilaoContext GetContext() => _context;

        public async Task<List<Leilao>> ListAll() => await _context.Leiloes.ToListAsync();
        public async Task Create(Leilao NovoLeilao)
        {
            _context.Add(NovoLeilao);
            await _context.SaveChangesAsync();
        }

        public async Task<Leilao> EditById(int? LeilaoId) => await _context.Leiloes.FindAsync(LeilaoId);

        public async Task<Leilao> GetLeilao(int? LeilaoId) => await _context.Leiloes.FirstOrDefaultAsync(l => l.LeilaoId == LeilaoId);

        public async Task DeleteById(int LeilaoId)
        {
            var leilao = await _context.Leiloes.FirstOrDefaultAsync(l => l.LeilaoId == LeilaoId);
            _context.Leiloes.Remove(leilao);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateLeilao(Leilao leilao)
        {
            _context.Update(leilao);
            await _context.SaveChangesAsync();
        }
        public bool LeilaoExits(int id) => _context.Leiloes.Any(e => e.LeilaoId == id);
    }
}
