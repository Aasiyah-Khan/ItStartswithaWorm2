using System.Collections;
using Unity.VisualScripting.Antlr3.Runtime.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WormMovement : MonoBehaviour
{
    public Rigidbody2D rb;

    // how fast mr. worm is even moving
    float moveSpeed = 5f;
    public Vector2 MoveInput { get; private set; }

    // state setup
    public bool hiding;
    public bool caught;
    
    public bool canMove;

    public Animator animator;

    public GameObject gameManager;
    //GameManager gameManager;


    void Start()
    {
         GameManager.instance.SetWorm(gameObject);
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        hiding = false;
        caught = false;
        canMove = true;
    }


    void FixedUpdate()
    {
        if(canMove == true)
        {
            
             Vector2 movement = MoveInput * moveSpeed;
            rb.linearVelocity = movement;
        }
         

    }

     public void OnMove(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
       
            MoveInput = context.ReadValue<Vector2>();
            animator.SetFloat("speed", Mathf.Abs(MoveInput.x));
            if(MoveInput.x >= 0)
        {
            this.gameObject.GetComponent<Transform>().rotation = new Quaternion(0, 0, 0, 0);
        }
        else if(MoveInput.x <= 0)
        {
             this.gameObject.GetComponent<Transform>().rotation = new Quaternion(0, 180, 0, 0);
        }
        
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "safe")
        {
            hiding = true;
            Debug.Log("Player is safe");
        }
        else if(collision.gameObject.tag == "shadow" && hiding == false)
        {
            Debug.Log("Caught by bird");
            caught = true;
            canMove = false;
            StartCoroutine(StunWorm());

        }
        else if(collision.gameObject.tag == "light")
        {
            Debug.Log("Slowed by light burns");
            moveSpeed = 2f;
            //triggers the animation
            animator.SetBool("isWrinkly", true);
        }
        else if(collision.gameObject.tag == "Beak")
        {
            Debug.Log("SceneChanged");
           GameManager.instance.gameState = 2;
            SceneManager.LoadScene("Bird");
        }
    }


    // when leaving safe spot
    void OnTriggerExit2D(Collider2D collision)
    {
        // the hiding spots are tagged safe 
        if(collision.gameObject.tag == "safe")
        {
            hiding = false;
            Debug.Log("Player is no longer safe");
        }
        else if(collision.gameObject.tag == "light")
        {
            Debug.Log("Fast Again");
            moveSpeed = 5f;
            //ends the animation
            animator.SetBool("isWrinkly", false);
        }
    }

    // coroutine time!!! I need to stun the enemy
    IEnumerator StunWorm()
    {
        // I need to wait for two seconds;
        yield return new WaitForSeconds(2f);
        // start movement again
        Debug.Log("Can Move Again");
        canMove = true;
    }


}
