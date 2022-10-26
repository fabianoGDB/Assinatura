
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AssinaturaDigital.Entities;

namespace AssinaturaDigital.Services
{
    public interface IAssinaturaService
    {
        Task<Assinatura> Obter(Guid id);
        Task<List<Assinatura>> ObterAss(string Usuario, string Email);
        Task<Assinatura> Inserir(Assinatura assinatura);
        Task Atualizar(Guid id, Assinatura assinatura);
        Task Remover(Guid id);
    }
}
