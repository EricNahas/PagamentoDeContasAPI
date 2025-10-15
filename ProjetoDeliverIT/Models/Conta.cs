using ProjetoDeliverIT.Utils;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoDeliverIT.Models
{
    public class Conta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [CampoObrigatorioAttribute(ErrorMessage = "O campo Nome é obrigatório.")]
        public string Nome { get; set; } = string.Empty;

        [CampoObrigatorioAttribute(ErrorMessage = "O campo Valor Original é obrigatório.")]
        public decimal ValorOriginal { get; set; }

        [CampoObrigatorioAttribute(ErrorMessage = "O campo Data de Vencimento é obrigatório.")]
        public DateTimeOffset DataVencimento { get; set; }

        [CampoObrigatorioAttribute(ErrorMessage = "O campo Data de Pagamento é obrigatório.")]
        public DateTimeOffset DataPagamento { get; set; }

        public decimal ValorCorrigido { get; set; }
        public int DiasAtraso { get; set; }
        public decimal Multa { get; set; }
        public decimal JurosDia { get; set; }
    }
}