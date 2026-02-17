using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadZone : MonoBehaviour
{
   int deadCount;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       deadCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "bird")
        {
             deadCount++;
            Debug.Log("Dead Birds: " + deadCount);
            if(deadCount == 4)
            {
                GameManager.instance.gameState = 1;
                SceneManager.LoadScene("Worm");
            }
        }
    }
}
