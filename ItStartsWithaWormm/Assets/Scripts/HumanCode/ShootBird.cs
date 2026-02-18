using System.Collections;
using UnityEngine;

public class ShootBird : MonoBehaviour
{
    public AudioSource shooting;
    // to see if you can even shoot the bird
    bool aimedAt;
    bool shot;
    // so I can edit in editor
    [SerializeField] private Collider2D hitCollider;
    void Start()
    {
        aimedAt = false;
        shot = false;
        
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onShoot()
    {
        shooting.Play();
        Debug.Log("Shot nothing");
        if(aimedAt == true)
        {
            Debug.Log("Bird shot");
            if(shot == false)
            {
                 shot = true;
            }
            else
            {
                // if(shot == true)
            //{
               // collision.gameObject.GetComponent<BirdMove>().dead = true;
                //shot = false
            //}
            // u hv to shoot twice to kill
                //hitCollider.GetComponentInParent<BirdMove>().dead = true;
                //shot = false;
            }
           
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision");
        if(collision.gameObject.tag == "bird" )
        {
            // to check if just the hit part is touching the bird
            if (hitCollider.IsTouching(collision))
            {
            Debug.Log("Aiming at a bird");
            //aimedAt = true;
            //this.gameObject.GetComponent<Rigidbody2D>().position = new Vector2(this.gameObject.GetComponent<Rigidbody2D>().position.x - 0.2f, this.gameObject.GetComponent<Rigidbody2D>().position.y);
           if(shot == true)
            {
                collision.gameObject.GetComponent<BirdMove>().dead = true;
           }
           StartCoroutine(AimTime(collision));
           // aimedAt = false;
          // Debug.Log("no longer able to shoot!");
           //StartCoroutine(NoAim());
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
         if(collision.gameObject.tag == "bird")
        {
           //aimedAt = false;
          // Debug.Log("no longer able to shoot!");
          StartCoroutine(NoAim());
        }
    }

    // a timer givng only a little time to react
     IEnumerator AimTime(Collider2D collision)
    {
        // you are aiming at it
        aimedAt = true;
        // if you happen to shoot at this time
            // wait 0.5 secs before moving crosshair by a tiny bit
        yield return new WaitForSeconds(0.5f);
        this.gameObject.GetComponent<Rigidbody2D>().position = new Vector2(this.gameObject.GetComponent<Rigidbody2D>().position.x - 0.2f, this.gameObject.GetComponent<Rigidbody2D>().position.y);
        aimedAt = false;
       
        

    }

    IEnumerator NoAim()
    {
        yield return new WaitForSeconds(0.5f);
        aimedAt = false;
         Debug.Log("no longer able to shoot!");
    }
}
