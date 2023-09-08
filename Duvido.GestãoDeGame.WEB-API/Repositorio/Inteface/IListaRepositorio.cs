using Duvido.GestãoDeGame.WEB_API.Models;

namespace Duvido.GestãoDeGame.WEB_API.Repositorio.Inteface
{
    public interface IListaRepositorio
    {
        Task<List<ListaViewModel>> BuscarTodasListas();
        Task<ListaViewModel> BuscarPorId(int id);
        Task<ListaViewModel> Adicionar(ListaViewModel lista);
        Task<ListaViewModel> Atualizar(ListaViewModel lista, int id);
        Task<bool> Apagar(int id);
    }
}
