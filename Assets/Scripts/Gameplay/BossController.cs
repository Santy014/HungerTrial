using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;  
    
    public HealthSystem bossHealth;
    
    private void Start() 
    {

        
        if (bossHealth == null)
        {
            Debug.LogError("bossHealth NO está asignado en el Inspector!");
            return;
        }
        
        bossHealth.OnDeath += MostrarResultados;
        
        Debug.Log("EnemyController iniciando, capítulo: " + GameManager.Instance.currentChapter);
        SetupBoss(GameManager.Instance.currentChapter);   
    }
public void SetupBoss(int chapter)
{
    switch(chapter)
    {
        case 1:
            StartCoroutine(PatronMuroConHueco(3f, 60f));  // lento
            break;
        case 2:
            StartCoroutine(PatronMuroConHueco(4f, 60f));  // más rápido
            break;
        case 3:
            StartCoroutine(PatronMuroConHueco(5f, 60f));  // aún más rápido
            break;
    }
}
        
    private IEnumerator PatronMuroConHueco(float velocidad, float duracion)
    {
        float t = 0f;
        
        while (t < duracion)
        {
            int hueco = Random.Range(0, 6);  // hueco aleatorio (0-5)
            
            // Dispara 7 balas en línea horizontal
            for (int i = 0; i < 7; i++)
            {
                if (i == hueco || i == hueco + 1) continue;  // salta el hueco
                
                float x = -3f + (i * 1f);  // distribuye de -3 a 3
                
                Disparar(Vector2.down, velocidad);  // (0, -1) = siempre hacia abajo
            }
            
            t += 0.8f;
            yield return new WaitForSeconds(0.8f);
        }
    }
    
    private void Disparar(Vector2 direccion, float velocidad)
    {
        var bala = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
        Bullet bullet = bala.GetComponent<Bullet>();
        bullet.Init(direccion.normalized, velocidad, 1);
    }
    
    private void MostrarResultados()
    {
        Time.timeScale = 0f;
        // Aquí se mostrará el ResultsPanel (lo conectaremos después)
    }
}