using System.Collections;
using UnityEngine;


public class BirdMovement : MonoBehaviour
{
    // access enemy's rb to move it side to side
    // I need it to be random T-T
    Rigidbody2D rb;
    // starting position + ending position
    public float startingX;
    public float endingX;
    Vector2 movePoint;

    float speed = 4f;
    bool moveRight;



    void Start()
    {
        
        moveRight = true;
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        StartCoroutine(RanMove());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
         // move bird left and right

        // if (moveRight)
        // {
        //      rb.position = new Vector2(rb.position.x + speed, rb.position.y);
        //      if(rb.position.x >= endingX)
        //     {
        //         moveRight = false;
        //     }
        // }
        // else
        // {
        //     // move left
        //      rb.position = new Vector2(rb.position.x - speed, rb.position.y);
        //      if(rb.position.x <= startingX)
        //     {
        //         moveRight = true;
        //     }
        // }
       

       
    }

    // a coroutine to randomize movement??
    IEnumerator RanMove()
    {
        //Debug.Log("RanMove Started");
        // goes on forever (idk if this is a great idea ngl)
        while(true)
        {
          // pick random location
            movePoint = new Vector2(Random.Range(startingX, endingX), rb.position.y);
            // keep moving until very close to the ending point (which is random)
            while(Vector2.Distance(rb.position, movePoint) > 0.05f)
            {
                // the movement
                rb.MovePosition(Vector2.MoveTowards(rb.position, movePoint, speed * Time.fixedDeltaTime));
                // so move with the update function
                yield return new WaitForFixedUpdate();

            
            }
            // wait 5 secs before choosing a new location to move toward...
            yield return new WaitForSeconds(1f);
        }
        
    }



   
    
}
