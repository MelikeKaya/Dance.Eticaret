using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dance.Eticaret.Model.Entity
{
    public class Basket:EntityBase
    {
        public int UserId { get; set; }
        public int DanceLessonID { get; set; }
        public DanceLesson DanceLesson { get; set; }
        public int Quantity { get; set; }
    }
}
