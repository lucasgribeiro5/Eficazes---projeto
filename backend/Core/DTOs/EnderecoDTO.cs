﻿using Core.Models;

namespace Core.DTOs
{
    public class EnderecoDTO
    {
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Complemento { get; set; }
        public int NumeroResidencia { get; set; }
    }
}
