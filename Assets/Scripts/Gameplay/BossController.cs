using System.Collections;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;  
    public HealthSystem bossHealth;
    public ResultsPanel resultsPanel;
    
    private Transform playerTransform;
    private AudioSource audioSource;
    public AudioClip[] disparoSounds;

    private void Start() 
    {
        bossHealth = GetComponent<HealthSystem>();
        audioSource = GetComponent<AudioSource>();
        
        if (bossHealth == null)
        {
            return;
        }
        
        bossHealth.OnDeath += MostrarResultados;
        
        // Encuentra al Player
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
            playerTransform = player.transform;
        
        SetupBoss(GameManager.Instance.currentChapter);   
    }

    public void SetupBoss(int chapter)
    {
        switch(chapter)
        {
            case 1:
                StartCoroutine(ShootingPattern(3f, 60f));
                break;
            case 2:
                StartCoroutine(ShootingPattern(4f, 60f));
                break;
            case 3:
                StartCoroutine(ShootingPattern(5f, 60f));
                break;
        }
    }
        
    private IEnumerator ShootingPattern(float velocidad, float duracion)
    {
        float t = 0f;
        
        while (t < duracion && playerTransform != null && Time.timeScale > 0)
        {
            Vector2 dir2Player = (playerTransform.position - transform.position).normalized;
            Disparar(dir2Player, velocidad);
            
            t += 0.8f;
            yield return new WaitForSeconds(0.8f);
        }
    }
    
    private void Disparar(Vector2 direccion, float velocidad)
    {
        var bala = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
        Bullet bullet = bala.GetComponent<Bullet>();
        bullet.Init(direccion.normalized, velocidad, 1);
        
        if (disparoSounds.Length > 0 && audioSource != null)
        {
            AudioClip clip = disparoSounds[Random.Range(0, disparoSounds.Length)];
            audioSource.PlayOneShot(clip);
        }
    }
    
    private void MostrarResultados()
    {
        Time.timeScale = 0f;
        
        if (resultsPanel != null)
        {
            resultsPanel.gameObject.SetActive(true);
        }
    }
}