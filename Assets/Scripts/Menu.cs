using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject exitButton;
    [SerializeField] private GameObject logo;
    [SerializeField] private GameObject howToPlayTab;
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void HowToPlay()
    {
        howToPlayTab.SetActive(true);
        playButton.SetActive(false);
        exitButton.SetActive(false);
        logo.SetActive(false);
    }

    public void CloseHowToPlay()
    {
        howToPlayTab.SetActive(false);
        playButton.SetActive(true);
        exitButton.SetActive(true);
        logo.SetActive(true);
    }

}

