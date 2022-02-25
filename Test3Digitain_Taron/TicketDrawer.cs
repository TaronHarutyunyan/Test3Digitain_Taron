using System;

namespace Test3Digitain_Taron
{
    internal class TicketDrawer : ITicketDrawer
    {

        public void Draw(ITicket t)
        {
            Console.Clear();
            Console.WriteLine("-----------------------");

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"|   *    |    *    |");
                Console.WriteLine("-----------------------");
            }
        }
        public void Redraw(ITicket t, int level)
        {
            Console.Clear();
            Console.WriteLine("------------------------");
            for (int i = 1; i < 11; i++)
            {
                if(i <= level)
                {
                    Console.WriteLine($"|         {200*i}         |");
                    Console.WriteLine("-----------------------");
                }
                else
                {                  
                    Console.WriteLine($"|   *    |    *    |");
                    Console.WriteLine("-----------------------");
                    
                }
            }
        }
    }
}
