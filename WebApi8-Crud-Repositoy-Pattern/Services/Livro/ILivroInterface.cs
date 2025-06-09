using WebApi8_Crud_Repositoy_Pattern.Dto.Livro;
using WebApi8_Crud_Repositoy_Pattern.Models;

namespace WebApi8_Crud_Repositoy_Pattern.Services.Livro
{
    public interface ILivroInterface
    {
        Task<ResponseModel<List<LivroModel>>> ListarLivros();
        Task<ResponseModel<LivroModel>> BuscarLivroPorId(int idLivro);
        Task<ResponseModel<List<LivroModel>>> BuscarLivroPorIdAutor(int idAutor);
        Task<ResponseModel<List<LivroModel>>> CriarLivro(LivroCriacaoDto LivroCriacaoDto);
        Task<ResponseModel<List<LivroModel>>> EditarLivro(LivroEdicaoDto LivroEdicaoDto);
        Task<ResponseModel<List<LivroModel>>> ExcluirLivro(int idLivro);
    }
}
