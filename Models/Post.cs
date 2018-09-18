using System;

namespace CursoWebApi.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public int? CategoriaId { get; set; }
        public DateTime? DataCriacao { get; set; }

        
        public Categoria Categoria { get; set; }

    }
}