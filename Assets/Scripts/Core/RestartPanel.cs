using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartPanel : MonoBehaviour
{
    public Button btnReintentar;
    public Button btnMenu;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        btnReintentar.onClick.AddListener(OnClickReintentar);
        btnMenu.onClick.AddListener(OnClickMenu);
    }
        
    private void OnClickReintentar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Game");
    }
        
    private void OnClickMenu()
    {
            Time.timeScale = 1f;
            SceneManager.LoadScene("MainMenu");
    }   
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
