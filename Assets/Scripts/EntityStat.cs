using Unity.Mathematics;
using UnityEngine;

public class EntityStat
{
    private Entity _entity;
    public EntityStat(Entity p_Entity)
    {
        _entity = p_Entity;
    }

    public EntityStat(Entity p_Entity, float p_BaseFlatValue)
    {
        _entity = p_Entity;
        _baseFlatValue = 0;
        _percentageValue = 0;
        _tempFlatValue = 0;
        _tempPercentageValue = 0;
    }

    public float Value => (_baseFlatValue + _tempFlatValue) * (1 + (_percentageValue + _tempPercentageValue) / 100);

    private float _baseFlatValue;
    private float _tempFlatValue;
    private float _percentageValue;
    private float _tempPercentageValue;


    public float BaseFlatValue
    {
        get
        {
            return _baseFlatValue;
        }
        set
        {
            _baseFlatValue = value;
            //GlobalUIManager.Instance.RefreshUnitInfosPanel(_entity);
        }
    }

    public float TempFlatValue
    {
        get
        {
            return _tempFlatValue;
        }
        set
        {
            _tempFlatValue = value;
            //GlobalUIManager.Instance.RefreshUnitInfosPanel(_entity);
        }
    }

    public float PercentageValue
    {
        get
        {
            return _percentageValue;
        }
        set
        {
            _percentageValue = value;
            //GlobalUIManager.Instance.RefreshUnitInfosPanel(_entity);
        }
    }

    public float TempPercentageValue
    {
        get
        {
            return _tempPercentageValue;
        }
        set
        {
            _tempPercentageValue = value;
            //GlobalUIManager.Instance.RefreshUnitInfosPanel(_entity);
        }
    }

    public void Reset()
    {
        TempPercentageValue = 0;
        TempFlatValue = 0;
    }
}