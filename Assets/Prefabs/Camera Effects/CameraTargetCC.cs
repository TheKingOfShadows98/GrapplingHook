using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTargetCC : MonoBehaviour
{
#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(minPos, new Vector2(minPos.x, maxPos.y));
        Gizmos.DrawLine(new Vector2(maxPos.x, minPos.y), minPos);
        Gizmos.DrawLine(maxPos, new Vector2(maxPos.x, minPos.y));
        Gizmos.DrawLine(new Vector2(minPos.x, maxPos.y), maxPos);
    }

#endif
    /*TODO 
     * [-]Debe seguir al Player.
     * [-]Debe tener Maximos y minimos.
     * [-]Debe Poder Cambiar los Maximos y Minimos.
     * [-]Debe poder frezzear los ejes.
    */
    [SerializeField] private Vector2 minPos;
    [SerializeField] private Vector2 maxPos;

    private bool frezzeX;
    private bool frezzeY;

    [field:SerializeField] public Transform Player { get; set; }

    private void Update()
    {
        Vector2 _pos = transform.position;

        if(!frezzeX)
        _pos.x = Player.position.x < minPos.x ?
            minPos.x : Player.position.x > maxPos.x ?
            maxPos.x : Player.position.x;

        if(!frezzeY)
        _pos.y = Player.position.y < minPos.y ?
           minPos.y : Player.position.y > maxPos.y ?
           maxPos.y : Player.position.y;

        transform.position = _pos;
    }


    public void ChangeMinPos(Vector2 min )
    {
        minPos = min;
    }
    public void ChangeMaxPos(Vector2 max )
    {
        maxPos = max;
    }
    public void FrezzeX (float position)
    {
        frezzeX = true;
        transform.position = new Vector2(position, transform.position.y) ;
    }

    public void FrezzeY(float position)
    {
        frezzeY = true;
        transform.position = new Vector2(transform.position.x , position);
    }

    public void UnFrezzeX() { frezzeX = false; }
    public void UnFrezzeY() { frezzeY = false; }

}
