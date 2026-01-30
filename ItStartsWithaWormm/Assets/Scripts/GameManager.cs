using UnityEngine;

public class GameManager : MonoBehaviour
{
    // so that the game manager doesnt get destroyed during scene changes
    public static GameManager instance;
    // when the game starts --> when first scene is opened
    void Awake()
    {
            if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject); // Prevent duplication
        }
            
    }
}
