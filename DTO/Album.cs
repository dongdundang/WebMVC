using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Album
    {
        [Key]
        public int Id { set; get; }
        public string Name { set; get; }
        public string Image { set; get; }
        public int CreatedById { set; get; }
        public string CreatedByName { set; get; }
        public DateTime CreatedDate { set; get; }
        public int ModifiedById { set; get; }
        public string ModifiedByName { set; get; }
        public DateTime ModifiedDate { set; get; }
        public bool Activate { set; get; }

        public virtual ICollection<Song> Songs { set; get; }

        public Album()
        {
            Activate = true;
            ModifiedDate = DateTime.Now;
            Image = string.Empty;
        }
    }
}
