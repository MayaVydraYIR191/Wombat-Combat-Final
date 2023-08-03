using UnityEngine;

namespace WombatCombat
{
    public class Spawn : MonoBehaviour
    {
        public GameObject item;
        private Transform player;

        private void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }

        public void SpawnDroppedItem()
        {
            Vector2 playerPos = new Vector2(player.position.x + 6, player.position.y - 1);
            Instantiate(item, playerPos, Quaternion.identity);
        }
    }
}

