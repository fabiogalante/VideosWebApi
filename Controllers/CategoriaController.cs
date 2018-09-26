using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CursoWebApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CursoWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : Controller
    {
        private readonly ICategoriaServico _categoriaServico;

        public CategoriaController(ICategoriaServico categoriaServico)
        {
            _categoriaServico = categoriaServico;
        }

        [HttpGet]
        [Route("ObterCategorias")]
        public async Task<IActionResult> ObterCategorias()
        {
            return await _categoriaServico.ObterCategorias();
            
        }
    }
}