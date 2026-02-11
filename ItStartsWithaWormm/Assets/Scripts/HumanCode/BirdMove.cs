using System.Collections;
using UnityEngine;

public class BirdMove : MonoBehaviour
{
    public bool dead;
    Rigidbody2D rb;
    // starting position + ending position
    public float startingX;
    public float endingX;

    public float startingY;
    public float endingY;
    Vector2 movePoint;

    float speed = 4f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
         rb = this.gameObject.GetComponent<Rigidbody2D>();
        StartCoroutine(RanMove());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


     IEnumerator RanMove()
    {
        //Debug.Log("RanMove Started");
        // goes on forever (idk if this is a great idea ngl)
        while(true)
        {
          // pick random location
            movePoint = new Vector2(Random.Range(startingX, endingX), Random.Range(startingY, endingY));
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
