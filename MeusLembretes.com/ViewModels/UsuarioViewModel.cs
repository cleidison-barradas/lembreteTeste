using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MeusLembretes.com.ViewModels
{ 
    public class UsuarioViewModel

    {
        [Required(ErrorMessage ="Nome e Obrigatorio")]
        public string UsuarioNome { get; set; }

        [DataType(DataType.EmailAddress,ErrorMessage ="Digite um email valido")]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber,ErrorMessage ="Telefone Invalido")]
        public string Telefone { get; set; }

        public bool Ativo { get; set; }

        [DataType(DataType.Password,ErrorMessage ="Senha Invalida")]
        [MinLength(6,ErrorMessage ="Senha deve conter um minimo {1}")]
        public string Senha { get; set; }

        [DataType(DataType.Password, ErrorMessage = "Senha Invalida")]
        [Compare(nameof(Senha),ErrorMessage ="Senhas nao conferem")]
        [MinLength(6, ErrorMessage = "Senha deve conter um minimo {1}")]
        public string ComfirmacaoSenha { get; set; }

        public DateTime DataCadastro{ get; set; }
    }
}