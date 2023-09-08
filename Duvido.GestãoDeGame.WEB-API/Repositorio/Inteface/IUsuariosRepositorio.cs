using Duvido.GestãoDeGame.WEB_API.Models;

namespace Duvido.GestãoDeGame.WEB_API.Repositorio.Inteface
{
    public interface IUsuariosRepositorio
    {
        Task<List<UsuarioViewModel>> BuscarTodosUsuarios();
        Task<UsuarioViewModel> BuscarPorId(int id);
        Task<UsuarioViewModel> Adicionar(UsuarioViewModel usuario);
        Task<UsuarioViewModel> Atualizar(UsuarioViewModel usuario, int id);
        Task<bool> Apagar(int id);
    }
}
