using Newtonsoft.Json.Linq;
using System;

namespace SkillsUpGraphQL.Utilities
{
    public class GraphQLQuery
    {
        public string OperationName { get; set; }
        public string Query { get; set; }
        public JObject Varibles { get; set; }
    }

}
