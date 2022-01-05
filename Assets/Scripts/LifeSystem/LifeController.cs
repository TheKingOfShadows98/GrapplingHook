using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public enum LifeState
{
    Damage,
    Dead
}

public class LifeController : MonoBehaviour
{
    [field: SerializeField] public int Life { get; private set; }
    [field: SerializeField] public int Defense { get; private set; }
    [field: SerializeField] private Action<LifeState> Listeners;

    
    public void TakeDamage( int damage)
    {
        Debug.Log(damage);
        int realDamage = damage - Defense;
        realDamage = realDamage > 0 ? realDamage : 0;
        Life -= realDamage;
        if(Life > 0)
            ActiveListener(LifeState.Damage);
        else
        {
            ActiveListener(LifeState.Dead);
        }
    }




    public void addListener(Action<LifeState> method)
    {
        Listeners += method;
    }

    public void removeListener(Action<LifeState> method)
    {
        Listeners -= method;
    }

    public void ActiveListener(LifeState call)
    {
        if(Listeners != null)
        {
            Listeners.Invoke(call);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
