using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    public int hpBase = 10;
    public int damageBase = 1;
    public int currentChapter = 1;
    
    public int hpBonus = 0;
    public int damageBonus = 0;
    
    private void Awake() 
    { 
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    
    public void StartLevel(int chapter)
    {
        currentChapter = chapter;
        hpBonus = 0;
        damageBonus = 0;
        LoadScene("KitchenGame", GameState.KitchenGame);
    }
    
    public void GoToDungeon()
    {
        LoadScene("Game", GameState.Game);
    }
    
    public void CompleteChapter()
    {
        switch(currentChapter)
        {
            case 1:
                hpBase += 2;
                break;
            case 2:
                damageBase += 3;
                break;
            case 3:
                hpBase += 2;
                damageBase += 1;
                break;
        }
    }
    
    public void BackToMenu()
    {
        LoadScene("MainMenu", GameState.MainMenu);
    }
    
    private void LoadScene(string sceneName, GameState newState)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneName);
    }
}

public enum GameState { MainMenu, KitchenGame, Game, Results }