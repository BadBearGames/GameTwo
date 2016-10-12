using UnityEngine;
using System.Collections;

public class Platform : MonoBehaviour 
{
	#region Fields
	private bool hasLandedOn;
	public bool isStartingPlatform;
	#endregion

	#region Properties
	public bool HasLandedOn { get { return hasLandedOn; } }
	#endregion

	void Awake()
	{
		hasLandedOn = false;
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
        if (hasLandedOn)
        {
            //shrink platform
            float rate = 0.995f;
            transform.localScale = new Vector3(transform.localScale.x * rate, transform.localScale.y, transform.localScale.z * rate);
        }
    }
}
