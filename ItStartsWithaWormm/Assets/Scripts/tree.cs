using UnityEngine;

public class tree : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //destroys tree sprites when they go past a certain point on screen
        if (transform.position.x < -20f)
        {
            Destroy(gameObject);
        }
    }
}
