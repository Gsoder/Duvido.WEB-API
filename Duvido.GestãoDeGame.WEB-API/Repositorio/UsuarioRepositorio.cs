using Duvido.GestãoDeGame.WEB_API.Data;
using Duvido.GestãoDeGame.WEB_API.Models;
using Duvido.GestãoDeGame.WEB_API.Repositorio.Inteface;
using Microsoft.EntityFrameworkCore;

namespace Duvido.GestãoDeGame.WEB_API.Repositorio
{
    public class UsuarioRepositorio : IUsuariosRepositorio
    {
        private readonly AppDbContext _appDbContext;
        public UsuarioRepositorio(AppDbContext appDbContext) {

            _appDbContext = appDbContext;

        }

        public async Task<UsuarioViewModel> Adicionar(UsuarioViewModel usuario)
        {
            await _appDbContext.Usuario.AddAsync(usuario);
            await _appDbContext.SaveChangesAsync();

            return usuario;
        }

        public async Task<bool> Apagar(int id)
        {
            UsuarioViewModel usuarioPorId = await BuscarPorId(id);

            if (usuarioPorId == null)
            {
                throw new Exception($"Usuario não foi encontrado id: {id}");
            }

            _appDbContext.Usuario.Remove(usuarioPorId);
            await _appDbContext.SaveChangesAsync();

            return true;
        }

        public async Task<UsuarioViewModel> Atualizar(UsuarioViewModel usuario, int id)
        {
            UsuarioViewModel usuarioPorId = await BuscarPorId(id);

            if (usuarioPorId == null)
            {
                throw new Exception($"Usuario não foi encontrado id: {id}");
            }

            usuarioPorId.Id = usuario.Id;
            usuarioPorId.Nome = usuario.Nome;
            usuarioPorId.username = usuario.username;
            usuarioPorId.Senha = usuario.Senha;
            usuarioPorId.Email = usuario.Email;
            usuarioPorId.FotoPerfil = usuario.FotoPerfil;


            _appDbContext.Usuario.Update(usuarioPorId);
            await _appDbContext.SaveChangesAsync();

            return usuarioPorId;
        }

        public async Task<UsuarioViewModel> BuscarPorId(int id)
        {
            return await _appDbContext.Usuario.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<UsuarioViewModel>> BuscarTodosUsuarios()
        {
            return await _appDbContext.Usuario.ToListAsync();
        }

        
    }
}
