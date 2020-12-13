using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwDD1_ME2_Sample
{
    enum DifficultyLevels {easypeasy=1, average=20, nightmare=100, ultramegahard=200}
    class Case
    {
        string clientName;
        public DifficultyLevels difficulty;
        string caseName;
        Meeting[] meetings;
        public int TotalTime
        {
            get
            {
                int sum = 0;
                for (int i = 0; i < meetings.Length; i++)
                {
                    sum += meetings[i].Time;
                }
                return sum;
            }
        }
        public string ClientName { get { return clientName; } }
        public DifficultyLevels Difficulty { get { return difficulty; } }
        public string CaseName { get{ return caseName; } }
        public Meeting[] Meetings { get { return meetings; } }
        public Case(string clientName, string caseName, DifficultyLevels difficulty)
        {
            this.clientName = clientName;
            this.caseName = caseName;
            this.difficulty = difficulty;
        }
        private void store(Meeting meeting)
        {
            int i = 0;
            while (i<meetings.Length && meetings[i]!=null)
            {
                i++;
            }
            if (i<meetings.Length)
            {
                meetings[i] = meeting;
            }
        }
        public void processsData(string[] descriptions, string[] times)
        {
            int size = descriptions.Length;
            meetings = new Meeting[size];
            for (int i = 0; i < size; i++)
            {
                string description = descriptions[i];
                int time = int.Parse(times[i]);
                store(new Meeting(description, time));
            }
        }
        public Meeting[] longSession()
        {
            int threshold = 30;
            int count = 0;
            for (int i = 0; i < meetings.Length; i++)
            {
                count++;
            }
            Meeting[] result = new Meeting[count];
            int j = 0;
            for (int i = 0; i < meetings.Length; i++)
            {
                result[j] = meetings[i];
                j++;
            }
            return result;
        }
        public int Billing()
        {
            int sum = 0;
            double multipliers = (int)difficulty * 0.5;
            for (int i = 0; i < meetings.Length; i++)
            {
                int time = meetings[i].Time;
                sum = sum + (int)(time * 1 * multipliers);
            }
            return sum;
        }

    }
}
