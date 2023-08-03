using UnityEngine;

public class CraftSystemUI : MonoBehaviour
{
    private Transform[,] slotTransformArray;

    private Transform outputSlotTransform;

    private void Awake()
    {
        slotTransformArray = new Transform[GameParameters.gridSize,GameParameters.gridSize];

        for (int x = 0; x < GameParameters.gridSize; x++)
        {
            for (int y = 0; y < GameParameters.gridSize; y++)
            {
                //slotTransformArray = gridContainer.Find("grid")
            }
        }

        outputSlotTransform = transform.Find("outputSlot");
    }

}
