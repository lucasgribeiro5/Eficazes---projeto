using Core.Models;

namespace Core.Services
{
    public interface IImagemService
    {
        public Task<string> GuardarImagem(Imagem imagem, string pasta, string nome);
    }
}