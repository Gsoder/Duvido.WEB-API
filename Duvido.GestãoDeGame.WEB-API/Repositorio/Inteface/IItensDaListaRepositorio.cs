using Duvido.GestãoDeGame.WEB_API.Models;

namespace Duvido.GestãoDeGame.WEB_API.Repositorio.Inteface
{
    public interface IItensDaListaRepositorio
    {
        Task<List<ItensDaListaViewModel>> BuscarTodosItens();
        Task<ItensDaListaViewModel> BuscarPorId(int id);
        Task<ItensDaListaViewModel> Adicionar(ItensDaListaViewModel ItensLista);
        Task<ItensDaListaViewModel> Atualizar(ItensDaListaViewModel lista, int id);
        Task<bool> Apagar(int id);
    }
}
