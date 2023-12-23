using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeZone.DAL
{
    public class Item
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required.")]

        public string? ItemName { get; set; }
        public int Quantity { get; set; } = 0;

        [Range(0, double.MaxValue, ErrorMessage = "Price must be a non-negative value.")]

        public float price { get; set; } = 0;
        public DateTime ExpiryDate { get; set; }
        public ICollection<StoreItem> StoreItems { get; set; } = new List<StoreItem>();



    }
}
