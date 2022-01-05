using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnFrezzeCam : MonoBehaviour
{
    [SerializeField] private bool unFrezzeX;
    [SerializeField]private bool unFrezzeY;


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (unFrezzeX)
        {
            GameManager.Instance.CameraTarget.UnFrezzeX();
        }
        if (unFrezzeY)
        {
            GameManager.Instance.CameraTarget.UnFrezzeY();
        }
    }
}
