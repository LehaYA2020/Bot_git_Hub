using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cursovaya_Bot
{
    public class Gym
    {
        public string name { get; }
        public List<string> timetable = new List<string>();



        public Gym(string name)
        {
            this.name = name;
            CreateTimetable();
        }
        private void CreateTimetable()
        {
            if (name == "электросила")
            {
                timetable.Add("Wed");
                timetable.Add("Fri");
                timetable.Add("Mon");
            }
            if (name == "большевиков")
            {
                timetable.Add("Tue");
                timetable.Add("Thu");
                timetable.Add("Sat");
            }
        }
    }
}
