
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Contas.Domain.Interfaces;
using Contas.Domain.Models;
using Contas.Infrastructure.Context;
using System.Collections.Generic;

namespace Contas.Infrastructure.Repositories
{
    public class ContaRepository : IContaRepository
    {
        readonly ContaDbContext _context;


        public ContaRepository(ContaDbContext context)
        {
            _context = context;
        }

        public List<ContaModel> ListarContas()
        {
            return _context.Conta.FromSqlRaw($@" SELECT ContaId, Nome, Descricao 
                                                         FROM Conta").ToList();
        }
        public List<ContaModel> ObterContaId(int ContaId)
        {
            return _context.Conta.FromSqlRaw($@" SELECT Contaid, Nome, Descricao 
                                                         FROM conta
                                                       WHERE Contaid = {ContaId}").ToList();
        }

        public void InserirConta(ContaModel conta)
        {
            _context.Conta.FromSqlRaw($@"insert into conta (Nome,Descricao)values({conta.Nome},{conta.Descricao})");

        }

        public void AlterarConta(ContaModel conta)
        {
            _context.Conta.FromSqlRaw($@"update  conta set Nome={conta.Nome},Descricao={conta.Descricao} where contaId={conta.ContaId}");

        }

        public void DeletarConta(int ContaId)
        {

            _context.Conta.FromSqlRaw($@"delete from conta where contaId={ContaId}");

        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
