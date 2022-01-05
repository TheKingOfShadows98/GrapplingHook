using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrezzeCamTrigger : MonoBehaviour
{
    public float position;
    public bool frezzeX;
    public bool frezzeY;


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (frezzeX)
        {
            GameManager.Instance.CameraTarget.FrezzeX(position);
        }
        if (frezzeY)
        {
            GameManager.Instance.CameraTarget.FrezzeY(position);
        }
    }

}
