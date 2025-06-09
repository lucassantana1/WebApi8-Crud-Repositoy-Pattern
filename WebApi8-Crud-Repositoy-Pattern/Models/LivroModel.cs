namespace WebApi8_Crud_Repositoy_Pattern.Models
{
    public class LivroModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public AutorModel Autor { get; set; }
    }
}
