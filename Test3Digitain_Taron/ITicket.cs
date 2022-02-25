using System.Collections.Generic;

namespace Test3Digitain_Taron
{
    public enum LeftOrRigth
    {
        Left = 1,Right
    }
    internal interface ITicket
    {
        Dictionary<int,LeftOrRigth> RigthChoice { get; set; }
        
    }
}
