using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Misubishi.DAL.DTO
{
    public class CreateCarDto
    {
        public string Name { get; set; } = null!;
        public decimal? Price { get; set; }
        public string? ImageUrl { get; set; }
        public int? CategoryId { get; set; }
        public string? Description { get; set; }
    }
}
