using UnityEngine;

public class CarDown : MonoBehaviour
{
    
    public float speed = 2.5f; //speed of cars
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //moves cars down on screen
        transform.Translate(Vector3.up * speed * Time.deltaTime); //moves cars down
        transform.Translate(Vector3.right * speed * Time.deltaTime); //moves cars to the right

        if (transform.position.y < -7.5) //if the cars x position is more than 15
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 15f);
        }
    }
}
