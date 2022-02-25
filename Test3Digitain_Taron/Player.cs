using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test3Digitain_Taron
{
    internal class Player : IPlayer
    {
        public Player()
        {
        }

        public Player(string userName)
        {
            UserName = userName;
            Result = 0;
            AvailableGames = 3;
            LastLoginTime = DateTime.Now;
            Log log = Log.GetInstance();
            log.Write("Player Created ");
        }

        public string UserName { get; set; }
        public int Result { get;set; }
        public int AvailableGames { get; set; }
        public DateTime LastLoginTime { get; set; }
        
        
    }
}
