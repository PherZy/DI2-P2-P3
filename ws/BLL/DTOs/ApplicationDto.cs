using DAL.Entities;

namespace BLL.DTOs
{
    public class ApplicationDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ApplicationType Type { get; set; }
    }
}
