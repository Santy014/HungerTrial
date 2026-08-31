using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float smoothing = 5f;
    // Update is called once per frame
    void LateUpdate()
    {
        if (player == null ) return;

        Vector3 targetPos = new Vector3(player.position.x, player.position.y, -10);
        transform.position = Vector3.Lerp(transform.position, targetPos, smoothing * Time.deltaTime);
    }
}
