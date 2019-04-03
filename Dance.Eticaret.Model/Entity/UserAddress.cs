using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dance.Eticaret.Model.Entity
{
    public class UserAddress:EntityBase
    {
        public int UserID { get; set; }//kimin adresi olduğunu belirtecek
        public User User { get; set; }//üsttekiyle ikisi birbirni keyledi
        public string Title { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string IsActive { get; set; }
    }
}
