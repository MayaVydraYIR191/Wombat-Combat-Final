using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Inventory : MonoBehaviour
{
   private Inventory inventory;
   private Transform itemSlotContainer;
   private Transform itemSlotTemplate;
   
   public void SetInventory(Inventory inventory)
   {
      this.inventory = inventory;
      RefreshInventoryItem();
   }
   private void Awake()
   {
      itemSlotContainer = transform.Find("itemSlotContainer");
      itemSlotTemplate = itemSlotContainer.Find("itemSlotTemplate");
   }

   private void RefreshInventoryItem()
   {
      int x = 0;
      int y = 0;
      float itemSlotCellSize = 30f;
      foreach (Item item in inventory.GetItemList())
      {
         RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
         itemSlotRectTransform.gameObject.SetActive(true);
         itemSlotRectTransform.anchoredPosition = new Vector2(x*itemSlotCellSize,y*itemSlotCellSize);
         x++;
         if (x > 4)
         {
            x = 0;
            y++;
         }
      }
   }

}
