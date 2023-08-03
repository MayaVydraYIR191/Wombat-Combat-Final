using UnityEngine;

namespace WombatCombat
{

    public class Grass : MonoBehaviour
    {
        private float grassLife;

        private void Start()
        {
            grassLife = 10;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                GameParameters.Instance.CollectGrass();
                Destroy(gameObject);
            }

        }

        private void Update()
        {
            grassLife -= Time.deltaTime;
            if (grassLife <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}

