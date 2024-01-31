using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Models.Request
{
    public class UpdatedNews
    {
        public int NewsId { get; set; }
        public string NewsHeader { get; set; }
        public string NewsContent { get; set; }
    }
}
