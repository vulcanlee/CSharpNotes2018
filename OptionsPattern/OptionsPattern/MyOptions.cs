using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OptionsPattern
{
    public class MyOptions
    {
        public string ConnectionString { get; set; }
        public bool ActionMode { get; set; }
         public string OS { get; set; }
        public string MyName { get; set; }
       public ExcetionMode ExcetionMode { get; set; }
    }
    public class ExcetionMode
    {
        public ExcetionModeType ShowType { get; set; }
        public int Max { get; set; }
    }
    public enum ExcetionModeType
    {
        Detail,
        None,
        More
    }
}
