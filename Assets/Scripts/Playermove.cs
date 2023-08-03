using UnityEngine;
using UnityEngine.UIElements;

namespace WombatCombat
{
    public class Playermove : MonoBehaviour
    {
        public float speed;
        public float jumpForce;
        private float moveInput;

        public static bool lose = false;

        private Rigidbody2D rb;
        private bool facingRight = true;

        private bool isGrounded;
        public Transform feetPos;
        public float checkRadius;
        public LayerMask whatIsGround;

        public GameObject missionCompleted;
        public GameObject ZombieEatedYou;

        private Animator anim;
        
        private void Start()
        {
            anim = GetComponent<Animator>();
            rb = GetComponent<Rigidbody2D>();
            lose = false;
            ZombieBehavoir.count = 0;
        }
        private void FixedUpdate()
        {
            moveInput = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
            if (facingRight == false && moveInput > 0)
            {
                Flip();
            }
            else if (facingRight && moveInput < 0)
            {
                Flip();
            }

            if (moveInput == 0)
            {
                anim.SetBool("isRunning", false);
            }
            else
            {
                anim.SetBool("isRunning", true);
            }
        }

        private void Update()
        {
            isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

            if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }

            if (PlayerPrefs.GetInt("HighScore") < ZombieBehavoir.count)
            {
                PlayerPrefs.SetInt("HighScore", ZombieBehavoir.count);
            }

            else if (PlayerPrefs.GetInt("HighScore") >= ZombieBehavoir.count)
            {
                PlayerPrefs.SetInt("Score", ZombieBehavoir.count);
            }

            if (isGrounded == false)
            {
                anim.SetBool("isJumping", true);
            }
            else
            {
                anim.SetBool("isJumping", false);
            }

        }

        void Flip()
        {
            facingRight = !facingRight;
            Vector3 Scaler = transform.localScale;
            Scaler.x *= -1;
            transform.localScale = Scaler;
        }

        public void Jump()
        {
            rb.velocity = Vector2.up * jumpForce;
        }
        
        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("MissionEnd"))
            {
                missionCompleted.SetActive(true);
            }
            else if (other.CompareTag("Enemy"))
            {
                lose = true;
                gameObject.SetActive(false);
                ZombieEatedYou.SetActive(true);
            }
        }
    }
}
