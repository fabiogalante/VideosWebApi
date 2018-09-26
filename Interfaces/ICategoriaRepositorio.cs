using System.Collections.Generic;
using System.Threading.Tasks;
using CursoWebApi.Models;

namespace CursoWebApi.Interfaces
{
    public interface ICategoriaRepositorio
    {
        Task<IEnumerable<Categoria>> ObterCategorias();
    }
}
