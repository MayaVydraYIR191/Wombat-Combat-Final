using UnityEngine;

namespace WombatCombat
{
    public class Test : MonoBehaviour
    {
        [SerializeField] private Playermove player;
        [SerializeField] private UI_Inventory uiInv;

        private void Start()
        {
            //uiInv.SetInventory();
            CraftSystem craftSystem = new CraftSystem();
            Item item = new Item { itemType = Item.ItemType.Grass, amount = 1 };
            craftSystem.SetItem(item, 0, 0);

        }
    }
}
