using UnityEngine;
using System.Collections;

/// <summary>
/// Does whatever a player does
/// </summary>
[RequireComponent (typeof (Rigidbody))]
public class Player : MonoBehaviour 
{
	#region Fields
	//Physics
	private Rigidbody body;
	#endregion

	#region Properties
	public Vector3 Position { get { return transform.position; } }

	//Physics
	public Rigidbody Body { get { return body; } }
	#endregion

	void Start()
	{
		//Assign body
		body = GetComponent<Rigidbody>();
	}

	/// <summary>
	/// Should be called when hitting a platform
	/// </summary>
	public void Land()
	{
		InputManager.Instance.CanJump = true;
	}

	/// <summary>
	/// Makes that player jump yo
	/// </summary>
	/// <param name="direction">Direction.</param>
	/// <param name="force">Force.</param>
	public void Jump(Vector3 direction, float force)
	{
		body.AddForce(direction * force);
	}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Lava") {
            transform.position = new Vector3(-75, -.45f, -73);
            
        }

      
    }
 
 //player respawn
 
 
}

