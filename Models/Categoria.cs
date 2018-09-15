using System.Collections;
using System.Collections.Generic;

namespace CursoWebApi.Models
{
    public class Categoria
    {
        public Categoria()
        {
            Posts = new HashSet<Post>();
        }
        public int Id { get; set; } 
        public string Nome { get; set; }  
        public string PalavraChave { get; set; }

        public ICollection<Post> Posts { get; set; }
    }
}