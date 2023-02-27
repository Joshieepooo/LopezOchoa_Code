using System;

namespace LopezOchoaFinals
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Employee Time Keeping");
                Console.WriteLine("<------<<< >>>------>" + "\n\n");
                Console.WriteLine("Instructions:");
                Console.WriteLine("Military Time Only \nMake sure you don't input any letters \nMake Sure to Add ':' between Hr and Min \nAdd 'Mr.' or 'Ms.' at the start of your name \nYou can Include '0' in the start of solo numbers");
                Console.WriteLine("<--------------------<<< >>>------------------->" + "\n\n");
                Console.WriteLine("08:00 - 17:00 is the Regular Work Hours \n30 Minutes late is not really considered as late\n\n\n");

                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Enter Time-In (HH:MM): ");
                string timeIn = Console.ReadLine();
                Console.Write("Enter Time-Out (HH:MM): ");
                string timeOut = Console.ReadLine();

                string[] timeInSplitter = timeIn.Split(':');
                string[] timeOutSplitter = timeOut.Split(':');

                int timeInHr = int.Parse(timeInSplitter[0]);
                int timeInMnt = int.Parse(timeInSplitter[1]);
                int timeOutHr = int.Parse(timeOutSplitter[0]);
                int timeOutMnt = int.Parse(timeOutSplitter[1]);

                if (timeInHr < 0 || timeInHr > 23 || timeInMnt < 0 || timeInMnt > 60)
                {
                    Console.WriteLine("\nInvalid Time-In or Out");
                    return;
                }

                if (timeOutHr < 0 || timeOutHr > 23 || timeOutMnt < 0 || timeOutMnt > 60)
                {
                    Console.WriteLine("\nInvalid Time-In or Out");
                    return;
                }

                int totalHr1phs = timeOutHr - timeInHr;
                int totalMnt = timeOutMnt - timeInMnt;

                //Lunch Time is not included in both Hours
                int totalHr2phs = totalHr1phs - 1;
                int rglrHr = totalHr1phs - 1;

                /* Please Don'T Get Confused  
                 * '<' is LESS THANNNN!
                 * '>' is GREATER THANNNNN!
                */

                //00:00 = 12:00 & 23:59 = 11:59 REMEMBER!
                if (totalHr2phs >= 0 && totalHr2phs < 24)
                {
                    Console.WriteLine("\n" + name + " Here's Your Work Time Progress For This Day: \n");
                    Console.WriteLine("Total Hours: " + totalHr2phs + "Hrs");
                    Console.WriteLine("Regular Hours: " + rglrHr + "Hrs");
                }

                //Time-In greater than 08:00 will be considered as late
                //grace time is 30 minutes so 8:30 is not included in late time
                if (timeInHr > 8 || timeInMnt > 30)
                {
                    Console.WriteLine("Late Time: " + (timeInHr - 8) + "Hr/s & " + (timeInMnt - 30) + "Min/s");
                }

                //Time-Out less than 17:00 is considered as Under Time
                if (timeOutHr < 17)
                {
                    Console.WriteLine("Under Time: " + (17 - timeOutHr) + "Hr/s & " + (60 - timeOutMnt) + "Min/s");
                }

                //Time-Out greater than 17:00 is considered as Over Time
                if (timeOutHr >= 17 && timeOutHr < 24 && timeOutMnt > 0 && timeOutMnt <= 60)
                {
                    Console.WriteLine("Over Time: " + (timeOutHr - 17) + "Hr/s & " + timeOutMnt + "Min/s");
                }
                
                Console.Write("\nDo you want to continue? (Y/N): ");
                string answer = Console.ReadLine();
                if (answer.ToLower() != "y")
                {
                    break;
                }
            }
           
            Console.WriteLine("\n\n\n\n\n");
            Console.ReadKey();
        }
    }
}
