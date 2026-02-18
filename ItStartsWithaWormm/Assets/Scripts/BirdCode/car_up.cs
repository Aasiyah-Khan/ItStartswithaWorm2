using UnityEngine;

public class CarUp : MonoBehaviour
{
    
    public float speed = 2.5f; //speed of cars

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //moves cars up on screen
        transform.Translate(Vector2.up * speed * Time.deltaTime); //moves cars up
        transform.Translate(Vector2.right * speed * Time.deltaTime); //moves cars to the right

        if (transform.position.y > 7.5) //if the cars x position is more than 15
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - 15f);
        }
    }
}
