using UnityEngine;
using UnityEngine.InputSystem;

public class FollowMouse : MonoBehaviour
{
    private Camera mainCamera;
    // allows it to be found in the inspect
    [SerializeField]
    private float speed = 10f;

    public Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCamera = Camera.main;
        rb = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        followMousePos();
    }

    private void followMousePos()
    {
        rb.MovePosition(GetWorldPositionFromMouse());
    }

    private Vector2 GetWorldPositionFromMouse()
    {
         Vector2 mousePos = Mouse.current.position.ReadValue();
        return mainCamera.ScreenToWorldPoint(mousePos);
    }
}
