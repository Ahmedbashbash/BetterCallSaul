using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace SwDD1_ME2_Sample
{
    static class Calendar
    {
        static Case[] cases;
        static string calendarFile;
        public static string CalendarFile
        {
            get { return calendarFile; }
            set 
            {
                if (value.Length > 4 && value.Split('.')[1]=="cal")
                {
                    calendarFile = value;
                }
            }
        }
        public static void LoadCalendar()
        {
            string[] allLines = File.ReadAllLines(calendarFile);
            cases = new Case[allLines.Length];
            for (int i = 0; i < allLines.Length; i++)
            {
                string line = allLines[i];
                string clientName = line.Split('@')[1].Split(':')[0];
                string deficulty = line.Split('@')[1].Split(':')[2];
                DifficultyLevels difficultyLevel;
                if (deficulty== "easypeasy")
                {
                    difficultyLevel = DifficultyLevels.easypeasy;
                }
                else if (deficulty == "average")
                {
                    difficultyLevel = DifficultyLevels.average;
                }
                else if (deficulty == "nightmare")
                {
                    difficultyLevel = DifficultyLevels.nightmare;
                }
                else
                {
                    difficultyLevel = DifficultyLevels.ultramegahard;
                }
                string caseName = line.Split('@')[0];
                string[] descriptions= line.Split('@')[1].Split(':')[1].Split(';')[0].Split(',');
                string[] times = line.Split('@')[1].Split(':')[1].Split(';')[1].Split(',');
                Case newCase = new Case(clientName, caseName, difficultyLevel);
                newCase.processsData(descriptions, times);
                cases[i] = newCase; 
            }
        }
        public static int CalculateTotalIncome()
        {
            int sum = 0;
            for (int i = 0; i < cases.Length; i++)
            {
                sum += cases[i].Billing();
            }
            return sum;
        }
        public static string FavoriteClient()
        {
            string name = "none";
            int MaxLongSession = 0;
            for (int i = 0; i < cases.Length; i++)
            {
                if (cases[i].longSession().Length>MaxLongSession)
                {
                    name = cases[i].ClientName;
                    MaxLongSession = cases[i].longSession().Length;
                }
            }
            return name;
        }
        public static void saveFile()
        {
            string fileName = "out.txt";
            string data = CalculateTotalIncome() + "," + FavoriteClient();
            File.WriteAllText(fileName, data);
        }
        public static void saveAllData()
        {
            string fileName = "out.txt";
            for (int i = 0; i < cases.Length; i++)
            {
                Case currentCase=cases[i];
                string content = $"{currentCase.ClientName} - {currentCase.CaseName}\n  Difficulty of case: {currentCase.difficulty}\n  Total meetings: {currentCase.Meetings.Length} meetings, {currentCase.TotalTime} minutes\n  Total cost: ${currentCase.Billing()} \n";
                File.AppendAllText(fileName, content);
            }
        }
    }
}
