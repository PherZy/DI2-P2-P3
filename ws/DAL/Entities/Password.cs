using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DAL.Entities
{
    public class Password
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string EncryptedPassword { get; set; }
        public string Notes { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? LastModified { get; set; }

        public int ApplicationId { get; set; }
        public virtual Application Application { get; set; }
    }
}
