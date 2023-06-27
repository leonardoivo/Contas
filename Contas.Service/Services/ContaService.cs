using AutoMapper;
using Contas.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Contas.Application;
using Contas.Application.ViewModels.Conta;
using Contas.Domain.Interfaces;
using Contas.Domain.Models;
using Contas.Domain;
using Contas.Service.Interfaces;


namespace Contas.Service.Services
{
    public interface ContaService:IContaService
    {
        private readonly IContaRepository _contaRepository;
        protected readonly IMapper _map;

        public ContaService(IContaRepository contaRepository, IMapper map)
        {
            _contaRepository = contaRepository;
            _map = map;
        }

        public List<ContaViewModel> Listarcontas()
        {

            var contas = _contaRepository.Listarcontas();
            return _map.Map<List<ContaViewModel>>(contas);

        }
        public List<ContaViewModel> ObtercontaId(int contaId)
        {
            var contas = _contaRepository.ObtercontaId(contaId);
            return _map.Map<List<ContaViewModel>>(contas);
        }

        public void Inserirconta(ContaViewModel conta)
        {
            var contaNovo = _map.Map<ContaModel>(conta);

            _contaRepository.Inserirconta(contaNovo);
        }

        public void Alterarconta(ContaViewModel conta)
        {
            var contaAtualizado = _map.Map<ContaModel>(conta);

            _contaRepository.Alterarconta(contaAtualizado);

        }

        public void Deletarconta(int contaId)
        {

            _contaRepository.DeletarConta(contaId);

        }

    }
}
