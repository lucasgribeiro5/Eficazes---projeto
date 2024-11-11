using Core.DTOs;

namespace Core.Models
{
    public class Endereco
    {
        public string Id { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Complemento { get; set; }
        public int Numero { get; set; }
        public Cliente Cliente { get; set; }

        private Endereco() { }

        public Endereco(EnderecoDTO enderecoDTO)
        {
            Cep = enderecoDTO.Cep;
            Logradouro = enderecoDTO.Logradouro;
            Bairro = enderecoDTO.Bairro;
            Cidade = enderecoDTO.Cidade;
            Complemento = enderecoDTO.Complemento;
            Numero = enderecoDTO.NumeroResidencia;
        }
    }
}