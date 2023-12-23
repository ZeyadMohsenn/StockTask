using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeZone.DAL
{
    public class Admin
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public int? StoreId { get; set; } = 0;
        public Store? Store { get; set; }

    }
}
