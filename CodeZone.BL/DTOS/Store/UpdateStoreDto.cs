using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeZone.BL
{
    public class UpdateStoreDto
    {
        public string Name { get; set; }
        public string OpeningTime { get; set; }
        public string ClosingTime { get; set; }
        public string ManagerName { get; set; }
        public string PhoneNumber { get; set; }
    }
}
