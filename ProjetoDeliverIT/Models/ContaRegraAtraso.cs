using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoDeliverIT.Models
{
    public class ContaRegraAtraso
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int DiasMinimo { get; set; }

        /// <summary>
        /// Caso nulo, indica que não há limite máximo para a regra.
        /// </summary>
        public int? DiasMaximo { get; set; }
        public decimal Multa { get; set; }
        public decimal JurosDia { get; set; }
    }
}
