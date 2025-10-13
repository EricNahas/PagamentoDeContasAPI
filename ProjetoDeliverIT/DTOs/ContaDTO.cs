namespace ProjetoDeliverIT.DTOs
{
    public class ContaDTO
    {
        public string? Nome { get; set; }                
        public decimal ValorOriginal { get; set; }      
        public decimal ValorCorrigido { get; set; }     
        public int DiasAtraso { get; set; }             
        public DateTimeOffset DataPagamento { get; set; }     
    }
}
