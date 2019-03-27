using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Song
    {
        [Key]
        public int Id { set; get; }
        public string Name { set; get;}
        public string Url { set; get; }
        public bool Activate { set; get; }
        public int CreatedById { set; get; }
        public string CreatedByName { set; get; }
        public DateTime CreatedDate { set; get; }
        public int ModifiedById { set; get; }
        public int ModifiedByName { set; get; }
        public DateTime ModifiedDate { set; get; }
        public int AlbumId { set; get; }

        public virtual Album Album { set; get; }
    }
}
