using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CursoWebApi.Interfaces
{
    public interface ICategoriaServico
    {
        Task<IActionResult> ObterCategorias();
    }
}
