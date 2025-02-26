using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Application
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ApplicationType Type { get; set; }
        public DateTime CreatedAt { get; set; }
        public virtual ICollection<Password> Passwords { get; set; }
    }
}
