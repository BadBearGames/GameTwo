using UnityEngine;
using System.Collections;

public class ColorSwitcher : MonoBehaviour {


    public float colourChangeDelay = 0.5f;
    float currentDelay = 0f;
    bool colourChangeCollision = false;

    void OnCollisionEnter(Collision other)
    {
        colourChangeCollision = true;
        currentDelay = Time.time + colourChangeDelay;
    }

    void checkColourChange()
    {
        if (colourChangeCollision && gameObject.name != "Player")
        {
            transform.GetComponent<Renderer>().material.color = Color.yellow;
            if (Time.time > currentDelay)
            {
                transform.GetComponent<Renderer>().material.color = new Color(0, 0, 0); 
                colourChangeCollision = false;
            }
        }
    }

    void Update()
    {
        checkColourChange();
    }
}
