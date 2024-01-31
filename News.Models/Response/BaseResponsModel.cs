using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Models.Response
{
    public class BaseResponsModel<T>
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public T Obj { get; set; }
    }
}
