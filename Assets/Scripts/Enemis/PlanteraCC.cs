using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer
{
    public Timer()
    {

    }
    public float time { get; private set; }
    public void start( float _time)
    {
        time = Time.time + _time;
    }
    public bool isReady()
    {
        return time <= Time.time;
    }
}
public enum stados
{
    idle,
    moving,
    attacking,
    dead
}
public class PlanteraCC : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rigid;
    [SerializeField] private GameObject hitbox;


    [Header("Move and Idle")]
    [SerializeField] private float speed;
    [SerializeField] private float maxTargetThreshold;
    [SerializeField] private float mindistance;
    [SerializeField] private float iddleTime;
     private float target;

    private Timer iddleTimer = new Timer();

    [Header("Attacking and distance detection")]

    [SerializeField] private float maxDetectionRange;
    [SerializeField] private float attack;
    [SerializeField] private float attackCD;

    private Timer attackTimer = new Timer();

    private stados state = stados.idle;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case stados.idle:
                {
                    MoveTo();
                    break;
                }
            case stados.moving:
                {
                    Move();
                    if (iddleTimer.isReady()) state = stados.idle;
                    break;
                }
        }

    }
    void HideHitBox()
    {
        hitbox.transform.position = (transform.position + (Vector3.down * 2));
    }
    void ShowHitBox()
    {
        hitbox.transform.position = (transform.position );
    }
   
    void MoveTo()
    {
        target = transform.position.x + Random.Range(-maxTargetThreshold, maxTargetThreshold);
        iddleTimer.start(iddleTime);
        state = stados.moving;
        HideHitBox();
    }

    void Move()
    {
        if(target - transform.position.x < 0)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        if(Mathf.Abs(target - transform.position.x) > mindistance)
        {
            rigid.velocity = new Vector2(
                transform.right.normalized.x * speed,
                rigid.velocity.y
                );
        }
        else
        {
            rigid.velocity = new Vector2(0f, rigid.velocity.y);
            ShowHitBox();
        }
    }
    void Attack()
    {

    }
}
