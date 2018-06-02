using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Best_Lectures_Schedule
{
    class Lecture : IComparable<Lecture>
    {
        public string LectureName { get; set; }
        public int StartHour { get; set; }
        public int EndHour { get; set; }

        public Lecture(string lectureName, int startHour, int endHour)
        {
            this.LectureName = lectureName;
            this.StartHour = startHour;
            this.EndHour = endHour;
        }

        public int CompareTo(Lecture other)
        {
            int compare = this.EndHour.CompareTo(other.EndHour);
            if (compare == 0)
            {
                return this.StartHour.CompareTo(other.StartHour);
            }
            return compare;
        }
    }
    class Program
    {
        static List<Lecture> lectures = new List<Lecture>();
        static HashSet<Lecture> result = new HashSet<Lecture>();

        static void Main(string[] args)
        {
            var lectureInfo = Console.ReadLine().Split(' ').ToArray();
            var numberOfLectures = int.Parse(lectureInfo[1]);
            for (int i = 0; i < numberOfLectures; i++)
            {
                var argsInfo = Console.ReadLine().Split(' ').ToArray();
                var lectureName = argsInfo[0].Split(':').ToArray()[0];
                var startHour = int.Parse(argsInfo[1]);
                var endHour = int.Parse(argsInfo[3]);
                var lecture = new Lecture(lectureName, startHour, endHour);
                lectures.Add(lecture);
            }

            GetPossibleLectures();
            Print();
        }

        private static void Print()
        {
            Console.WriteLine($"Lectures ({result.Count}):");
            foreach (var item in result)
            {
                Console.WriteLine($"{item.StartHour}-{item.EndHour} -> {item.LectureName}");
            }
        }

        private static void GetPossibleLectures()
        {
            
            lectures.Sort();
            var startTime = lectures[0].StartHour;
            var endTime = lectures[0].EndHour;
            result.Add(lectures[0]);
            for (int i = 1; i < lectures.Count; i++)
            {
                if (lectures[i].StartHour >= endTime)
                {
                    result.Add(lectures[i]);
                    startTime = lectures[i].StartHour;
                    endTime = lectures[i].EndHour;
                }
            }
        }
    }
}
