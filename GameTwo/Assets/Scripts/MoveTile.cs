using UnityEngine;
using System.Collections;

public class MoveTile : MonoBehaviour
{
    private bool dirRight = true;
    public float speed = 2.0f;
    public float range = 4.0f;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame  
    void Update()
    {
        if (dirRight)
           transform.Translate(Vector2.right * speed * Time.deltaTime);
        else
            transform.Translate(-Vector2.right * speed * Time.deltaTime);

        if (transform.position.x >= range)
        {
            dirRight = false;
        }

        if (transform.position.x <= -range)
        {
            dirRight = true;
        }

        
    }
}