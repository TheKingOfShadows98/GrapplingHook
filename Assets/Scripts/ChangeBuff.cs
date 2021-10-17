using GrappleHook.util;
using UnityEngine;

public class ChangeBuff : MonoBehaviour
{
    [SerializeField] private PowerUps buff;
    [SerializeField] private Animator animator;
    [SerializeField] private string TriggerName;
    [SerializeField] private SpriteRenderer sprite;
    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        sprite.color = GameManager.instance.powerUps[buff] ? Color.white : Config.ColorDisable;
    }
    private void FixedUpdate()
    {

        sprite.color = GameManager.instance.powerUps[buff] ? Color.white : Config.ColorDisable;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Config.TAG_PLAYER) && GameManager.instance.powerUps[buff])
        {
            collision.GetComponent<PlayerController>().ChangeBuff(buff);
            if (animator) animator.SetTrigger(TriggerName);
        }
    }
}