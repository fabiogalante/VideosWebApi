using System.Threading.Tasks;
using CursoWebApi.Models;
using CursoWebApi.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace CursoWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostRepositorio _repositorio;

        public PostController(IPostRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        [HttpGet]
        [Route("ObterCategorias")]
        public async Task<IActionResult> ObterCategorias()
        {
            var categorias = await _repositorio.ObterCategorias();
            if (categorias == null) return BadRequest();

            return Ok(categorias);
        }

        [HttpGet]
        [Route("ObterPosts")]
        public async Task<IActionResult> ObterPosts()
        {
            var posts = await _repositorio.ObterPosts();
            if (posts == null) return BadRequest();

            return Ok(posts);
        }

        [HttpGet]
        [Route("ObterPost/{postId}")]
        public async Task<IActionResult> ObterPost(int? postId)
        {
            if (postId == null) return NotFound();

            var post = await _repositorio.ObterPost(postId);
            if (post == null) return BadRequest();

            return Ok(post);
        }

        [HttpPost]
        [Route("AdicionarPost")]
        public async Task<IActionResult> AdicionarPost([FromBody] Post model)
        {
            if (model == null)
                return BadRequest();

            var postId = await _repositorio.AdicinarPost(model);

            if (postId > 0)
                return Ok(postId);

            return StatusCode(500, "Erro ao incluir o post");
        }

        [HttpDelete("{postId}/ExcluirPost")]
        public async Task<IActionResult> Excluir(int? postId)
        {
            if (postId == null)
                return NotFound();

            await _repositorio.ExcluirPost(postId);

            return NoContent();
        }

        [HttpPut]
        [Route("AtualizarPost")]
        public async Task<IActionResult> AtualizarPost([FromBody] Post model)
        {
            //if(model == null)
            //    return BadRequest();

            //Api Controller valida

            await _repositorio.AtualizarPost(model);
            return Ok();

            
        }
    }
}