using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    protected override void InitStats()
    {
        base.InitStats();

        //Stats.MaxHealthStat = new EntityStat(this, 100);
        //Stats.Damage= new EntityStat(this, 100);
        //Stats.Armor= new EntityStat(this, 100);
        //Stats.MovePointStat = new EntityStat(this, 100);
        //Stats.Range = new EntityStat(this, 100);
        //Stats = new EntityStat(this, 200);



        //Stats.MaxHealthStat.BaseFlatValue = 200;
        //Stats.DamageStat.BaseFlatValue = 60;
        //Stats.ArmorStat.BaseFlatValue = 20;
        //Stats.MovePointStat.BaseFlatValue = 4;
        Stats.Range = new EntityStat(this, 200);
        UnitName = "Player";

    }
}
