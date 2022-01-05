using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GrapplingHook.Player;

public enum BallStates
{
    idle,
    falling,
    dashing,
}
public class BallCC : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigid;
    [SerializeField] private float speed;

    [SerializeField] private float timefall;
    private float timer;
    private BallStates state;
    // Start is called before the first frame update
    void Start()
    {
        state = BallStates.falling;
        rigid.gravityScale = 3;
        timer = Time.time + timefall;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer <= Time.time)
        {
            if (state == BallStates.idle)
            {
                rigid.velocity = Vector2.zero;
                state = BallStates.falling;
                timer += 0.5f;
            }else
            if (state == BallStates.falling)
            {
                state = BallStates.dashing;
                timer += 2f;
            }else
            if (state == BallStates.dashing)
            {
                state = BallStates.idle;
                timer += 3f;
            }

        }
        switch (state)
        {
            case BallStates.dashing:
                {
                    Dash();
                    break;
                }
            case BallStates.idle:
                {
                    Idle();
                    break;
                }
            case BallStates.falling:
                {
                    Fall();
                    break;
                }
        }
    }
    void Idle()
    {
        rigid.gravityScale = -0.1f;
        var a = GameManager.Instance.GetPlayerPosition().x - transform.position.x;
        if (a < 0) transform.rotation = Quaternion.Euler(0, 180, 0);
        else transform.rotation = Quaternion.Euler(0, 0, 0);
        rigid.drag = 0.5f;
    }
    void Fall()
    {
        rigid.gravityScale = 3;
        rigid.drag = 0;
    }
    void Dash()
    {
        rigid.velocity = new Vector2(speed * transform.right.x, rigid.velocity.y);
        rigid.gravityScale = 1;
        
    }
}
