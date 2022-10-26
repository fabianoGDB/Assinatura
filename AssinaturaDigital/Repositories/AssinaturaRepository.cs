using AssinaturaDigital.Entities;
using AssinaturaDigital.Model;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AssinaturaDigital.Repositories
{
    public class AssinaturaRepository : IAssinaturaRepository
    {

        private readonly IMongoCollection<Assinatura> _collection;
        private readonly DbConfiguration _dbConfiguration;

        public AssinaturaRepository(IOptions<DbConfiguration> dbConfiguration)
        {
            _dbConfiguration = dbConfiguration.Value;
            var client = new MongoClient(_dbConfiguration.ConnectionString);
            var bd = client.GetDatabase(_dbConfiguration.DatabaseName);
            _collection = bd.GetCollection<Assinatura>(_dbConfiguration.CollectionName);
        }


        public Task<Assinatura> Obter(Guid id)
        {
            return _collection.Find(c => c.Id == id).FirstOrDefaultAsync();
        }

        public Task<List<Assinatura>> ObterAsinaturas(string usuario, string email)
        {
            return _collection.Find(c => c.Usuario == usuario && c.Email == email).ToListAsync();
        }

        public async Task<Assinatura>  Inserir(Assinatura assinatura)
        {
            await _collection.InsertOneAsync(assinatura).ConfigureAwait(false);
            return assinatura;
        }

        public Task Atualizar(Assinatura assinatura)
        {
            return _collection.ReplaceOneAsync(c => c.Id == assinatura.Id, assinatura);
        }

        public Task Remover(Guid id)
        {
            return _collection.DeleteOneAsync(c => c.Id == id);
        }
    }
}
