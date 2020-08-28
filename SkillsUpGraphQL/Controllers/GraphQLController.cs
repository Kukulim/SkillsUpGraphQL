using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkillsUpGraphQL.Utilities;

namespace SkillsUpGraphQL.Controllers
{
    [Route("[controller]")]
    public class GraphQLController : Controller
    {
        private readonly ISchema schema;
        private readonly IDocumentExecuter documentExecuter;

        public GraphQLController(ISchema schema, IDocumentExecuter documentExecuter)
        {
            this.schema = schema;
            this.documentExecuter = documentExecuter;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GraphQLQuery query)
        {
            if (query==null)
            {
                throw new ArgumentNullException(nameof(query));
            }
            var inputs = query.Varibles?.ToInputs();
            var executionOptions = new ExecutionOptions
            {
                Schema = schema,
                Query = query.Query,
                Inputs = inputs
            };
            var result = await documentExecuter.ExecuteAsync(executionOptions);

            return Ok(result);
        }
    }
}