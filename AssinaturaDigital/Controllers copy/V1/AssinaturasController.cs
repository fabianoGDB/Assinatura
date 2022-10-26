using AssinaturaDigital.Entities;
using AssinaturaDigital.Exceptions;
using AssinaturaDigital.Model;
using AssinaturaDigital.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AssinaturaDigital.Controllers.V1
{
    [Route("api/V1/[controller]")]
    [ApiController]
    public class AssinaturasController : ControllerBase
    {
        private readonly IAssinaturaService _assinaturaService;

        public AssinaturasController(IAssinaturaService assinaturaService)
        {
            _assinaturaService = assinaturaService;
        }

        [HttpGet("{idAssinatura:guid}")]
        public async Task<ActionResult<IEnumerable<Assinatura>>> Obter([FromRoute]Guid idAssinatura)
        {
            var assinatura = await _assinaturaService.Obter(idAssinatura);

            if (assinatura == null)
                return NoContent();

            return Ok(assinatura);
        }

        [HttpPost]
        public async Task<ActionResult<Assinatura>> InserirAssinatura([FromBody]Assinatura assinaturaInputModel)
        {
            try
            {
                var assinatura = await _assinaturaService.Inserir(assinaturaInputModel);

                return Ok(assinatura);
            }
            catch (AssinaturaJaCadastradaException ex)
            {
                return UnprocessableEntity("Já existe uma assinatura com este nome de Usuario");
            }
        }

        [HttpPut("{idAssinatura:guid}")]
        public async Task<ActionResult> AtualizarAssinatura([FromRoute] Guid idAssinatura, Assinatura assinaturaInputModel)
        {
            try
            {
                await _assinaturaService.Atualizar(idAssinatura, assinaturaInputModel);
                return Ok();
            }
            catch (AssinaturaNaoCadastradaException ex)
            {
                return NotFound("Não existe essa assinatura");
            }
        }

        [HttpPatch("{senha}/{email}")]
        public async Task<ActionResult> ObterAssinatura([FromRoute] string senha,[FromRoute] string email)
        {
            try
            {
                await _assinaturaService.ObterAss(senha, email);
                return Ok();
            }
            catch (AssinaturaNaoCadastradaException ex)
            {
                return NotFound("Essa assinatura não existe");
            }
        }

        [HttpDelete("{idAssinatura:guid}")]
        public async Task<ActionResult> ApagarAssinatura([FromRoute] Guid idAssinatura)
        {
            try
            {
                await _assinaturaService.Remover(idAssinatura);
                return Ok();
            }
            catch(AssinaturaNaoCadastradaException ex)
            {
                return NotFound("Essa assinatura não existe");
            }
        }
    }
}
