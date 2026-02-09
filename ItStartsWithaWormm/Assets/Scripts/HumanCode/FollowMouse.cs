using UnityEngine;
using UnityEngine.InputSystem;

public class FollowMouse : MonoBehaviour
{
    private Camera mainCamera;
    // allows it to be found in the inspect
    [SerializeField]
    private float speed = 10f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        followMousePos();
    }

    private void followMousePos()
    {
        transform.position = GetWorldPositionFromMouse();
    }

    private Vector2 GetWorldPositionFromMouse()
    {
         Vector2 mousePos = Mouse.current.position.ReadValue();
        return mainCamera.ScreenToWorldPoint(mousePos);
    }
}
