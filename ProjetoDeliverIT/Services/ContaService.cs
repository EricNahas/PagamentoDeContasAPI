using AutoMapper;
using ProjetoDeliverIT.DTOs;
using ProjetoDeliverIT.Models;
using ProjetoDeliverIT.Repositories;
using ProjetoDeliverIT.Utils;

namespace ProjetoDeliverIT.Services
{
    public class ContaService : IContaService
    {
        private readonly IContaRepository _repo;
        private readonly IContaRegraAtrasoRepository _regraRepo;
        private readonly IMapper _mapper;


        public ContaService(IContaRepository repo, IContaRegraAtrasoRepository regraRepo, IMapper mapper)
        {
            _repo = repo;
            _regraRepo = regraRepo;
            _mapper = mapper;
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
                    bill.Multa = bill.ValorOriginal * regra.Multa;
                    bill.JurosDia = bill.ValorOriginal * regra.JurosDia * diasAtraso;
                    bill.ValorCorrigido = bill.ValorOriginal + bill.Multa + bill.JurosDia;
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

        public IEnumerable<ContaDTO> GetAll()
        {
            IEnumerable<Conta> contas = _repo.GetAll();

            var listaContas = _mapper.Map<IEnumerable<ContaDTO>>(contas);

            return listaContas;
        }
    }
}
