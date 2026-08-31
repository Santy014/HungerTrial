using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f; 

    public SpriteRenderer spriteRenderer;
    public Sprite[] directionSprites;
    private float attackCooldown = 0f;
    private const float ATTACK_COOLDOWN_TIME = 1f;
    public GameObject bulletPrefab;  
    public Transform firePoint;    
    private Vector2 lastDirection = Vector2.down;
    private AudioSource audioSource; 
    private AudioClip  attackSound;
     public GameObject restartPanel;
     public HealthSystem bossHealth;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        HealthSystem health = GetComponent<HealthSystem>();
        if (health != null)
            health.OnDeath += ShowRestartPanel;  //  Llama al morir
    }
    
    void Update()
    {
        // Movimiento
        Vector2 mov = new Vector2(Input.GetAxisRaw("Horizontal"),
                                  Input.GetAxisRaw("Vertical")).normalized;    
        transform.position += (Vector3)mov * speed * Time.deltaTime;
        
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        
        // Cambiar el sprite segun la direccion
        if (h > 0) 
        { spriteRenderer.sprite = directionSprites[3];
            lastDirection = Vector2.right;}
        else if (h < 0) 
        { spriteRenderer.sprite = directionSprites[2];
            lastDirection = Vector2.left;}
        else if (v > 0) 
        { spriteRenderer.sprite = directionSprites[0];
            lastDirection = Vector2.up;
        }
        else if (v < 0) 
        {spriteRenderer.sprite = directionSprites[1];
            lastDirection = Vector2.down;
        }

        // Atacar
        attackCooldown -= Time.deltaTime;
        
        if (Input.GetKeyDown(KeyCode.Space) && attackCooldown <= 0f && firePoint != null && bulletPrefab != null)
        {
            var bala = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            Bullet bullet = bala.GetComponent<Bullet>();
            bullet.Init(lastDirection, 5f, 2);
            
            if (attackSound != null)
                audioSource.PlayOneShot(attackSound);  
            
            attackCooldown = ATTACK_COOLDOWN_TIME;
        }
    }
    private void ShowRestartPanel()
    {
        Time.timeScale = 0f;
        
        if (restartPanel != null)
        {
            restartPanel.gameObject.SetActive(true);
        }
    }
}
