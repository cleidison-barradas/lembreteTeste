using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MeusLembretes.com.Models
{
    [Table("tbl_usuario")]
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage ="Nome Obrigatorio")]
        public string UsuarioNome { get; set; }

        [Required(ErrorMessage ="Email Obrigatorio")]
        public string Email { get; set; }    
        
        public string Telefone { get; set; }

        public DateTime DataCadastro { get; set; }

        [Required(ErrorMessage ="Senha Obrigatorio")]  
        public string Senha { get; set; }

        public bool Ativo { get; set; }

        public virtual ICollection<Usuario> Usuarios{ get; set; }
    }
}