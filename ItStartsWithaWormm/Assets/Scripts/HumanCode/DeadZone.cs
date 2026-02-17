using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadZone : MonoBehaviour
{
   int deadCount;
   public Sprite frame1;
    public Sprite frame2;
    public Sprite frame3;
    public Sprite frame4;
    public Sprite frame5;
    public Sprite frame6;
    public Sprite frame7;
    public Sprite frame8, frame9, frame10, frame11, frame12, frame13, frame14, frame15;

    public GameObject cut;
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
                GameManager.instance.gameState = 6;
                // start cutscene
               StartCoroutine(CutScene());
            }
        }
    }

    IEnumerator CutScene()
    {
        cut.GetComponent<SpriteRenderer>().sprite = frame1;
        yield return new WaitForSeconds(1f);
        cut.GetComponent<SpriteRenderer>().sprite = frame2;
        yield return new WaitForSeconds(1f);
        cut.GetComponent<SpriteRenderer>().sprite = frame3;
        yield return new WaitForSeconds(1f);
        cut.GetComponent<SpriteRenderer>().sprite = frame4;
        yield return new WaitForSeconds(1f);
        cut.GetComponent<SpriteRenderer>().sprite = frame5;
        yield return new WaitForSeconds(1f);
        cut.GetComponent<SpriteRenderer>().sprite = frame6;
        yield return new WaitForSeconds(1f);
        cut.GetComponent<SpriteRenderer>().sprite = frame7;
        yield return new WaitForSeconds(1f);
        cut.GetComponent<SpriteRenderer>().sprite = frame8;
        yield return new WaitForSeconds(1f);
        cut.GetComponent<SpriteRenderer>().sprite = frame9;
        yield return new WaitForSeconds(1f);
        cut.GetComponent<SpriteRenderer>().sprite = frame10;
        yield return new WaitForSeconds(1f);
        cut.GetComponent<SpriteRenderer>().sprite = frame11;
        yield return new WaitForSeconds(1f);
        cut.GetComponent<SpriteRenderer>().sprite = frame12;
        yield return new WaitForSeconds(1f);
        cut.GetComponent<SpriteRenderer>().sprite = frame13;
        yield return new WaitForSeconds(1f);
        cut.GetComponent<SpriteRenderer>().sprite = frame14;
        yield return new WaitForSeconds(1f);
        cut.GetComponent<SpriteRenderer>().sprite = frame15;
        yield return new WaitForSeconds(2f);

        // reset state
        GameManager.instance.gameState = 1;
                // back to worm scene
                SceneManager.LoadScene("Worm");

    }
}
