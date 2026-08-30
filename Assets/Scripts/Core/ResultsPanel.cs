using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ResultsPanel : MonoBehaviour
{
    public TextMeshProUGUI rewardText;
    public Button btnNext;
    public Button btnMenu;
    
    private void Start() 
    {
        GameManager.Instance.CompleteChapter();
        
        int chapter = GameManager.Instance.currentChapter;
        rewardText.text = $"¡Capitulo {chapter} completado!\n" +
                         $"HP Base: {GameManager.Instance.hpBase}\n" +
                         $"Daño Base: {GameManager.Instance.damageBase}";
        
        btnNext.onClick.AddListener(OnClickNext);
        btnMenu.onClick.AddListener(OnClickMenu);
    }
    
    private void OnClickNext()
    {
        Time.timeScale = 1f;
        GameManager.Instance.currentChapter++;
        SceneManager.LoadScene("MainMenu");
    }
    
    private void OnClickMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}