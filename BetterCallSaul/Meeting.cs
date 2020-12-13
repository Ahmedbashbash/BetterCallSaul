using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwDD1_ME2_Sample
{
    class Meeting
    {
        string description;
        int time;
        public string Description
        {
            get
            {
                return description; 
            } 
        }
        public int Time 
        { 
            get 
            { 
                return time; 
            } 
        }
        public Meeting(string description, int time)
        {
            this.description = description;
            this.time = time;
        }
    }
}
