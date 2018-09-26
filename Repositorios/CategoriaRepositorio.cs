using System.Collections.Generic;
using System.Threading.Tasks;
using CursoWebApi.Data;
using CursoWebApi.Interfaces;
using CursoWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CursoWebApi.Repositorios
{
    public class CategoriaRepositorio : ICategoriaRepositorio
    {
        private readonly BlogDbContext _context;

        public CategoriaRepositorio(BlogDbContext context)
        {
            _context = context;
        }
      

        public async Task<IEnumerable<Categoria>> ObterCategorias()
        {
            return await _context.Categoria.ToListAsync();
        }
    }
}
