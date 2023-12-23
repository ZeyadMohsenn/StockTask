using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CodeZone.DAL
{
    public class Store
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        public string? Name { get; set; }
        public string? ManagerName { get; set; }  
        public Admin? Admin { get; set; }
        public string? Location { get; set; }
        public string? PhoneNumber { get; set; }
        public string? OpeningTime { get; set; }
        public string? ClosingTime { get; set; }
        public ICollection<StoreItem> StoreItems { get; set; } = new List<StoreItem>();
    }
}
