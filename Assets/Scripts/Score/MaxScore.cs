using UnityEngine;
using TMPro;

public class MaxScore : MonoBehaviour
{
    void Update ()
    {
        GetComponent<TMP_Text>().text = PlayerPrefs.GetInt("HighScore").ToString();
    }
}

