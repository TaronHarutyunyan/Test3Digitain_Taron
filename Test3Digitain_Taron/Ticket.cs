using System;
using System.Collections.Generic;

namespace Test3Digitain_Taron
{
    internal class Ticket : ITicket
    {
        public Ticket()
        {
            RigthChoice = GetAnswers();
            Log log = Log.GetInstance();
            log.Write("Ticket Created");
        }

        private Dictionary<int, LeftOrRigth> GetAnswers()
        {
            Dictionary<int, LeftOrRigth> lanswers = new Dictionary<int, LeftOrRigth>();
            Random random = new Random();
            for (int i = 1; i <=10 ; i++)
            {
                lanswers.Add(i, (LeftOrRigth)random.Next(1, 3));
            }
            return lanswers;

        }
        public Dictionary<int, LeftOrRigth> RigthChoice { get; set; } = new Dictionary<int, LeftOrRigth>();
    }
}
