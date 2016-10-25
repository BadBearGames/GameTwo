using UnityEngine;
using System.Collections;

public class Platform : MonoBehaviour 
{
	#region Fields
	private bool hasLandedOn;
	public bool isStartingPlatform;
    private Vector3 orginal;
    private float height = 100;
	#endregion

	#region Properties
	public bool HasLandedOn { get { return hasLandedOn; } }
	#endregion

	void Awake()
	{
        //cant be on it from the begining
		hasLandedOn = false;

        // save orginal size
        orginal = transform.localScale;
    }

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.GetComponent<Player>() != null)
		{
			//Player landed so call the landing
			GameManager.Instance.LandedOnNewPlatform(this);

            //check if platform isnt the start one
            if(!isStartingPlatform)
            {
                //its not- allow to shrink
                hasLandedOn = true;
                
           }
            	
		}
	}

    void OnCollisionExit(Collision col)
    {
        //make sure colliding object is the player
        if (col.gameObject.GetComponent<Player>() != null)
        {
            //Player left the platform
            hasLandedOn = false; //no longer landed on- should stop shrinking

        }
    }

    void FixedUpdate()
    {
        //check if its been landed on
        float rate = 0.2f; //rate of resizing
        float color = 2.5f;
        this.transform.GetComponent<Renderer>().material.color = new Color( 255-(color * height),0, 0);
        if (hasLandedOn)
        {
            //shrink platform
            //transform.localScale = new Vector3(transform.localScale.x * rate, transform.localScale.y, transform.localScale.z * rate);
            height -= rate;
            //print(height);
            print(255 - color * height);

        }
        else 
        {
            //check if it needs togo back to orginal siz
            if (transform.localScale.x < orginal.x && transform.localScale.y < orginal.y && transform.localScale.z < orginal.z)
            {
                //grow
                transform.localScale = new Vector3(transform.localScale.x / rate, transform.localScale.y, transform.localScale.z / rate);
            }
        }
        if (height <= 0)
        {
            //disable collider to let player fall through
        }
    }
}
