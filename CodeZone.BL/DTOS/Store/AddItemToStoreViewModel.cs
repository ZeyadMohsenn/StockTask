using CodeZone.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeZone.BL
{
    public class AddItemToStoreViewModel
    {
        [Required(ErrorMessage = "Please select an item.")]
        public int ItemId { get; set; }

        [Required(ErrorMessage = "Please enter the quantity.")]
        public int Quantity { get; set; }

        public int StoreId { get; set; }

        public List<Item> AvailableItems { get; set; }
    }
}
