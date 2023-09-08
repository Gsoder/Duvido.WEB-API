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
    public class ItensDasListasController : ControllerBase
    {
        public readonly IItensDaListaRepositorio _itensDaListaRepositorio;
        private readonly IListaRepositorio _listaRepositorio;

        public ItensDasListasController(IItensDaListaRepositorio itensDaListaRepositorio, IListaRepositorio listaRepositorio)
        {
            _itensDaListaRepositorio = itensDaListaRepositorio;
            _listaRepositorio = listaRepositorio;
        }

       

        [HttpGet]
        public async Task<ActionResult<List<ItensDaListaViewModel>>> BuscarTodasListas(){

            List<ItensDaListaViewModel> listas = await _itensDaListaRepositorio.BuscarTodosItens();

            return Ok(listas);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ItensDaListaViewModel>> BuscarPorId(int id)
        {

            ItensDaListaViewModel listas = await _itensDaListaRepositorio.BuscarPorId(id);

            return Ok(listas);
        }

        [HttpPost]
        public async Task<ActionResult<ItensDaListaViewModel>> Cadastrar([FromBody] ItensDaListaViewModel ItensDaListaViewModel)
        {
            ItensDaListaViewModel lista = await _itensDaListaRepositorio.Adicionar(ItensDaListaViewModel);

            return Ok(lista);
        }



        [HttpPut("{id}")]
        public async Task<ActionResult<ItensDaListaViewModel>> Atualizar([FromBody] ItensDaListaViewModel listaModel, int id)
        {
            listaModel.ID = id;
            ItensDaListaViewModel lista = await _itensDaListaRepositorio.Atualizar(listaModel, id);

            return Ok(lista);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ItensDaListaViewModel>> Apagar(int id)
        {

            bool lista = await _itensDaListaRepositorio.Apagar(id);

            return Ok(lista);
        }


    }
}
