using System.Collections;
using UnityEngine;

public class LightBehave : MonoBehaviour
{
    // light should appear every (lightAppear) seconds and remain for (lightRemain)
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float lightAppear;
    public float lightRemain;
    void Start()
    {
        
        StartCoroutine(LightTimer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator LightTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(lightAppear);
            // light is on the ground
            this.gameObject.GetComponent<Transform>().position = new Vector2(this.gameObject.GetComponent<Transform>().position.x, -2.5f);
            //Debug.Log("light on");
            // waiit 2 secs
            yield return new WaitForSeconds(lightRemain);
            // light is hidden offscreen
           this.gameObject.GetComponent<Transform>().position = new Vector2(this.gameObject.GetComponent<Transform>().position.x, 9.5f);
            //Debug.Log("light off");
        }
       
    }
}
