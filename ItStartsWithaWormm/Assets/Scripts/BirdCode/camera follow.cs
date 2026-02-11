using UnityEngine;

public class camerafollow : MonoBehaviour
{
    public Transform bird; //target the camera will follow
    public float smoothSpeed = 65f; //camera speed
    public float xOffset = 5f; //offset of the camera on the x position

    private float lockY; //locked y position of camera
    private float lockZ; //locked z position of camera
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lockY = transform.position.y; //locks the y position of the camera
        lockZ = transform.position.z; //locks the z position of the camera
    }

    // Update is called once per frame after other update code is ran
    void LateUpdate()
    {
        //cameras x position = bird x position, locked y and z 
        Vector3 targetPosition = new Vector3(bird.position.x + xOffset, lockY, lockZ);
        //smooths the camera movement
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
    }
}
