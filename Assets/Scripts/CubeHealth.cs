using UnityEngine;

namespace WombatCombat
{

    public class CubeHealth : MonoBehaviour
    {
        [SerializeField] private int healthOfCube;
        private int collisionCount;
        private float timer;

        private void Awake()
        {
            healthOfCube = 10;
        }

        void Update()
        {
            if (healthOfCube > 0)
            {
                if (collisionCount > 0)
                {
                    timer -= Time.deltaTime;
                    if (timer <= 0)
                    {
                        healthOfCube -= 1;
                        timer = 1;
                    }
                }
            }

            if (healthOfCube <= 0)
            {
                gameObject.SetActive(false);
            }

        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Enemy"))
            {
                collisionCount++;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Enemy"))
            {
                collisionCount--;
                if (collisionCount <= 0)
                {
                    timer = 0;
                }
            }
        }
    }
}
