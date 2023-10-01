using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLib.Models.MVC_Tools
{
    public class ResponseDTO
    {
        public bool IsSuccess { get; set; } = true;
        public object Result { get; set; }
        public string ErrorMessage { get; set; } = "";
        public List<string> ErrorMessages { get; set; }
    }
}
