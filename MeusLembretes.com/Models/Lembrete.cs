using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MeusLembretes.com.Models
{
    [Table("tbl_lembrete")]
    public class Lembrete
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LembreteId { get; set; }

        public int UsuarioId { get; set; }

        [Required(ErrorMessage ="Um Titulo E Requerido")]
        [MaxLength(50,ErrorMessage ="Maximo de {1} Caracteres Atingido")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Uma Mensagem E Requerida")]
        [MaxLength(250, ErrorMessage = "Maximo de {1} Caracteres Atingido")]
        public string Mensagem  { get; set; }

        [Required(ErrorMessage = "Uma Data E Requerida")]
        [DataType(DataType.Date,ErrorMessage ="Formato Invalido")]
        public DateTime RealizacaoData { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Formato Invalido")]
        public DateTime DataCadastro { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Formato Invalido")]
        public DateTime Modificacao { get; set; }

        public virtual Usuario Usuario { get; set; }

    }
}