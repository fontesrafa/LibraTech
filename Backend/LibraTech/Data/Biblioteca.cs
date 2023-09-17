using LibraTech.Models.DTO;

namespace LibraTech.Data
{
    public static class Biblioteca
    {
        public static List<LivroDTO> ListaLivro= new List<LivroDTO>
            {
                new LivroDTO{Id = 1, Titulo = "Engenharia de Software" },
                new LivroDTO{Id = 2,Titulo = "Design de Software" }
            };
    }
}
