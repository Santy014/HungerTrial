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
    private void Start() 
    { 
        currentHP = maxHP;
        UpdateHPText();  
    }
    
    public void TakeDamage(int damage) 
    { 
        if (invulnerable == true)
            return;
        
        currentHP -= damage;   
        UpdateHPText();

        if (currentHP <= 0)
        {
            OnDeath?.Invoke();
            Destroy(gameObject);
            return;  
        }
        
        // Si sobrevive se vuelve invulnerable
        StartCoroutine(IFrames());
    }
    
    private IEnumerator IFrames() 
    { 
        invulnerable = true;
        float elapsed = 0f;
        
        // Mientras tiempo < invulnDuration
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