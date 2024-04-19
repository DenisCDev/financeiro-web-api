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
        public double Valor { get; set; }

        private DateTime _data;

        [Column("Data")]
        [Display(Name = "Data")]
        [DataType(DataType.Date)]
        public DateTime Data
        {
            get => _data.Date; // Retorna apenas a data sem a hora
            set => _data = DateTime.SpecifyKind(value, DateTimeKind.Utc); // Define a data como UTC
        }
    }
}
