using System.Collections.Generic;
using System.Threading.Tasks;
using CursoWebApi.Models;
using CursoWebApi.ViewModel;

namespace CursoWebApi.Repositorio {
    public interface IPostRepositorio {
        Task<List<Categoria>> ObterCategorias ();

        Task<List<PostViewModel>> ObterPosts ();

        Task<PostViewModel> ObterPost (int? postId);

        Task<int> AdicinarPost (Post post);

        Task ExcluirPost (int? postId);

        Task AtualizarPost (Post post);
    }
}