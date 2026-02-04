using UnityEngine;

public class GameManager : MonoBehaviour
{
    // so that the game manager doesnt get destroyed during scene changes
    public static GameManager instance;
    // when the game starts --> when first scene is opened
    // state management
    public int gameState;
    public Camera cam;
    // worm part is 1
    // camera stuff
    float camX;
    float wormX;
    float camDiff;
    public GameObject worm;
    void Awake()
    {
            if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject); // Prevent duplication
        }
            
    }

    void Start()
    {
        // if you want to test out a certain state change number here:
        gameState = 1;
        // so the camera follows the worm
         wormX = worm.gameObject.GetComponent<Rigidbody2D>().position.x;
        camX = cam.GetComponent<Transform>().position.x;
        camDiff = camX - wormX;

    }

    void FixedUpdate()
    {
        if(gameState == 1)
        {
            // reupdate the worm pos
            wormX = worm.GetComponent<Rigidbody2D>().position.x;
            // camera follows the worm based on distance
            cam.GetComponent<Transform>().position = new Vector3(wormX + camDiff, cam.GetComponent<Transform>().position.y, -10);

        }
    }
}
