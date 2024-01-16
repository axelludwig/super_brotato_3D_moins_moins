using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityStats
{
    public EntityStats(Entity p_Entity)
    {
        _entity = p_Entity;
        //MaxHealthStat = new EntityStat(_entity);
        //Damage = new EntityStat(_entity);
        //Armor = new EntityStat(_entity);
        //MovePointStat = new EntityStat(_entity);

        Damage = new EntityStat(_entity, 100);
        Armor= new EntityStat(_entity, 100);
        MovePointStat = new EntityStat(_entity, 100);
        Range = new EntityStat(_entity, 100);
        //Stats = new EntityStat(_entity, 200);
    }

    private Entity _entity;

    public EntityStat MaxHealthStat { get; set; }
    public EntityStat HealthRegen { get; set; }

    public float Health { get; set; }
    public float HealthPercentage => Health / MaxHealthStat.Value;

    public EntityStat Damage { get; set; }
    public EntityStat Armor { get; set; }
    public EntityStat AttackSpeed { get; set; }

    public EntityStat Luck { get; set; }
    public EntityStat Range { get; set; }
    public EntityStat CritChance { get; set; }
    public EntityStat CritDamage { get; set; }

    public EntityStat LifeSteal { get; set; }
    public EntityStat ElementalDamage { get; set; }

    #region MovePoints

    public EntityStat MovePointStat { get; set; }
    public short MovePoints => MovePointStat.Value >= 0 ? (short)MovePointStat.Value : (short)0;
    public short CurrentMovePoints { get; set; }

    #endregion

    //public int Range { get; set; }
    //public int Lead { get; set; }
    //public short MaxSummonNumber { get; set; }
    //public int MoneyValue => Mathf.RoundToInt((MaxHealthStat.BaseFlatValue / 100 + Damage.BaseFlatValue / 50 + Armor.BaseFlatValue / 20 + MovePoints / 3) * SpawnPower * 0.5f);

    //public int SpawnPower { get; set; }

}