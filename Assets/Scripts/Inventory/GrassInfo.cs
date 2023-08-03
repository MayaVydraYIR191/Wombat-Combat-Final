using UnityEngine;
using TMPro;

namespace WombatCombat
{

    public class GrassInfo : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI counter;
        [SerializeField] private GameObject grassImage;

        void Start()
        {
            grassImage.SetActive(false);
        }

        void Update()
        {
            counter.text = GameParameters.Instance.GrassCount.ToString();
            if (GameParameters.Instance.GrassCount > 0)
            {
                grassImage.SetActive(true);
            }
            else
            {
                grassImage.SetActive(false);
            }
        }
    }
}
