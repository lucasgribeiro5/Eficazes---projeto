using Core.Models;
using Core.Services;

namespace Infrastructure.Services
{
    public class ImagemService : IImagemService
    {
        public async Task<string> GuardarImagem(Imagem imagem, string pasta, string nome)
        {
            string productsUploadFolderPath = Path.Combine("wwwroot", pasta);
            Directory.CreateDirectory(productsUploadFolderPath);

            string fullFileName = $"{nome}{imagem.Extensao}";
            string filePath = Path.Combine(productsUploadFolderPath, fullFileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await stream.WriteAsync(imagem.Conteudo, 0, imagem.Conteudo.Length);
            }

            string fileUrl = $"/{pasta}/{fullFileName}";

            return fileUrl;
        }
    }
}