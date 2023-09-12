using System;
using System.Collections;

namespace Exam1_cs
{
    public class ManagementDrivers<T>
    {
        public T[] Drivers { get; set; }

        public void SortDrivers() => Array.Sort(Drivers);

        public string[] WhereIsNow()
        {
            string[] where = new string[Drivers.Length];
            for(int i =0; i<where.Length; i++)
                where[i] = $"{(Drivers[i] as IPerson).Firstname} is on {(Drivers[i] as ILocatable).X} situation.";
            return where;    
        }

        public void NearestDriver(Customer c, Place p)
        {
            (T d, long min) = (Drivers[0], (Drivers[0] as ILocatable).Distance(c));
            foreach (T driver in Drivers)
            {
                if((driver as ILocatable).Distance(c) < min)
                    (d, min) = (driver, (driver as ILocatable).Distance(c));
            }
            (d as IDriver).GoToTarget(c, p);
        }
    }
}