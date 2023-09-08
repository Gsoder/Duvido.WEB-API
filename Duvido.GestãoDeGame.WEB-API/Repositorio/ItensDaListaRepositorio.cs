using Duvido.GestãoDeGame.WEB_API.Data;
using Duvido.GestãoDeGame.WEB_API.Models;
using Duvido.GestãoDeGame.WEB_API.Repositorio.Inteface;
using Microsoft.EntityFrameworkCore;

namespace Duvido.GestãoDeGame.WEB_API.Repositorio
{
    public class ItensDaListaRepositorio : IItensDaListaRepositorio
    {
        private readonly AppDbContext _appDbContext;
        public ItensDaListaRepositorio(AppDbContext appDbContext) {

            _appDbContext = appDbContext;

        }

        public async Task<ItensDaListaViewModel> Adicionar(ItensDaListaViewModel ItensLista)
        {
            await _appDbContext.ItensDaLista.AddAsync(ItensLista);
            await _appDbContext.SaveChangesAsync();

            return ItensLista;
        }

        public async Task<bool> Apagar(int id)
        {
            ItensDaListaViewModel listaPorId = await BuscarPorId(id);

            if (listaPorId == null)
            {
                throw new Exception($"lista não foi encontrado id: {id}");
            }

            _appDbContext.ItensDaLista.Remove(listaPorId);
            await _appDbContext.SaveChangesAsync();

            return true;
        }

        public async Task<ItensDaListaViewModel> Atualizar(ItensDaListaViewModel ItensLista, int id)
        {
            ItensDaListaViewModel listaPorId = await BuscarPorId(id);

            if (listaPorId == null)
            {
                throw new Exception($"lista não foi encontrado id: {id}");
            }

            listaPorId.ID = ItensLista.ID;
            listaPorId.IDDaLista = ItensLista.IDDaLista;
            listaPorId.Posicao = ItensLista.Posicao;
            listaPorId.NomeDoItem = ItensLista.NomeDoItem;


            _appDbContext.ItensDaLista.Update(listaPorId);
            await _appDbContext.SaveChangesAsync();

            return listaPorId;
        }

        public async Task<ItensDaListaViewModel> BuscarPorId(int id)
        {
            return await _appDbContext.ItensDaLista.FirstOrDefaultAsync(x => x.ID == id);
        }

        public async Task<List<ItensDaListaViewModel>> BuscarTodosItens()
        {
            return await _appDbContext.ItensDaLista.ToListAsync();
        }
    }
}
