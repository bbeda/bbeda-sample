using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace AnswersTest.Helpers
{
    public class JsonCamelCaseResult : ActionResult
    {
        private readonly object Data;

        public JsonCamelCaseResult(object data)
            : this(data, JsonRequestBehavior.DenyGet)
        {
        }

        public JsonCamelCaseResult(object data, JsonRequestBehavior behavior)
        {
            Data = data;
            JsonRequestBehavior = behavior;
        }

        public Encoding ContentEncoding { get; set; }

        public string ContentType { get; set; }

        public JsonRequestBehavior JsonRequestBehavior { get; set; }

        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            if (JsonRequestBehavior == JsonRequestBehavior.DenyGet && String.Equals(context.HttpContext.Request.HttpMethod, "GET", StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException("This operation does not allow GET");
            }

            HttpResponseBase response = context.HttpContext.Response;

            response.ContentType = !String.IsNullOrEmpty(ContentType) ? ContentType : "application/json";
            if (ContentEncoding != null)
            {
                response.ContentEncoding = ContentEncoding;
            }
            if (Data != null)
            {
                var jsonSerializerSettings = new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                };

                response.Write(JsonConvert.SerializeObject(Data, Formatting.Indented, jsonSerializerSettings));
            }
        }
    }
}