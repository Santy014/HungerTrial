using System.Collections;
using UnityEngine;
using TMPro;

public class HealthSystem : MonoBehaviour
{
    public int maxHP = 10; 
    public int currentHP;
    public float invulnDuration = 0.8f;
    public SpriteRenderer sprite;
    private bool invulnerable = false;
    public System.Action OnDeath;
    public TextMeshProUGUI HPText;
    private AudioSource audioSource;
    public AudioClip hitSound;      
    public AudioClip deathSound;
    
    private void Start() 
    { 
        currentHP = maxHP;
        UpdateHPText();  
        audioSource = GetComponent<AudioSource>();
    }
    
    public void TakeDamage(int damage) 
    { 
        if (invulnerable == true || currentHP <= 0)
            return;
        
        currentHP -= damage;  
        
        // Reproduce sonido de golpe
        if (hitSound != null)
        {
            audioSource.PlayOneShot(hitSound);
        }
        
        UpdateHPText();

        if (currentHP <= 0)
        {
            // Reproduce sonido de muerte
            if (deathSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(deathSound);
            }
            OnDeath?.Invoke();
            Destroy(gameObject, 0.5f);
            return;  
        }
        
        StartCoroutine(IFrames());
    }
    
    private IEnumerator IFrames() 
    { 
        invulnerable = true;
        float elapsed = 0f;
        
        while (elapsed < invulnDuration)
        {
            sprite.enabled = !sprite.enabled;
            yield return new WaitForSeconds(0.1f);
            elapsed += 0.1f;
        }
        
        sprite.enabled = true;
        invulnerable = false;
    }

    private void UpdateHPText()
    {
        if (HPText != null)
        {
            HPText.text = $"{currentHP}/{maxHP}";
        }
    }
}