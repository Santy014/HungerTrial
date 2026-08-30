using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed = 5f; 
    public Vector2 minLimits = new Vector2(-3f, -2f);
    public Vector2 maxLimits = new Vector2(3f, 2f);
    
    private HealthSystem bossHealth;
    private float attackCooldown = 0f;
    private const float ATTACK_COOLDOWN_TIME = 1f;

    private void Start()
    {
        GameObject boss = GameObject.FindWithTag("Boss");
            bossHealth = boss.GetComponent<HealthSystem>();
    }
    void Update()
    {
        // Movimiento
        Vector2 mov = new Vector2(Input.GetAxisRaw("Horizontal"),
                                  Input.GetAxisRaw("Vertical")).normalized;    
        transform.position += (Vector3)mov * speed * Time.deltaTime;

        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, minLimits.x, maxLimits.x);
        pos.y = Mathf.Clamp(pos.y, minLimits.y, maxLimits.y);
        transform.position = pos;
        
        // Atacar
        attackCooldown -= Time.deltaTime;
        
        if (Input.GetKeyDown(KeyCode.Space) && attackCooldown <= 0f && bossHealth != null)
        {
            bossHealth.TakeDamage(2);  // Daño al boss
            attackCooldown = ATTACK_COOLDOWN_TIME;  // Cooldown de 1 seg
        }
    }

    void OnDrawGizmos() 
    {
        Gizmos.color = Color.yellow;
        Vector3 center = new Vector3(
            (minLimits.x + maxLimits.x) / 2,
            (minLimits.y + maxLimits.y) / 2,
            0
        );
        Vector3 size = new Vector3(
            maxLimits.x - minLimits.x,
            maxLimits.y - minLimits.y,
            0
        );
        Gizmos.DrawWireCube(center, size);
    }
}