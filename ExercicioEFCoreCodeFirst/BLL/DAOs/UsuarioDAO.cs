using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Text;
using TF_PSA.PL;
using System.Threading.Tasks;


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

        public async Task<Usuario> EditById(String Email) => await _context.Usuarios.FindAsync(Email);

        public async Task<Usuario> GetUsuario(String Email) => await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == Email);
        
        public async Task DeleteById(String Email)
        {
            var Usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == Email);
            _context.Usuarios.Remove(Usuario);
            await _context.SaveChangesAsync();
        }
    }   
}
