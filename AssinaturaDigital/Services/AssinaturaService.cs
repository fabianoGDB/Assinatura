using AssinaturaDigital.Entities;
using AssinaturaDigital.Repositories;

namespace AssinaturaDigital.Services
{
    public class AssinaturaService : IAssinaturaService
    {
        private readonly IAssinaturaRepository _assinaturaRepository;

        public AssinaturaService(IAssinaturaRepository assinaturaRepository)
        {
            _assinaturaRepository = assinaturaRepository;
        }

        
        public Task<Assinatura> Obter(Guid id)
        {
            return _assinaturaRepository.Obter(id);
        }
        public Task<List<Assinatura>> ObterAss(string email, string senha)
        {
            return _assinaturaRepository.ObterAsinaturas(senha, email);
        }
        public async Task<Assinatura> Inserir(Assinatura assinatura)
        {
            return await _assinaturaRepository.Inserir(assinatura);
        }
        public Task Atualizar(Guid id, Assinatura assinatura)
        {
            return _assinaturaRepository.Atualizar(assinatura);
        }

        public Task Atualizar(Guid id, string url)
        {
            var assinatura = new Assinatura(){};
            return _assinaturaRepository.Atualizar(assinatura);
        }

        public  Task Remover(Guid id)
        {
            return _assinaturaRepository.Remover(id);
        }
    }
}
