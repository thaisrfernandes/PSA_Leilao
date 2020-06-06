using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Text;
using TF_PSA.PL;
using System.Threading.Tasks;
using System.Linq;

namespace TF_PSA.BLL.DAOs
{
    public class UsuarioDAO
    {
        private readonly LeilaoContext _context;

        public UsuarioDAO()
        {
            _context = new LeilaoContext();
        }

        public LeilaoContext GetContext()
        {
            return _context;
        }

        public async Task<List<Usuario>> ListAll() => await _context.Usuarios.ToListAsync();
        public async Task Create(Usuario NovoUsuario)
        {
            _context.Add(NovoUsuario);
            await _context.SaveChangesAsync();
        }

        public async Task<Usuario> EditById(String id) => await _context.Usuarios.FindAsync(id);

        public async Task<Usuario> GetUsuario(String id) => await _context.Usuarios.FirstOrDefaultAsync(u => u.UsuarioId.Equals(id));
        
        public async Task DeleteById(String Email)
        {
            var Usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == Email);
            _context.Usuarios.Remove(Usuario);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUsuario(Usuario usuario)
        {
            _context.Update(usuario);
            await _context.SaveChangesAsync();
        }

        public bool UsuarioExits(string id) => _context.Usuarios.Any(e => e.UsuarioId.Equals(id));
    }   
}
