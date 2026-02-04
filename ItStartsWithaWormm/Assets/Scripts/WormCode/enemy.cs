using UnityEngine;

public class BirdMovement : MonoBehaviour
{
    // access enemy's rb to move it side to side
    Rigidbody2D rb;
    // starting position + ending position
    public float startingX;
    public float endingX;

    float speed = 0.04f;
    bool moveRight;



    void Start()
    {
        moveRight = true;
        rb = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
         // move bird left and right

        if (moveRight)
        {
             rb.position = new Vector2(rb.position.x + speed, rb.position.y);
             if(rb.position.x >= endingX)
            {
                moveRight = false;
            }
        }
        else
        {
            // move left
             rb.position = new Vector2(rb.position.x - speed, rb.position.y);
             if(rb.position.x <= startingX)
            {
                moveRight = true;
            }
        }
       
       
    }

   
    
}
