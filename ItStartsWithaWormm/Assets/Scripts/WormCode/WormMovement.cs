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

    public Sprite frame1;
    public Sprite frame2;
    public Sprite frame3;
    public Sprite frame4;

    public Sprite frame5;
    public Sprite frame6;

    public GameObject Cut;


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
        }
        else if(collision.gameObject.tag == "Beak")
        {
            //Debug.Log("SceneChanged");
           GameManager.instance.gameState = 2;
           // now the cutscene
           StartCoroutine(CutScene());
           // change scene
           
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

    IEnumerator CutScene()
    {
        Debug.Log("CutScene started!");
        Cut.GetComponent<SpriteRenderer>().sprite = frame1;
        yield return new WaitForSeconds(1f);
        Cut.GetComponent<SpriteRenderer>().sprite = frame2;
        yield return new WaitForSeconds(1f);
        Cut.GetComponent<SpriteRenderer>().sprite = frame3;
        yield return new WaitForSeconds(1f);
        Cut.GetComponent<SpriteRenderer>().sprite = frame4;
        yield return new WaitForSeconds(1f);
        Cut.GetComponent<SpriteRenderer>().sprite = frame5;
        yield return new WaitForSeconds(1f);
        Cut.GetComponent<SpriteRenderer>().sprite = frame6;
        yield return new WaitForSeconds(2f);
        // change scene
        GameManager.instance.gameState = 3;
         SceneManager.LoadScene("Bird");


    }


}
