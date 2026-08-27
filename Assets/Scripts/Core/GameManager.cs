using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Singleton pattern
    public static GameManager Instance { get; private set; }
    
    private GameManager() {}

    // Stats permanentes
    public int hpBase = 10;
    public int damageBase = 1;
    public int currentChapter = 1;
    
    // Buffs de Run 
    public int hpBonus = 0;
    public int damageBonus = 0;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Singleton Pattern 
    private void Awake() { 
        // Si ya existe la instancia, se destruye (Evitar duplicidad)
        if (Instance != null && Instance != this) {
            Destroy(gameObject);
            return 
        }

        // Mantener la sesion 
        Instance = this;

        // No destruir instancia al cargarla
        DontDestroyOnLoad(gameObject)
    }
    
    public void StartLevel(int chapter) { }
    public void CompleteChapter() { }
    public void GoToDungeon() { }
    public void BackToMenu() { }

    
}

