using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Models.Entities
{
    public class NewsEntity
    {
        [Key]
        public int Id { get; set; }
        public string Header { get; set; }    
        public string Content { get; set; }
        public int Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedUser { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedUser { get; set; }
    }
}
