using Duvido.GestãoDeGame.WEB_API.Data;
using Duvido.GestãoDeGame.WEB_API.Models;
using Duvido.GestãoDeGame.WEB_API.Repositorio.Inteface;
using Microsoft.EntityFrameworkCore;

namespace Duvido.GestãoDeGame.WEB_API.Repositorio
{
    public class ListaRepositorio : IListaRepositorio
    {
        private readonly AppDbContext _appDbContext;
        public ListaRepositorio(AppDbContext appDbContext) {

            _appDbContext = appDbContext;

        }

        public async Task<ListaViewModel> Adicionar(ListaViewModel lista)
        {
            await _appDbContext.Lista.AddAsync(lista);
            await _appDbContext.SaveChangesAsync();

            return lista;
        }

        public async Task<bool> Apagar(int id)
        {
            ListaViewModel listaPorId = await BuscarPorId(id);

            if (listaPorId == null)
            {
                throw new Exception($"lista não foi encontrado id: {id}");
            }

            _appDbContext.Lista.Remove(listaPorId);
            await _appDbContext.SaveChangesAsync();

            return true;
        }

        public async Task<ListaViewModel> Atualizar(ListaViewModel lista, int id)
        {
            ListaViewModel listaPorId = await BuscarPorId(id);

            if (listaPorId == null)
            {
                throw new Exception($"lista não foi encontrado id: {id}");
            }

            listaPorId.ID = lista.ID;
            listaPorId.NomeDaLista = lista.NomeDaLista;
            listaPorId.Categoria = lista.Categoria;
            listaPorId.ItensDaLista = lista.ItensDaLista;


            _appDbContext.Lista.Update(listaPorId);
            await _appDbContext.SaveChangesAsync();

            return listaPorId;
        }

        public async Task<ListaViewModel> BuscarPorId(int id)
        {
            return await _appDbContext.Lista
                .Include(x => x.ItensDaLista)
                .FirstOrDefaultAsync(x => x.ID == id);
        }

        public async Task<List<ListaViewModel>> BuscarTodasListas()
        {
            return await _appDbContext.Lista.Include(x => x.ItensDaLista).ToListAsync();
        }

        
    }
}
