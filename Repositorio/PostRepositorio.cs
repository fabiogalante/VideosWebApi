using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CursoWebApi.Data;
using CursoWebApi.Models;
using CursoWebApi.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace CursoWebApi.Repositorio {
    public class PostRepositorio : IPostRepositorio {
        private readonly BlogDbContext _context;

        public PostRepositorio (BlogDbContext context) {
            _context = context;
        }

        public async Task<int> AdicinarPost (Post post) {

            await _context.Post.AddAsync (post);
            await Salvar ();
            return post.PostId;
        }

        public async Task AtualizarPost (Post post) {

            _context.Update(post);
            await Salvar();
        }

        public async Task ExcluirPost (int? postId) {

            var post = await _context.Post.FirstOrDefaultAsync (x => x.PostId == postId);

            if (post != null) {
                _context.Post.Remove (post);
                await Salvar ();
            }
        }

        public async Task<List<Categoria>> ObterCategorias () {
            return await _context.Categoria.ToListAsync ();
        }

        public async Task<PostViewModel> ObterPost (int? postId) {

            return await (from p in _context.Post from c in _context.Categoria where p.PostId == postId select new PostViewModel {
                PostId = p.PostId,
                    Titulo = p.Titulo,
                    Descricao = p.Descricao,
                    CategoriaId = p.CategoriaId,
                    CategoriaNome = c.Nome,
                    DataCriacao = p.DataCriacao
            }).FirstOrDefaultAsync ();
        }

        public async Task<List<PostViewModel>> ObterPosts () {

            return await (from p in _context.Post join c in 
            _context.Categoria on p.CategoriaId equals c.Id 
            select new PostViewModel {
                PostId = p.PostId,
                    Titulo = p.Titulo,
                    Descricao = p.Descricao,
                    CategoriaId = p.CategoriaId,
                    CategoriaNome = c.Nome,
                    DataCriacao = p.DataCriacao
            }).ToListAsync ();
        }

        public async Task Salvar () {
            await _context.SaveChangesAsync ();
        }
    }
}