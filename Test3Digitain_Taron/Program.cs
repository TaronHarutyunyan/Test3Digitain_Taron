using System;
using System.Collections.Generic;

namespace Test3Digitain_Taron
{
    internal class Program
    {
        public static List<IPlayer> Players = new List<IPlayer>();
        public static IPlayer CurrentPlayer = null;
        static void Main(string[] args)
        {
            try
            {
                Run();
            }
            catch (PlayerDontHaveAnyAvailableGamesException e)
            {
                Log log = Log.GetInstance();
                log.Write($"Player Dont Have Any Available Games {e.StackTrace}");
            }
            catch (EmptyUserNameException e)
            {
                Log log = Log.GetInstance();
                log.Write($"Empty User Name {e.StackTrace}");
            }
            catch(Exception e)
            {
                Log log = Log.GetInstance();
                log.Write($"Some Exception {e.StackTrace}");
            }
        }
        public static void Run()
        {
            while (true)
            {
                ShowLogInMenu();
                StartGame();
            }
        }
        public static void StartGame()
        {
            CurrentPlayer.AvailableGames -= 1;
            ITicket ticket = new Ticket();
            ITicketDrawer ticketDrawer = new TicketDrawer();
            ticketDrawer.Draw(ticket);
            int currentposition = 1;
            Console.WriteLine("ENTER 1 FOR LEFT | ENTER 2 FOR RIGTH  | ENTER 0 TO EXIT WITH YOUR CURRENT MONEY ");
            bool isplaying = true;
            while (isplaying)
            {
                string linput = Console.ReadLine();
                switch (linput)
                {
                    case "1":
                        if(ticket.RigthChoice[currentposition] == (LeftOrRigth)1)
                        {
                            CurrentPlayer.Result += currentposition * 200;
                            ticketDrawer.Redraw(ticket, currentposition);
                            currentposition++;
                        }
                        else
                        {
                            Console.WriteLine("YOU LOSE");
                            Console.WriteLine("PRESS ANY KEY TO CONTINUE");
                            Console.ReadLine();
                            Run();
                        }
                        break;
                    case "2":
                        if (ticket.RigthChoice[currentposition] == (LeftOrRigth)1)
                        {
                            CurrentPlayer.Result += currentposition * 200;
                            ticketDrawer.Redraw(ticket, currentposition);
                            currentposition++;
                        }
                        else
                        {
                            Console.WriteLine("YOU LOSE");
                            Console.WriteLine("PRESS ANY KEY TO CONTINUE");
                            Log log = Log.GetInstance();
                            log.Write("Player Lose");
                            Console.ReadLine();
                            Run();
                            isplaying = false;
                        }
                        break;
                    case "0":
                        Console.WriteLine($"YOU HAVE WON {currentposition * 200} MONEY");
                        break;
                    default:
                        break;
                }
            }
            
        }
        
        public static void ShowLogInMenu()
        {
            Console.Clear();
            Console.WriteLine("Please Enter Your UserName");
            string luserName = Console.ReadLine();
            if (luserName == null) throw new EmptyUserNameException();
            if(!CkeckUserName(luserName)) CurrentPlayer = new Player(luserName);
            if (CurrentPlayer.LastLoginTime.AddHours(24) == DateTime.Now) CurrentPlayer.AvailableGames = 3;
            CurrentPlayer.LastLoginTime = DateTime.Now;
            Console.WriteLine($"YOU HAVE {CurrentPlayer.AvailableGames} AVAILABLE GAMES \nPress any key to start a game");
            Console.ReadLine(); 
        }
        public static bool CkeckUserName(string luserName)
        {            
            foreach (var item in Players)
            {
                if (item.UserName == luserName)
                {
                    CurrentPlayer = item;
                    if (CurrentPlayer.AvailableGames == 0) throw new PlayerDontHaveAnyAvailableGamesException();
                    return true;
                }
            }
            return false;
        }
        
    }
}
