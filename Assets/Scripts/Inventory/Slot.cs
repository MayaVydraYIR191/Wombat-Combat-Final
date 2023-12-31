using UnityEngine;

namespace WombatCombat
{

    public class Slot : MonoBehaviour
    {
        private Inventory inventory;
        [SerializeField] private int i;
        [SerializeField] private Item item;


        private void Start()
        {
            inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();

        }

        private void Update()
        {
            if (transform.childCount <= 0)
            {
                inventory.isFull[i] = false;
            }
        }

        public void DropItem()
        {
            foreach (Transform child in transform)
            {
                child.GetComponent<Spawn>().SpawnDroppedItem();
                Destroy(child.gameObject);
            }
        }
    }
}

