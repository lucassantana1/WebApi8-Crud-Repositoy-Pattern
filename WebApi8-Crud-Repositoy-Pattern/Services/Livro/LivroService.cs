using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebApi8_Crud_Repositoy_Pattern.Data;
using WebApi8_Crud_Repositoy_Pattern.Dto.Livro;
using WebApi8_Crud_Repositoy_Pattern.Models;

namespace WebApi8_Crud_Repositoy_Pattern.Services.Livro
{
    public class LivroService : ILivroInterface
    {
        private readonly AppDbContext _context;

        public LivroService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<LivroModel>> BuscarLivroPorId(int idLivro)
        {
            ResponseModel<LivroModel> resposta = new ResponseModel<LivroModel>();

            try
            {
                var livro = await _context.Livros.FirstOrDefaultAsync(livroBanco => livroBanco.Id == idLivro);

                if (livro == null)
                {
                    resposta.Mensagem = "Livro não encontrado.";
                    resposta.Status = false;
                    return resposta;
                }

                resposta.Dados = livro;
                resposta.Mensagem = "Livro encontrado com sucesso.";
                return resposta;
            }
            catch (Exception exe)
            {
                resposta.Mensagem = exe.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<LivroModel>>> BuscarLivroPorIdAutor(int idAutor)
        {
            ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();

            try
            {
                var livros = await _context.Livros
                    .Include(a => a.Autor)
                    .Where(livroBanco => livroBanco.Autor.Id == idAutor)
                    .ToListAsync();
                
                if (livros == null)
                {
                    resposta.Mensagem = "Livro não encontrado.";
                    return resposta;
                }

                resposta.Dados = livros;
                resposta.Mensagem = "Livro encontrado com sucesso.";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<LivroModel>>> CriarLivro(LivroCriacaoDto LivroCriacaoDto)
        {
            ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();

            try
            {
                var autor = await _context.Autores
                    .FirstOrDefaultAsync(autorBanco => autorBanco.Id == LivroCriacaoDto.Autor.Id);

                if (autor == null)
                {
                    resposta.Mensagem = "Autor não encontrado.";
                    return resposta;
                }

                var livro = new LivroModel()
                {
                    Titulo = LivroCriacaoDto.Titulo,
                    Autor = autor
                };

                _context.Add(livro);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Livros.Include(a => a.Autor)
                    .ToListAsync();

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<LivroModel>>> EditarLivro(LivroEdicaoDto LivroEdicaoDto)
        {
            ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();

            try
            {
                var livro = await _context.Livros
                    .Include(a => a.Autor)
                    .FirstOrDefaultAsync(livroBanco => livroBanco.Id == LivroEdicaoDto.Id);

                var autor = await _context.Autores
                    .FirstOrDefaultAsync(autorBanco => autorBanco.Id == LivroEdicaoDto.Autor.Id);

                if (livro == null)
                {
                    resposta.Mensagem = "Livro não encontrado.";
                    return resposta;
                }

                if(autor == null)
                {
                    resposta.Mensagem = "Autor não encontrado.";
                    return resposta;
                }

                livro.Titulo = LivroEdicaoDto.Titulo;
                livro.Autor = autor;

                _context.Update(livro);
                await _context.SaveChangesAsync();
                
                resposta.Dados = await _context.Livros
                    .ToListAsync();

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<LivroModel>>> ExcluirLivro(int idLivro)
        {
            ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();

            try
            {
                var autor = await _context.Livros.FirstOrDefaultAsync(livroBanco => livroBanco.Id == idLivro);

                if(autor == null)
                {
                    resposta.Mensagem = "Livro não encontrado.";
                    return resposta;
                }

                _context.Remove(autor);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Livros.ToListAsync();
                resposta.Mensagem = "Livro excluído com sucesso.";

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;

                return resposta;
            }
        }

        public async Task<ResponseModel<List<LivroModel>>> ListarLivros()
        {
            ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();

            try
            {
                var livros = await _context.Livros.ToListAsync();

                resposta.Dados = livros;
                resposta.Mensagem = "Lista de livros obtida com sucesso.";

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;

                return resposta;
            }
        }
    }
}
