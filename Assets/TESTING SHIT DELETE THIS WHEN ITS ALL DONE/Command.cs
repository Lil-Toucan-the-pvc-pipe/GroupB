using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Command
{
    public Command()
    {}

    public virtual void Execute()
    {}
}

public class PumpCommand : Command
{
    /*protected*/
    Player _xPlayer;
    public PumpCommand(Player _xPlayer) : base()
    {
        this._xPlayer = _xPlayer;
    }

    public override void Execute()
    {
        _xPlayer.aAnimator.Play("PUMPING IRON");
    }
}

//public class AddPointCommand : Command
//{
//    PointsHandler _xPoints;
//    public AddPointCommand(PointsHandler _xPoints) : base()
//    {
//        this._xPoints = _xPoints;
//    }
//}
