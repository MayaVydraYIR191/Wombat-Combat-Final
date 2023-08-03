using UnityEngine;
using TMPro;

namespace WombatCombat
{
    public class Score : MonoBehaviour
    {
        void Update()
        {
            GetComponent<TMP_Text>().text = PlayerPrefs.GetInt("Score").ToString();
        }
    }
}

