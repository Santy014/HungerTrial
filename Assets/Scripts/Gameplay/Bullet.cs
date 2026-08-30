using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5f;
    public int damage = 3;
    public float lifespan = 6f;  // Se autodestruye tras X seg viva
    
    private Vector2 direction;
    private float timeAlive = 0f;
    
    public void Init(Vector2 dir, float vel, int dmg)
    {
        direction = dir;
        speed = vel;
        damage = dmg;
    }
    
    private void Update()
    {
        timeAlive += Time.deltaTime;
        transform.position += (Vector3)(direction * speed * Time.deltaTime);
        if (timeAlive > lifespan)
        {
            Destroy(gameObject);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            HealthSystem health = collision.GetComponent<HealthSystem>();
            if (health != null)
            {
                health.TakeDamage(damage);  
            }
            Destroy(gameObject);
        }
    }
}