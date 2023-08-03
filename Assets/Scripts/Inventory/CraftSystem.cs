using UnityEditor;
using UnityEngine;
using GameKit.Managers;

public class CraftSystem
{
   [SerializeField] GameParameters gameParameters;
   private Item[,] itemArray;


   public CraftSystem()
   {
      itemArray = new Item[GameParameters.gridSize, GameParameters.gridSize];
   }

   private bool isEmpty(int x, int y)
   {
      return itemArray[x, y] == null;
   }

   public Item GetItem(int x, int y)
   {
      return itemArray[x, y];
   }

   public void SetItem(Item item, int x, int y)
   {
      itemArray[x, y] = item;
   }

   private void IncreaseItem(int x, int y)
   {
      GetItem(x, y).amount++;
   }
   private void DecreaseItem(int x, int y)
   {
      GetItem(x, y).amount--;
   }

   private bool TryAddItem(Item item, int x, int y)
   {
      if (isEmpty(x, y))
      {
         SetItem(item,x,y);
         return true;
      }

      if (item.itemType == GetItem(x, y).itemType)
      {
         IncreaseItem(x,y);
         return true;
      }
      else
      {
         return false;
      }
   }

}


