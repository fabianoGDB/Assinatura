using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AssinaturaDigital.Entities
{
    public class Assinatura
    {
        [BsonId]
        [BsonElement("id")]
        public Guid Id { get; set; }
        [BsonElement("nome")]
        public string Nome { get; set; }
        [BsonElement("telefone")]
        public string Telefone { get; set; }
        [BsonElement("url")]
        public string Url { get; set; }
        [BsonElement("cargo")]
        public string Cargo { get; set; }
        [BsonElement("empresa")]
        public string Empresa { get; set; }
        [BsonElement("email")]
        public string Email { get; set; }
        [BsonElement("site")]
        public string Site { get; set; }
        [BsonElement("endereco")]
        public string Endereco { get; set; }
        [BsonElement("usuario")]
        public string Usuario { get; set; }
        [BsonElement("senha")]
        public string Senha { get; set; }
    }
}
