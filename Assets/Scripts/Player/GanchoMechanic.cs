using GrappleHook.util;
using System.Collections;
using UnityEngine;

public class GanchoMechanic : MonoBehaviour
{
    private const float MAXTIMEACTIVE = 1f;
    private const float RAYDISTANCE = 1f;

    [SerializeField] private PlayerController playerController;
    [SerializeField] private bool acting;
    [SerializeField] private float maxDistance;
    [SerializeField] private Transform HookHead;
    [SerializeField] private float speed;
    [SerializeField] private float minDistanceOfRealize;
    [SerializeField] private Vector2 posStartRay;
    [SerializeField] private Vector3 launchAngle;

    private void Update()
    {
        if (Input.GetButton(Config.BUTTON_ACTION) && !acting)
        {
            if (playerController.GetFacing() < 0)
            {
                HookHead.rotation = Quaternion.Euler(new Vector3(launchAngle.x, -180, launchAngle.z));
            }
            else
            {
                HookHead.rotation = Quaternion.Euler(new Vector3(launchAngle.x, 0, launchAngle.z));
            }
            acting = true;
            StartCoroutine(IGrappleHook());
        }
        if (!acting)
        {
            HookHead.position = transform.position;
        }
    }

    private IEnumerator IGrappleHook()
    {
        while (Vector3.Distance(transform.position, HookHead.position) < maxDistance)
        {
            Vector2 origin = (Vector2)HookHead.position + posStartRay;
            RaycastHit2D hit = Physics2D.Raycast(origin, HookHead.up, RAYDISTANCE);
            if (hit)
            {
                if (hit.collider.CompareTag(Config.TAG_GANCHO))
                {
                    StartCoroutine(IMovePlayer(hit.collider.transform.position));
                    break;
                }
            }
            yield return null;
            HookHead.Translate(Vector2.right * speed * Time.deltaTime);
        }
        acting = false;
        StopCoroutine("IMovePlayer");
    }

    private IEnumerator IMovePlayer(Vector3 _hookPos)
    {
        StopCoroutine(IGrappleHook());
        float timeLeft = MAXTIMEACTIVE;
        HookHead.position = _hookPos;
        Debug.Log("Start");
        playerController.DisableMovement();

        while (Vector3.Distance(transform.position, _hookPos) > minDistanceOfRealize)
        {
            transform.position = Vector3.Slerp(transform.position, _hookPos, speed * Time.deltaTime);
            timeLeft -= Time.deltaTime;
            if (timeLeft <= 0) break;
            yield return null;
        }
        playerController.EnableMovement();
        acting = false;
    }

    private void OnEnable()
    {
        HookHead.gameObject.SetActive(true);
    }

    private void OnDisable()
    {
        HookHead.gameObject.SetActive(false);
    }
}