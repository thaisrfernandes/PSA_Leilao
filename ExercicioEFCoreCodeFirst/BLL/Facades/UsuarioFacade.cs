using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TF_PSA.BLL.DAOs;
using TF_PSA.PL;

namespace TF_PSA.BLL.Facades
{
    public class UsuarioFacade
    {
        private UsuarioDAO UsuarioDAO;

        public UsuarioFacade()
        {
            UsuarioDAO = new UsuarioDAO();
        }

        public Task<List<Usuario>> ListAllUsuarios() => UsuarioDAO.ListAll();
        public Task<Usuario> EditUsuario(String Email) => UsuarioDAO.EditById(Email);
        public Task<Usuario> GetUsuario(String Email) => UsuarioDAO.GetUsuario(Email);
        public async Task CreateUsuario(Usuario NovoUsuario) => await UsuarioDAO.Create(NovoUsuario);
        public async Task DeleteUsuarioById(String Email) => await UsuarioDAO.DeleteById(Email);
    }
}
