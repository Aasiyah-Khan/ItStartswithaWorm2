using UnityEngine;

public class WormMovement : MonoBehaviour
{
    public Rigidbody2D rb;

    // how fast mr. worm is even moving
    float moveSpeed = 5f;
    public Vector2 MoveInput { get; private set; }


    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
         Vector2 movement = MoveInput * moveSpeed;
        rb.linearVelocity = movement;

    }

     public void OnMove(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        MoveInput = context.ReadValue<Vector2>();
    }


}
