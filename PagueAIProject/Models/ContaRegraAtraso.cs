using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoDeliverIT.Models
{
    /// <summary>
    /// Tabela que define as regras de atraso para contas.
    /// Por padrão, as regras são definidas por intervalos de dias.
    /// </summary>
    public class ContaRegraAtraso
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        /// <summary>
        /// O número mínimo da MENOR regra deve ser 1
        /// </summary>
        public int DiasMinimo { get; set; }

        /// <summary>
        /// O número máximo da MAIOR regra deve ser nulo (sem limite)
        /// Isso quer dizer que: após o número mínimo, não há limite máximo para aplicação da regra
        /// </summary>
        public int? DiasMaximo { get; set; }
        public decimal Multa { get; set; }
        public decimal JurosDia { get; set; }
    }
}
