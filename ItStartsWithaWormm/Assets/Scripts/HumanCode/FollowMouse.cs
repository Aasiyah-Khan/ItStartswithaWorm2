using System.Collections;
using System.Security.AccessControl;
using UnityEngine;
using UnityEngine.InputSystem;

public class FollowMouse : MonoBehaviour
{
    private Camera mainCamera;
    // allows it to be found in the inspect
    [SerializeField]
    private float speed = 10f;
    
    
    public Rigidbody2D rb;
    // all of the frames
    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameManager.instance.gameState = 5;
        mainCamera = Camera.main;
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        // hide the cursor
        Cursor.visible = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(GameManager.instance.gameState == 5)
        {
            mainCamera.GetComponent<Transform>().position = new Vector3(0,0,-10);
            this.gameObject.SetActive(true);
            followMousePos();
        }
        else if(GameManager.instance.gameState == 6)
        {
            this.gameObject.SetActive(false);
            // move camera to cutscene pos
            mainCamera.GetComponent<Transform>().position = new Vector3(50.2f, 0, -10);
           
        }
        
    }

    private void followMousePos()
    {
        rb.MovePosition(GetWorldPositionFromMouse());
    }

    private Vector2 GetWorldPositionFromMouse()
    {
         Vector2 mousePos = Mouse.current.position.ReadValue();
        return mainCamera.ScreenToWorldPoint(mousePos);
    }

    
}
