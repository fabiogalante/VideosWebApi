using System;

namespace CursoWebApi.ViewModel
{
    public class PostViewModel
    {
        public int PostId { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public int? CategoriaId { get; set; }
        public DateTime? DataCriacao { get; set; }
        public string CategoriaNome { get; set; }
    }
}