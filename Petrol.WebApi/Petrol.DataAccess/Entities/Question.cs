using System;
using System.Collections.Generic;
using System.Text;

namespace Petrol.DataAccess.Entities
{
    public class Question
    {
        public int Id { get; set; }
        public string AskedQuestion { get; set; }
        public string Answer { get; set; }
    }
}
