using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    protected override void InitStats()
    {
        Stats.MaxHealthStat = new EntityStats(this, 100);
        Stats.DamageStat = new EntityStats(this, 100);
        Stats.ArmorStat = new EntityStats(this, 100);
        Stats.MovePointStat = new EntityStats(this, 100);
        Stats.Range = new EntityStats(this, 100);
        Stats = new EntityStats(this, 200);
        //Stats.MaxHealthStat.BaseFlatValue = 200;
        //Stats.DamageStat.BaseFlatValue = 60;
        Stats.ArmorStat.BaseFlatValue = 20;
        Stats.MovePointStat.BaseFlatValue = 4;
        Stats.Range = 1;
        UnitName = "Player";

        base.InitStats();
    }
}
