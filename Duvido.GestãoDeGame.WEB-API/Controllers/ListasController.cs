using Duvido.GestãoDeGame.WEB_API.Data;
using Duvido.GestãoDeGame.WEB_API.Models;
using Duvido.GestãoDeGame.WEB_API.Repositorio;
using Duvido.GestãoDeGame.WEB_API.Repositorio.Inteface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Duvido.GestãoDeGame.WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListasController : ControllerBase
    {
        public readonly IItensDaListaRepositorio _itensDaListaRepositorio;
        private readonly IListaRepositorio _listaRepositorio;
        private readonly AppDbContext _dbContext;

        public ListasController(IItensDaListaRepositorio itensDaListaRepositorio, IListaRepositorio listaRepositorio, AppDbContext dbContext)
        {
            _itensDaListaRepositorio = itensDaListaRepositorio;
            _listaRepositorio = listaRepositorio;
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<ListaViewModel>>> BuscarTodasListas(){

            List<ListaViewModel> listas = await _listaRepositorio.BuscarTodasListas();


            return Ok(listas);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ListaViewModel>> BuscarPorId(int id)
        {

            ListaViewModel listas = await _listaRepositorio.BuscarPorId(id);

            

            return Ok(listas);
        }

        


        [HttpPost]
        public async Task<ActionResult<ListaViewModel>> Cadastrar([FromBody] ListaViewModel ListaViewModel)
        {
            ListaViewModel lista = await _listaRepositorio.Adicionar(ListaViewModel);

            return Ok(lista);
        }



        [HttpPut("{id}")]
        public async Task<ActionResult<ListaViewModel>> Atualizar([FromBody] ListaViewModel listaModel, int id)
        {
            listaModel.ID = id;
            ListaViewModel lista = await _listaRepositorio.Atualizar(listaModel, id);

            return Ok(lista);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ListaViewModel>> Apagar(int id)
        {

            bool lista = await _listaRepositorio.Apagar(id);

            return Ok(lista);
        }
    }
}
