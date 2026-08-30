using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonNext : MonoBehaviour
{
    private void ClickNext()
    {
        Time.timeScale = 1f;
        GameManager.Instance.currentChapter++;
        SceneManager.LoadScene("MainMenu");  // Volver a Main Menu
    }
}
