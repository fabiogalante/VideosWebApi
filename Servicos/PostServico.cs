using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CursoWebApi.Interfaces;
using CursoWebApi.Models;
using CursoWebApi.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace CursoWebApi.Servicos
{
    public class PostServico : IPostServico
    {
        private readonly IPostRepositorio _postRepositorio;

        public PostServico(IPostRepositorio postRepositorio)
        {
            _postRepositorio = postRepositorio;
        }


        public async Task<IActionResult> ObterPosts()
        {

            var posts = await _postRepositorio.ObterPosts();

            if (posts != null)
            {
                return new OkObjectResult(posts.Select(p => new PostViewModel
                {
                    Id = p.PostId,
                    Titulo = p.Titulo,
                    Descricao = p.Descricao,
                    DataCriacao = p.DataCriacao,
                }));
            }

            return new BadRequestResult();

        }

        public async Task<IActionResult> ObterPostsPorCategoria(int? categoriaId)
        {
            if (categoriaId == null)
                return new BadRequestResult();

            var posts = await _postRepositorio.ObterPostsPorCategoria(categoriaId);

            if (posts != null)
            {
                return new OkObjectResult(posts.Select(p => new PostViewModel
                {
                    Titulo = p.Titulo,
                    Descricao = p.Descricao,
                    DataCriacao = p.DataCriacao,
                }));
            }

            return new BadRequestResult();
           
        }

        public async Task<IActionResult> ObterPost(int? postId)
        {
            Post post = await _postRepositorio.ObterPost(postId);

            if (post != null)
            {
                return new OkObjectResult(new PostViewModel
                {
                    Id = post.PostId,
                    Titulo = post.Titulo,
                    Descricao = post.Descricao,
                    DataCriacao = post.DataCriacao
                });
            }

            return new NoContentResult();
        }

       


        public async Task<IActionResult> AdicinarPost([FromBody] Post post)
        {
            if (post == null)
                return new BadRequestResult();

            var postId = await _postRepositorio.AdicinarPost(post);

            if (postId > 0)
                return new OkObjectResult(postId);

            return new StatusCodeResult(500);
        }

        public async Task<IActionResult> ExcluirPost(int? postId)
        {

            if (postId == null)
                return new NoContentResult();

            var post = await _postRepositorio.ExcluirPost(postId);

            return new OkObjectResult(new PostViewModel
            {
                Id = post.PostId,
                Titulo = post.Titulo,
                Descricao = post.Descricao
            });                          
         
        }

        public async Task<IActionResult> AtualizarPost(Post post)
        {
            if (post == null)
                return new BadRequestResult();

            await  _postRepositorio.AtualizarPost(post);

            return new OkResult();
        }
    }
}
