using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = .01f;
    public bool hasKey = false;

    public GameObject key;

    public static PlayerController instance;

    // Start is called before the first frame update
    void Start()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        GameObject.DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = transform.position;

        if (Input.GetKey("w"))
        {
            newPosition.y += speed;             
        }
        
        if (Input.GetKey("s")) 
        {
            newPosition.y -= speed;
        }

        if(Input.GetKey("a")) 
        { 
            newPosition.x -= speed;
        }

        if(Input.GetKey("d")) 
        { 
            newPosition.x += speed;
        }

        transform.position = newPosition;
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.tag.Equals("door")) 
        {
            Debug.Log("hit");
            //SceneManager.LoadScene(0); 
            
        }

        if(collision.gameObject.tag.Equals("key"))
        { 
            Debug.Log("obtained key");
            hasKey = true;
        }
        if (collision.gameObject.tag.Equals("end") && hasKey == true)
        {
            Debug.Log("hit");
            //SceneManager.LoadScene(2);
        }

        if (collision.gameObject.tag.Equals(GetComponent<Collider>())) 
        {
            Debug.Log("hit");
        }
    }
}
