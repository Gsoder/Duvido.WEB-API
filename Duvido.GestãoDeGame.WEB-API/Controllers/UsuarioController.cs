using Duvido.GestãoDeGame.WEB_API.Data;
using Duvido.GestãoDeGame.WEB_API.Models;
using Duvido.GestãoDeGame.WEB_API.Repositorio;
using Duvido.GestãoDeGame.WEB_API.Repositorio.Inteface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Duvido.GestãoDeGame.WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuariosRepositorio _usuariosRepositorio;
        private readonly AppDbContext _dbContext;

        public UsuarioController(IUsuariosRepositorio usuariosRepositorio, AppDbContext dbContext)
        {
            _usuariosRepositorio = usuariosRepositorio;
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<UsuarioViewModel>>> BuscarTodosUsuarios()
        {

            List<UsuarioViewModel> listas = await _usuariosRepositorio.BuscarTodosUsuarios();


            return Ok(listas);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioViewModel>> BuscarPorId(int id)
        {

            UsuarioViewModel listas = await _usuariosRepositorio.BuscarPorId(id);



            return Ok(listas);
        }




        [HttpPost]
        public async Task<ActionResult<UsuarioViewModel>> Cadastrar([FromBody] UsuarioViewModel UsuarioViewModel)
        {
            UsuarioViewModel lista = await _usuariosRepositorio.Adicionar(UsuarioViewModel);

            return Ok(lista);
        }



        [HttpPut("{id}")]
        public async Task<ActionResult<UsuarioViewModel>> Atualizar([FromBody] UsuarioViewModel listaModel, int id)
        {
            listaModel.Id = id;
            UsuarioViewModel lista = await _usuariosRepositorio.Atualizar(listaModel, id);

            return Ok(lista);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UsuarioViewModel>> Apagar(int id)
        {

            bool lista = await _usuariosRepositorio.Apagar(id);

            return Ok(lista);
        }
    }
}
