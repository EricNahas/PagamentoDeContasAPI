using System.ComponentModel.DataAnnotations;

namespace ProjetoDeliverIT.Models
{
    public class Conta
    {
        public int ID { get; set; }

        #region [ Campos Obrigatórios ]
        public required string Nome { get; set; }
        public required decimal ValorOriginal { get; set; }
        public required DateTimeOffset DataVencimento { get; set; }
        public required DateTimeOffset DataPagamento { get; set; }
        #endregion

        public decimal ValorCorrigido { get; set; }
        public int DiasAtraso { get; set; }
        public decimal Multa { get; set; }
        public decimal JurosDia { get; set; }
    }
}
