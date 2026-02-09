using UnityEngine;
using UnityEngine.InputSystem;

public class birdmovement : MonoBehaviour
{
    public float flySpeed = 5f; //forward flying speed of the bird
    public float steerSpeed = 180f; //turn speed of bird
    public float steerSmoothing = 4f; //how smooth the birds rotation is
    private float currentSteer; //current steering angle
    

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
}
