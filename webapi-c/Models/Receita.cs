using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi_c.Models
{
    [Table("Receita")]
    public class Receita
    {
        [Key]
        [Column("Id")]
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Column("Nome")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Column("Valor")]
        [Display(Name = "Valor")]
        public decimal Valor { get; set; }

        [Column("Data")]
        [Display(Name = "Data")]
        [DataType(DataType.Date)] // Especifica que o tipo de dado esperado é apenas a data
        public DateTime Data { get; set; } // Armazena apenas a data, sem a hora
    }
}
