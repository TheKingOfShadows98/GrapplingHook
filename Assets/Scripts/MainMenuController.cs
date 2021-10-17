using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    private const string PARAMTRIGGER = "Start";
    private const float TIMETOACTIVE = 3f;
    [SerializeField] private Animator animator;
    [SerializeField] private float timepass = 0;
    [SerializeField] private bool active;

    private void Awake()
    {
        timepass = 0;
    }

    private void Update()
    {
        if (timepass > TIMETOACTIVE)
        {
            if (Input.anyKey && !active)
            {
                animator.SetTrigger(PARAMTRIGGER);
                active = true;
                timepass = 0;
            }
        }
        else
        {
            timepass += Time.deltaTime;
        }
        if (active && timepass > 2f)
        {
            GameManager.instance.PauseGame(false);
            this.enabled = false;
        }
        else { timepass += Time.deltaTime; }
    }
}