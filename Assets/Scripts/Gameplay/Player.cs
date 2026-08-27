using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f; 
    public Vector2 minlimits = new Vector2(-3f,-2f);
    public Vector2 maxlimits = new Vector2(3f,2f);


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {    

    }

    // Update is called once per frame
    void Update()
    {
    Vector2 mov =  new Vector2(Input.GetAxisRaw("Horizontal"),
                        Input.GetAxisRaw("Vertical")).normalized;    

    transform.position =+ (Vector3)mov * speed * Time.deltaTime;

    Vector3 pos = transform.position     
    pos.x = Mathf.Clamp( mov.x , minlimits.x , maxlimits.x );
    pos.y =  Mathf.Clamp( mov.x , minlimits.x , maxlimits.x );
    transform.position = pos; 
    }

    void OnDrawGizmos() {
        Vector3 center = new Vector3(
            (minlimits.x + maxlimits.x) / 2,
            (minlimits.y + maxlimits.y) / 2,
            0
        );

        Vector3 size = new Vector3(
            maxlimits.x - minlimits.x,
            maxlimits.y - minlimits.y,
            0
        );
        
         Gizmos.DrawWireCube(center, size);
    }
}
