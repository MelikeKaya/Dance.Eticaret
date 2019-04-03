using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dance.Eticaret.Model.Entity
{
    public class OrderLesson:EntityBase
    {
        public int OrderID { get; set; }
        public int DanceLessonID { get; set; }
        public DanceLesson DanceLesson { get; set; }
        public int Quantity { get; set; }
    }
}
