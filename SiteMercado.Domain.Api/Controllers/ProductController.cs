using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using SiteMercado.Domain.Api;
using SiteMercado.Domain.Commands;
using SiteMercado.Domain.Entities;
using SiteMercado.Domain.Handlers;
using SiteMercado.Domain.Repositories;

namespace SiteMercado.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductController : ControllerBase
    {
        /// <summary>
        /// Cria um novo produto
        /// </summary>
        /// <param name="command"></param>
        /// <param name="handler"></param>
        /// <returns></returns>
        [Route("")]
        [HttpPost]
        [Authorize]
        public GenericCommandResult Create(
            [FromBody] CreateProductCommand command,
            [FromServices] ProductHandler handler
        )
        {
            return (GenericCommandResult)handler.Handle(command);
        }

        /// <summary>
        /// Retorna um  Produto filtrado pelo ID
        /// </summary>
        /// <param name="id">ID do produto</param>
        /// <param name="repository">repositório de pesquisa</param>
        [Route("{id}")]
        [HttpGet]
        [Authorize]
        public Product GetById(string id,
            [FromServices] IProductRepository repository
        )
        {
            var obj = repository.GetById(Guid.Parse(id));
            return obj;
        }

        /// <summary>
        /// Retorna lista de Produtos
        /// </summary>
        /// <param name="repository">repositório de pesquisa</param>
        [Route("")]
        [HttpGet]
        [Authorize]
        public IEnumerable<Product> GetAll(
            [FromServices] IProductRepository repository
        )
        {
            return repository.GetAll();
        }


        /// <summary>
        /// Atualiza dados do produto
        /// </summary>
        /// <param name="command"></param>
        /// <param name="handler"></param>
        /// <returns></returns>         
        [Route("")]
        [HttpPut]
        [Authorize]
        public GenericCommandResult Update(
            [FromBody] UpdateProductCommand command,
            [FromServices] ProductHandler handler
        )
        {
            return (GenericCommandResult)handler.Handle(command);
        }

        /// <summary>
        /// Exclui um produto
        /// </summary>
        /// <param name="command"></param>
        /// <param name="handler"></param>
        /// <returns></returns>         
        [Route("")]
        [HttpDelete]
        [Authorize]
        public GenericCommandResult Delete(
            [FromBody] DeleteProductCommand command,
            [FromServices] ProductHandler handler
        )
        {
            return (GenericCommandResult)handler.Handle(command);
        }

    }
}