using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dance.Eticaret.Model.Entity
{
    public class DanceType:EntityBase
    {
        public int ParentID { get; set; } = 0;
        public string Name { get; set; }
        public bool IsActive { get; set; }


    }
}
