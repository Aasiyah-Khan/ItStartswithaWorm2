using UnityEngine;

public class ShootBird : MonoBehaviour
{
    // to see if you can even shoot the bird
    bool aimedAt;
    bool shot;
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
        if(aimedAt == true)
        {
            Debug.Log("Bird shot");
            shot = true;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision");
        if(collision.gameObject.tag == "bird")
        {
            Debug.Log("Aiming at a bird");
            aimedAt = true;
            if(shot == true)
            {
                
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
         if(collision.gameObject.tag == "bird")
           {
           aimedAt = false;
       }
     }
}
