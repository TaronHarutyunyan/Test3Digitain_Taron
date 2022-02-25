using System;

namespace Test3Digitain_Taron
{
    internal interface IPlayer
    {
        string UserName { get; set; }
        int Result { get; set; }
        int AvailableGames { get; set; }
        DateTime LastLoginTime { get; set; }
    }
}
