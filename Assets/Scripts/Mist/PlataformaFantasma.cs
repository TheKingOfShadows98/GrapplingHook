using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaFantasma : MonoBehaviour
{

    void FixedUpdate()
    {
        var visble = GameManager.Instance.GetPlayerHeigth() > (transform.position.y + transform.localScale.y / 2 );
            try
            {
            GetComponent<Collider2D>().enabled = visble;
            }
            catch
            {
                Debug.Log("No Existe Collider");
            }
    }
}
