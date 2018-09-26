using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CursoWebApi.Interfaces;
using CursoWebApi.Models;
using CursoWebApi.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace CursoWebApi.Servicos
{

    public class CategoriaServico : ICategoriaServico
    {
        private readonly ICategoriaRepositorio _categoriaRepositorio;

        public CategoriaServico(ICategoriaRepositorio categoriaRepositorio)
        {
            _categoriaRepositorio = categoriaRepositorio;
        }

        public async Task<IActionResult> ObterCategorias()
        {
            try
            {
                IEnumerable<Categoria> categorias = await _categoriaRepositorio.ObterCategorias();

                if (categorias != null)
                {
                    return new OkObjectResult(categorias.Select(c => new CategoriaViewModel
                            {
                                CategoriaNome = c.Nome,
                                PalavraChave = c.PalavraChave

                            }
                        )
                        .OrderBy(c => c.CategoriaNome)
                        .ThenBy(c => c.PalavraChave)
                    );
                }

                return new NotFoundResult();

            }
            catch
            {
                return new ConflictResult();
            }
        }
    }
}
