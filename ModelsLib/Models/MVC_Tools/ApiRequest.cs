using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ModelsLib.Models.StaticDetails;

namespace ModelsLib.Models.MVC_Tools
{
    public class ApiRequest
    {
        public ApiType apiType { get; set; }
        public string Url { get; set; }
        public Object Data { get; set; }

    }
}
