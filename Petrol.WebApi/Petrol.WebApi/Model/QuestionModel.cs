using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petrol.WebApi.Model
{
    public class QuestionModel
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
    }
}
