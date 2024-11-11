namespace Core.Models
{
    public class Imagem
    {
        public string NomeDoArquivo { get; set; }
        public byte[] Conteudo { get; set; }
        public string TipoDeConteudo { get; set; }
        public string Extensao { get; set; }
    }
}
