using GrappleHook.util;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float lifeTime;

    private void OnEnable()
    {
        Destroy(gameObject, lifeTime);
    }

    private void Update()
    {
        if (GameManager.instance.gameState != GameStates.playing) return;
        var oldPos = transform.position;
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D hit = Physics2D.Linecast(oldPos, transform.position);
        if (hit && hit.collider.CompareTag(Config.TAG_BREACKABLE))
        {
            Destroy(hit.collider.gameObject);
            Destroy(gameObject);
        }
    }
}