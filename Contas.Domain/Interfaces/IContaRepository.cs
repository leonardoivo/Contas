using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contas.Domain.Models;

namespace Contas.Domain.Interfaces
{
    public interface IContaRepository : IDisposable
    {
        public List<ContaModel> ListarContas();

        public List<ContaModel> ObterContaId(int contaId);

        public void InserirConta(ContaModel conta);

        public void AlterarConta(ContaModel conta);

        public void DeletarConta(int contaId);




    }
}
