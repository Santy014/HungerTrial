using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject panelSplash;
    public GameObject panelMenuPrincipal;
    public Button btnIniciar;
    public Button btnJugar;
    public Button btnSalir;


    
    private void Start()
    {
    btnIniciar.onClick.AddListener(OnClickIniciar);
    btnJugar.onClick.AddListener(OnClickJugar);
    btnSalir.onClick.AddListener(OnClickSalir);
    }
    
    private void OnClickIniciar()
    {
        panelSplash.SetActive(false);
        panelMenuPrincipal.SetActive(true);
    }
    private void OnClickJugar() 
    {
    GameManager.Instance.StartLevel(1);
    }
    private void OnClickSalir()
    {
    Application.Quit();
    }
}
