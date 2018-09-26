using System.Threading.Tasks;
using CursoWebApi.Models;
using CursoWebApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CursoWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostServico _postServico;

        public PostController(IPostServico postServico)
        {
            _postServico = postServico;
        }

       

        [HttpGet]
        [Route("ObterPosts")]
        public async Task<IActionResult> ObterPosts()
        {
            return await _postServico.ObterPosts();
        }

        [HttpGet]
        [Route("{categoriaId}/ObterPostsPorCategoria")]
        public async Task<IActionResult> ObterPostsPorCategoria(int? categoriaId)
        {
            return await _postServico.ObterPostsPorCategoria(categoriaId);
        }

        [HttpGet]
        [Route("ObterPost/{postId}")]
        public async Task<IActionResult> ObterPost(int postId)
        {
            return await _postServico.ObterPost(postId);
        }

        [HttpPost]
        [Route("AdicionarPost")]
        public async Task<IActionResult> AdicionarPost([FromBody] Post post)
        {
            return await _postServico.AdicinarPost(post);
        }

        [HttpDelete("{postId}/ExcluirPost")]
        public async Task<IActionResult> Excluir(int postId)
        {
            return await _postServico.ExcluirPost(postId);
        }

        [HttpPut]
        [Route("AtualizarPost")]
        public async Task<IActionResult> AtualizarPost([FromBody] Post model)
        {
            //if(model == null)
            //    return BadRequest();

            //Api Controller valida

            return await _postServico.AtualizarPost(model);
            
        }
    }
}