using UnityEngine;

public class AppearBoss : MonoBehaviour
{   
    public GameObject Boss;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Boss != null)
        {
            Boss.SetActive(true);
            
            HealthSystem bossHealth = Boss.GetComponent<HealthSystem>();
            if (bossHealth != null)
            {
                bossHealth.currentHP = bossHealth.maxHP;
            }
        }
    }
}
