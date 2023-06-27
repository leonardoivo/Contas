
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

        public List<ContaModel> ListarClientes()
        {
            return _context.Conta.FromSqlRaw($@" SELECT ClienteId, Nome, Porte 
                                                         FROM sca.Cliente").ToList();
        }
        public List<ContaModel> ObterClienteId(int clienteId)
        {
            return _context.Conta.FromSqlRaw($@" SELECT ClienteId, Nome, Porte 
                                                         FROM sca.Cliente
                                                       WHERE ClienteId = {clienteId}").ToList();
        }

        public void InserirCliente(ContaModel cliente)
        {
            _context.Conta.FromSqlRaw($@"insert into cliente (Nome,Cliente)values({cliente.Nome},{cliente.Porte})");

        }

        public void AlterarCliente(ContaModel cliente)
        {
            _context.Conta.FromSqlRaw($@"update  cliente set Nome={cliente.Nome},Porte={cliente.Porte} where clienteId={cliente.IdCliente}");

        }

        public void DeletarCliente(int clienteId)
        {

            _context.Conta.FromSqlRaw($@"delete from cliente where clienteId={clienteId}");

        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
