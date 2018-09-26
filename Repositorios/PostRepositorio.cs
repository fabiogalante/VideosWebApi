using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CursoWebApi.Data;
using CursoWebApi.Interfaces;
using CursoWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CursoWebApi.Repositorios
{
    public class PostRepositorio : IPostRepositorio
    {
        private readonly BlogDbContext _context;

        public PostRepositorio(BlogDbContext context)
        {
            _context = context;
        }

        public async Task<int> AdicinarPost(Post post)
        {
            await _context.Post.AddAsync(post);
            await Salvar();
            return post.PostId;
        }

        public async Task AtualizarPost(Post post)
        {
            _context.Update(post);
            await Salvar();
        }

        public async Task<Post> ObterPost(int? postId)
        {
            return await _context.Post
                .Where(p => p.PostId == postId)
                .FirstOrDefaultAsync();

        }

        public async Task<Post> ExcluirPost(int? postId)
        {
            var post = await ObterPost(postId);

            if (post != null)
            {
                _context.Post.Remove(post);
                await Salvar();
            }

            return post;
        }
      


        public async Task<IEnumerable<Post>> ObterPosts()
        {
            return await _context.Post.ToListAsync();
        }

        public async  Task<IEnumerable<Post>> ObterPostsPorCategoria(int? categoriaId)
        {
            return  await _context.Post
                .Where(c => c.CategoriaId == categoriaId)
                .ToListAsync();
        }

        public async Task Salvar()
        {
            await _context.SaveChangesAsync();
        }
    }
}