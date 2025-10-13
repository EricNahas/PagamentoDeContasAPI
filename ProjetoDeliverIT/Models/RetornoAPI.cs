using System.ComponentModel.DataAnnotations;
using ProjetoDeliverIT.Enumerators;

namespace ProjetoDeliverIT.Models
{
    public class RetornoAPI
    {
        public string? MensagemRetorno { get; set; }

        [EnumDataType(typeof(StatusRetornoAPI))]
        public short StatusRetorno { get; set; }

        public object? DadosRetorno { get; set; }
    }
}
