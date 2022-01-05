using UnityEngine;

namespace GrapplingHook.Player
{
    public class SaltoP : MonoBehaviour
    {
        [field: SerializeField] private float JumpForce { get; set; }
        [field: SerializeField] private Rigidbody2D Rig { get; set; }

        [SerializeField] Animator animator;

        [Header("Parametros de configuración")]
        [Range(0, 1), SerializeField] private float coyoteTime;
        [SerializeField] private float LineDistance;

        [SerializeField] private string GroundTag;
        [SerializeField] private AudioSource audioSource;

        [SerializeField] private ParticleSystem jumpParticleSystem;
        [field: SerializeField] public float lineHeightOffset { get; private set; }
        [SerializeField, Range(0.1f, 1f)] private float maxTimeJump;

        [Header("Sound Pitch")]
        [SerializeField]
        private float minPitch;
        [SerializeField]
        private float maxPitch;


        public float timewindowJump { get; private set; }
        public float timeEndJump { get; private set; }

#if UNITY_EDITOR

        private void OnDrawGizmos()
        {
            Vector2 start = (Vector2)transform.position + (Vector2.down * lineHeightOffset) + Vector2.left * (LineDistance / 2);
            Vector2 end = (Vector2)transform.position + (Vector2.down * lineHeightOffset) + Vector2.right * (LineDistance / 2);
            Gizmos.color = Color.red;
            Gizmos.DrawLine(start, end);
            start = (Vector2)transform.position + (Vector2.up * lineHeightOffset) + Vector2.left * (LineDistance / 2);
            end = (Vector2)transform.position + (Vector2.up * lineHeightOffset) + Vector2.right * (LineDistance / 2);
            Gizmos.color = Color.red;
            Gizmos.DrawLine(start, end);
        }

#endif

        private void Update()
        {
            if (Input.GetButtonDown("Jump") && stayGround())
            {
                timeEndJump = Time.time + maxTimeJump;
                jumpParticleSystem.Play();
                
                audioSource.Stop();
                audioSource.pitch = Random.Range(minPitch, maxPitch);
                audioSource.Play();

                animator.SetBool("Jump", true);

            }

            if (Input.GetButtonUp("Jump") && timeEndJump > Time.time) {
                Rig.velocity = new Vector2(Rig.velocity.x, 0);
                timeEndJump = Time.time; }

        }
        public bool stayGround()
        {
            return timewindowJump >= Time.time;
        }

        private void FixedUpdate()
        {
            if (timeEndJump >= Time.time) Jump();

            CheckJump();
        }

        public void Jump()
        {
            Vector2 _vector = Rig.velocity;
            _vector.y = JumpForce;

            Rig.velocity = _vector;
        }

        public void CheckJump()
        {
            Vector2 start = (Vector2)transform.position + (Vector2.down * lineHeightOffset) + Vector2.left * (LineDistance / 2);
            Vector2 end = (Vector2)transform.position + (Vector2.down * lineHeightOffset) + Vector2.right * (LineDistance / 2);
            var hit = Physics2D.Linecast(start, end);
            if (hit.collider)
            {
                if (hit.collider.CompareTag(GroundTag))
                {

                    animator.SetBool("Jump", false);
                    timewindowJump = Time.time + coyoteTime;
                }
            }
            Vector2 start2 = (Vector2)transform.position + (Vector2.up * lineHeightOffset) + Vector2.left * (LineDistance / 2);
            Vector2 end2 = (Vector2)transform.position + (Vector2.up * lineHeightOffset) + Vector2.right * (LineDistance / 2);
            var hit2 = Physics2D.Linecast(start2, end2);

            if (hit2.collider) timeEndJump = Time.time;
        }
    }
}