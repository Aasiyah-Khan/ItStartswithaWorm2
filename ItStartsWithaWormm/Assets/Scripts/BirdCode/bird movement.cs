using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class birdmovement : MonoBehaviour
{
    public float flySpeed; //forward flying speed of the bird
    public float normalSpeed = 5f; //normal value of speed
    public float slowness = 0.3f; //multiplier for slowing the bird down
    public float steerSpeed = 180f; //turn speed of bird
    public float steerSmoothing = 4f; //how smooth the birds rotation is
    private float currentSteer; //current steering angle
    private float nextSceneX = 120f; //x position the sprite must reach to trigger transition to next scene
    private bool switchScene = false; //checks if the scene changed
    public float maxYfly = 8f; //maximum y value of player sprite before getting reset
    public float minYfly = -8f; //minimum y value of player sprite before getting reset
    public float shiftX = 2f; // distance the sprite moves on the x when reset
    

    private Rigidbody2D bird; //instantiates rigidbody component of our bird
    public InputActionReference steerAction; //instantiates the steering action in the input menu

    void Awake()
    {
        bird = GetComponent<Rigidbody2D>(); //accesses the rigidbody component
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        float targetSteer = steerAction.action.ReadValue<float>();
        
        //smooths the steering of the bird
        currentSteer = Mathf.Lerp(
            currentSteer,
            targetSteer,
            steerSmoothing * Time.fixedDeltaTime);
        
        //constant movement from left to right across screen
        bird.linearVelocity = transform.right * flySpeed;
        //rotates the bird on z-axis
        bird.rotation -= currentSteer * steerSpeed * Time.fixedDeltaTime;
        /*
        //checks the steer input value
        float steer = steerAction.action.ReadValue<float>();

        //constant movement from left to right across screen
        bird.linearVelocity = transform.right * flySpeed;
        //rotates the bird on the z-axis
        bird.rotation -= steer * steerSpeed * Time.deltaTime;
        */
    }

    void OnEnable()
    {
        steerAction.action.Enable(); //positive value for rotation
    }

    void OnDisable()
    {
        steerAction.action.Disable(); //negative value for rotation
    }
    
    //activates once the bird goes out of bounds
    void ResetBird()
    {
        //moves the bird to the left slightly and resets y to 0
        bird.position = new Vector2(bird.position.x - shiftX, 0f);
        bird.rotation = 0f; //resets birds rotation 
        bird.linearVelocity = Vector2.zero; //stops movement briefly
        currentSteer = 0f; //resets the z rotation of the bird to face right
    }
    
    //triggers on collision with trees
    void OnTriggerEnter2D(Collider2D other)
    {
        //if bird collides with tree sprite
        if (other.CompareTag("treeobstacle"))
        {
           /*
            //reloads the current scene upon tree collision
            Scene currentscene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentscene.name);
            */
           flySpeed *= slowness; //slows the speed of the bird sprite
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("treeobstacle"))
        {
            flySpeed = normalSpeed; //reverts speed to normal after tree collision stops
        }
    }

    void Update()
    {
        //if the bird reaches a certain x position
        if (!switchScene && bird.position.x >= nextSceneX)
        {
            switchScene = true; //checks when the scene switched
            SceneManager.LoadScene("Human"); //loads the next scene
        }
        
        //active when bird y value is too high or low
        if (bird.position.y > maxYfly || bird.position.y < minYfly)
        {
            ResetBird();
        }
    }
}
