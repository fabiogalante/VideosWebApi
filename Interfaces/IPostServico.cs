using System.Threading.Tasks;
using CursoWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace CursoWebApi.Interfaces
{
    public interface IPostServico
    {
        Task<IActionResult> ObterPosts();
        Task<IActionResult> ObterPost(int? postId);
        Task<IActionResult> ObterPostsPorCategoria(int? categoriaId);
        Task<IActionResult> AdicinarPost(Post post);
        Task<IActionResult> ExcluirPost(int? postId);
        Task<IActionResult> AtualizarPost(Post post);
    }
}
