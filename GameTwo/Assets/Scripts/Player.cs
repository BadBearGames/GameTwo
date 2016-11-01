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
    private bool isDead;
    private Vector3 lastSafePosition;
	#endregion

	#region Properties
    public bool IsDead
    {
        get { return isDead; }

        set { isDead = value; }
    }

	public Vector3 Position { get { return transform.position; } }

	//Physics
	public Rigidbody Body { get { return body; } }
	#endregion

	void Start()
	{
		//Assign body
		body = GetComponent<Rigidbody>();
        lastSafePosition = this.transform.position;
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
		SoundManager.Instance.PlaySfx("jump");
		body.AddForce(direction * force);
        //InputManager.Instance.checkSwipe = true;

	}

	/// <summary>
	/// Rolls
	/// </summary>
	/// <param name="direction">Direction.</param>
	/// <param name="force">Force.</param>
    public void Roll(Vector3 direction, float force)
    {
        print("ROLLED");
        direction.y = 0;
        body.AddForce(direction *(force*50));
        
        InputManager.Instance.checkSwipe = true;

    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Lava")
        {
            //move player
            this.transform.position = new Vector3(20, -1.0f, .5f);

            //set death bool
			if (!isDead)
			{
				SoundManager.Instance.PlaySfx("die");
				isDead = true;
			}
        }
    }

    //Every update check if player is gonna fall off tile
    public void FixedUpdate()
    {
        if (InputManager.Instance.CanJump && Physics.Raycast(this.transform.position, this.transform.TransformDirection(Vector3.back), 1.5f))
        {
            lastSafePosition = this.transform.position; // Save last safe position to be returned to later
        }

        if (InputManager.Instance.CanJump && !Physics.Raycast(this.transform.position, this.transform.TransformDirection(Vector3.back),1.5f))
        {
            //print("RAYFAIL");
            Vector3 force = this.body.velocity;
            this.body.AddForce(-2*(force*50));          //Cancel out any forces
            this.transform.position = lastSafePosition; //Move player to last safe place they stood
            this.body.AddForce(-2 * (force * 50));      //Apply a little bounce force

        }
    }
 //player respawn
 
 
}

