using UnityEngine;

namespace GrapplingHook.Player
{
    public class Movimiento : MonoBehaviour
    {
        [field: SerializeField] private float Speed { get; set; }
        [field: SerializeField] private Rigidbody2D Rig { get; set; }

        [SerializeField] Animator animator;
        [SerializeField] private SaltoP saltCC;

        [SerializeField] private AudioSource audioSource;

        [SerializeField] private ParticleSystem walkingParticles;


        private void Update()
        {
            bool idle = Mathf.RoundToInt(Input.GetAxisRaw("Horizontal")) == 0;
            animator.SetBool("Walk", !idle);
            if (Input.GetButton("Horizontal") && saltCC.stayGround() && !audioSource.isPlaying)
            {
                walkingParticles.Play();
                audioSource.Play();
            }
            if (!saltCC.stayGround() || idle) {
                walkingParticles.Stop();
                audioSource.Stop(); 
            }
            
        }
        private void FixedUpdate()
        {
            if (Input.GetButton("Horizontal"))
            {
                if(Input.GetAxis("Horizontal") >= 0) transform.rotation = Quaternion.Euler(Vector2.up * 0);

                else transform.rotation = Quaternion.Euler(Vector2.up * 180);

            }
            MovePlayer();
        }

        public void MovePlayer()
        {
            var _vector = Rig.velocity;
            var _speedx = Mathf.Abs(Input.GetAxis("Horizontal")) * Speed;
            var _vectorSpeed = (Vector2)transform.right * _speedx;
            _vector.x = _vectorSpeed.x;

            Rig.velocity = _vector;
        }
        public void Dash(float force)
        {
            var _vector = Rig.velocity;
            _vector.x = force * transform.right.x;
            Rig.velocity = _vector;
        }
    }
}