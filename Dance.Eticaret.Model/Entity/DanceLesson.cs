using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dance.Eticaret.Model.Entity
{
    public class DanceLesson :EntityBase
    {
        public string Name { get; set; }
        public int DanceTypeID { get; set; }
        public DanceType DanceType { get; set; }
        public string Trainer { get; set; }
        public string ImageUrl { get; set; }
        public string VideoUrl { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Tax { get; set; }
        public decimal Discount { get; set; }
        public int Kontenjan { get; set; }
        public bool IsActive { get; set; }


    }
}
