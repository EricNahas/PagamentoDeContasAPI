using AutoMapper;
using ProjetoDeliverIT.DTOs;
using ProjetoDeliverIT.Models;
using ProjetoDeliverIT.Repositories;
using ProjetoDeliverIT.Utils;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

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
                int diasAtraso = CalcularDiasAtraso(bill.DataPagamento, bill.DataVencimento);

                ContaRegraAtraso? regra = ObterRegra(diasAtraso);

                ValidarRegraAtraso(regra, diasAtraso);

                bill.DiasAtraso = diasAtraso;

                bill = RetornarContaCompleta(bill, regra);

                _repo.Insert(bill);
                _repo.SaveChanges();

                return ResponseUtils.RetornoSucessoErro(Enumerators.StatusRetornoAPI.Sucesso, MensagemRetornoAPI.Conta.InseridaSucesso, bill);
            }
            catch(CustomException ex)
            {
                return ex.RetornoAPI;
            }
            catch (Exception ex)
            {
                return ResponseUtils.RetornoSucessoErro(Enumerators.StatusRetornoAPI.ErroInterno, MensagemRetornoAPI.ErroInterno, ex.Message);
            }
        }

        public IEnumerable<ContaDTO> GetAll()
        {
            IEnumerable<Conta> contas = _repo.GetAll();

            var listaContas = _mapper.Map<IEnumerable<ContaDTO>>(contas);

            return listaContas;
        }

        #region Insert - Métodos Auxiliares
        private bool ContaAtrasada(int diasAtraso)
        {
            return diasAtraso > 0;
        }
        private Conta RetornarContaCompleta(Conta bill, ContaRegraAtraso regra)
        {
            if (ContaAtrasada(bill.DiasAtraso))
            {
                bill.Multa = CalcularMulta(bill.ValorOriginal, regra);
                bill.JurosDia = CalcularJuros(bill.ValorOriginal, bill.DiasAtraso, regra);
                bill.ValorCorrigido = CalcularValorCorrigido(bill.ValorOriginal, bill.Multa, bill.JurosDia);
            }
            else
                bill.ValorCorrigido = bill.ValorOriginal;

            return bill;
        }

        #region [ Parâmetro - ContaRegraAtraso ]

        private ContaRegraAtraso? ObterRegra(int diasAtraso)
        {
            return _regraRepo.GetByDias(diasAtraso);
        }
        private bool ExisteRegra(ContaRegraAtraso? regra)
        {
            return regra != null;
        }

        private void ValidarRegraAtraso(ContaRegraAtraso? regra, int diasAtraso)
        {
            if (!ExisteRegra(regra) && ContaAtrasada(diasAtraso))
                throw new CustomException(ResponseUtils.RetornoSucessoErro(Enumerators.StatusRetornoAPI.ErroRegraNegocio, MensagemRetornoAPI.ContaRegraAtraso.RegraNaoEncontarda(diasAtraso)));

            if (ExisteRegra(regra) && !ContaAtrasada(diasAtraso))
                throw new CustomException(ResponseUtils.RetornoSucessoErro(Enumerators.StatusRetornoAPI.ErroRegraNegocio, MensagemRetornoAPI.ContaRegraAtraso.RegraSemAtrasoExistente));

        }

        #endregion

        #region [ Cálculos ]

        private decimal CalcularMulta(decimal valorOriginal, ContaRegraAtraso regra)
        {
            return valorOriginal * regra.Multa;
        }
        private decimal CalcularJuros(decimal valorOriginal, int diasAtraso, ContaRegraAtraso regra)
        {
            return valorOriginal * regra.JurosDia * diasAtraso;
        }
        private int CalcularDiasAtraso(DateTimeOffset dataPagamento, DateTimeOffset dataVencimento)
        {
            int diasAtraso = (dataPagamento - dataVencimento).Days;
            return diasAtraso < 0 ? 0 : diasAtraso;
        }
        private decimal CalcularValorCorrigido(decimal valorOriginal, decimal multa, decimal jurosDia)
        {
            return valorOriginal + multa + jurosDia;
        }

        #endregion

        #endregion

    }
}
