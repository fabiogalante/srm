﻿using System.Collections.Generic;
using SRM.Domain.Entities;
using SRM.Domain.Interfaces.Applications;
using SRM.Domain.Interfaces.Service;
using SRM.Domain.Repository;

namespace SRM.Application.ServiceApplication
{
    public class ClienteApplication<TContext> : SRMApplicationBase<TContext, Cliente, int>, IClienteApplication<TContext> where TContext : IUnitOfWork<TContext>
    {
        private readonly IClienteService<TContext> _clienteService;

        public ClienteApplication(IUnitOfWork<TContext> context, IClienteService<TContext> service) : base(context, service)
        {
            _clienteService = service;
        }

        public List<Cliente> GetClientes(string nome)
        {
            return _clienteService.GetClientes(nome);
        }

        public void Salvar(Cliente model)
        {
            _clienteService.Salvar(model);
            _unitOfWork.Commit();
        }
    }
}
