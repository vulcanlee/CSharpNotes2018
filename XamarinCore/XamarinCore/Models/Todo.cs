using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XamarinCore.Models
{
    public class Todo
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public bool HasCompleted { get; set; }
    }
}
