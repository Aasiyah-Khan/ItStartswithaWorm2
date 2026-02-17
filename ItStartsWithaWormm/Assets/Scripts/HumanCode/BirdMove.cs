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

    bool dodge;

    float speed = 8f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dodge = false;
         rb = this.gameObject.GetComponent<Rigidbody2D>();
        StartCoroutine(RanMove());
    }

    // Update is called once per frame
    void Update()
    {
        if(dead == true)
        {
            Debug.Log(gameObject.name + " is dead");
            // hide the bird off screen
            rb.position =  new Vector2(28f, 1f);       
        }
    }


     IEnumerator RanMove()
    {
        //Debug.Log("RanMove Started");
        // goes on forever (idk if this is a great idea ngl)
        while(dead == false)
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
            // wait before choosing a new location to move toward...
            yield return new WaitForSeconds(0.3f);
        }
        
    }

    // if the bird collides with the trigger-- make it move away from trigger
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "vicinity")
        {
            // move bird??
            dodge = true;
            Debug.Log("Bird Dodged!");
            // stop the random movement and begin the dodging
             StopCoroutine(RanMove());
            StartCoroutine(Dodge(collision.transform));

           

        }
    }


    IEnumerator Dodge(Transform threat)
    {
        // make a vector called direction that
        // look at the position and make it a vector direction
        Vector2 direction = (transform.position - threat.position).normalized;
        // wait can I randomize this
        //Vector2 direction2 = new Vector2(Random.Range(-1,1), Random.Range(-1, 1));

        // short timer
        float dodgeTime = 0.3f;
        // start timer at 0
        float timer = 0f;


         while (timer < dodgeTime)
        {
            // take that direction
            // multiply the speed so it flies away in that direction faster 
            rb.MovePosition(rb.position + direction * speed * 3f * Time.fixedDeltaTime);
            // add to timer a tiny bit...
            timer += Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }
        // now move to a random direction again
        StartCoroutine(RanMove());
    }
}
