using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZIndexAutoAjust : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sp;
    void Start()
    {
        if (!sp) sp = GetComponent<SpriteRenderer>();
        Sort();
    }

    [ContextMenu("Sort")]
    public void Sort()
    {
        sp.sortingOrder = -Mathf.FloorToInt(transform.position.z * 10);
    }

}
