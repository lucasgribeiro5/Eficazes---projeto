using Core.DTOs;

namespace Core.Models
{
    public class Cliente
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Apelido { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Cpf { get; set; }
        public string Genero { get; set; }
        public string Telefone { get; set; }        
        public string? Foto { get; set; }

        private Cliente() { }

        public Cliente(string nome, string apelido, string email, string senha, DateTime dataNascimento, string cpf, string genero, string telefone, string? foto = null)
        {
            Nome = nome;
            Apelido = apelido;
            Email = email;
            Senha = senha;
            DataNascimento = dataNascimento;
            Cpf = cpf;
            Genero = genero;
            Telefone = telefone;
            Foto = foto;
        }

        public Cliente(ClienteDTO clienteDTO)
        {
            Nome = clienteDTO.Nome;
            Apelido = clienteDTO.Apelido;
            Email = clienteDTO.Email;
            Senha = clienteDTO.Senha;
            DataNascimento = clienteDTO.DataNascimento;
            Cpf = clienteDTO.Cpf;
            Genero = clienteDTO.Genero;
            Telefone = clienteDTO.Telefone;
        }
    }
}
