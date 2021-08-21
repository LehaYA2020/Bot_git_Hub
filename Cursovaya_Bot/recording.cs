using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cursovaya_Bot
{
    public class recording
    {
        public long peerId { get; }
        public Gym gym { get; }
        public DateTime date { get; set; }


        public recording(long peerId, Gym gym)
        {
            this.peerId = peerId;
            this.gym = gym;
        }

        public bool checkDate(DateTime date)
        {
            DateTime NowDate = DateTime.Now;
            if (gym.timetable.Contains(date.ToString("ddd")) && date >= NowDate)
            {
                this.date = date;
                return true;
            }
            return false;
        }
    }
}
