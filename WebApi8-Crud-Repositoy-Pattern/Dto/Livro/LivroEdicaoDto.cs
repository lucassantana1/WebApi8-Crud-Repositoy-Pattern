using WebApi8_Crud_Repositoy_Pattern.Dto.Vinculo;
using WebApi8_Crud_Repositoy_Pattern.Models;

namespace WebApi8_Crud_Repositoy_Pattern.Dto.Livro
{
    public class LivroEdicaoDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public AutorVinculoDto Autor { get; set; }
    }
}
