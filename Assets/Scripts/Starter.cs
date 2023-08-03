using UnityEngine;

public class Starter : MonoBehaviour
{
    [SerializeField] GameParameters gameParameters;
    public void Awake()
    {
        gameParameters.InitManager();
    }
}
