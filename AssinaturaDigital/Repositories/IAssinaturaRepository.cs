﻿using AssinaturaDigital.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AssinaturaDigital.Repositories
{
    public interface IAssinaturaRepository
    {
        Task<Assinatura> Obter(Guid id);
        Task<List<Assinatura>> ObterAsinaturas(string Usuario, string Email);
        Task<Assinatura> Inserir(Assinatura assinatura);
        Task Atualizar(Assinatura assinatura);
        Task Remover(Guid id);
    }
}