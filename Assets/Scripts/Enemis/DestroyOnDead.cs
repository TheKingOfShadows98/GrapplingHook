using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnDead : MonoBehaviour
{
    [SerializeField] LifeController lc;
    [SerializeField] AudioSource a;

    private void Start()
    {
        if (lc) lc.addListener(Dead);
    }

    public void Dead(LifeState state)
    {
        if (state.Equals(LifeState.Dead)) {
            a.Play();
            Destroy(gameObject, 0.5f);
        }
    }
}
