using ProjetoDeliverIT.Models;
using ProjetoDeliverIT.Repositories;
using ProjetoDeliverIT.Utils;
using static System.Net.Mime.MediaTypeNames;

namespace ProjetoDeliverIT.Services
{
    public class ContaService : IContaService
    {
        private readonly IContaRepository _repo;
        private readonly IContaRegraAtrasoRepository _regraRepo;

        public ContaService(IContaRepository repo, IContaRegraAtrasoRepository regraRepo)
        {
            _repo = repo;
            _regraRepo = regraRepo;
        }

        public RetornoAPI Insert(Conta bill)
        {
            try
            {
                int diasAtraso = (bill.DataPagamento - bill.DataVencimento).Days;
                if (diasAtraso < 0) diasAtraso = 0;

                bill.DiasAtraso = diasAtraso;

                var regra = _regraRepo.GetByDias(diasAtraso);
                if (regra == null)
                    return ResponseUtils.RetornoSucessoErro(Enumerators.StatusRetornoAPI.ErroValidacao, $"Nenhuma regra encontrada para {diasAtraso} dias de atraso.");

                if (diasAtraso > 0)
                {
                    bill.ValorCorrigido = bill.ValorOriginal +
                        bill.ValorOriginal * bill.Multa / 100 +
                        (bill.ValorOriginal * (bill.JurosDia / 100) * diasAtraso);
                }
                else
                    bill.ValorCorrigido = bill.ValorOriginal;

                _repo.Insert(bill);
                _repo.SaveChanges();

                return ResponseUtils.RetornoSucessoErro(Enumerators.StatusRetornoAPI.Sucesso, "Conta inserida com sucesso.", bill);
            }
            catch (Exception ex)
            {
                return ResponseUtils.RetornoSucessoErro(Enumerators.StatusRetornoAPI.ErroInterno, "Erro ao inserir conta.", ex.Message);
            }
        }

        private void DefinirMultaEJuros(Conta bill)
        {
            if (bill.DiasAtraso <= 3)
            {
                bill.Multa = 2;
                bill.JurosDia = 0.1m;
            }
            else if (bill.DiasAtraso <= 5)
            {
                bill.Multa = 3;
                bill.JurosDia = 0.2m;
            }
            else
            {
                bill.Multa = 5;
                bill.JurosDia = 0.3m;
            }
        }

        public IEnumerable<Conta> GetAll() => _repo.GetAll();
    }
}
