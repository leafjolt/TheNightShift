using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    // Higher values make the camera catch up faster
    public float smoothSpeed = 0.125f;
    public Vector3 offset = new Vector3(0, 0, -10);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LateUpdate()
    {
        if (player != null)
        {
            // Desired position of the camera
            Vector3 desiredPosition = new Vector3(player.position.x, transform.position.y, offset.z);
            
            // Smoothly transition to follow player (using linear interpolation)
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            
            transform.position = smoothedPosition;
        }
    }
}
