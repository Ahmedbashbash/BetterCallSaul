using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwDD1_ME2_Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            Calendar.CalendarFile = "sample.cal";
            Calendar.LoadCalendar();
            Calendar.saveFile();
            //Calendar.saveAllData();
        }
    }
}
