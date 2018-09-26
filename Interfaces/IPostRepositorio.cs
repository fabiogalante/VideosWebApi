using System.Collections.Generic;
using System.Threading.Tasks;
using CursoWebApi.Models;

namespace CursoWebApi.Interfaces
{
    public interface IPostRepositorio
    {


        Task<IEnumerable<Post>> ObterPosts();
        Task<IEnumerable<Post>> ObterPostsPorCategoria(int? categoriaId);
        Task<Post> ObterPost (int? postId);
        Task<int> AdicinarPost (Post post);
        Task<Post> ExcluirPost (int? postId);
        Task AtualizarPost (Post post);
        Task Salvar();
    }
}