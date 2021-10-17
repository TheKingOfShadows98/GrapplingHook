using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniqueObjects : MonoBehaviour
{
    public static UniqueObjects instance;
    private void Awake()
    {
        if(UniqueObjects.instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
