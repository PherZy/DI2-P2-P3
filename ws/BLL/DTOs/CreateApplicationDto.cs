using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class CreateApplicationDto
    {
        public string Name { get; set; }
        public ApplicationType Type { get; set; }
    }
}
