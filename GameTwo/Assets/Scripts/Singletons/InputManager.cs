using UnityEngine;
using System.Collections;

/// <summary>
/// Should load all sound files from resources and store them in a dictionary on awake.
/// A play sound method should be defined for looping and one shot sounds.
/// Any calls to sound manager should be made in code.
/// Any ui sounds will be handled seperately through canvas.
/// </summary>
public class InputManager : Singleton<InputManager>
{
	#region Fields
	//Jumping
	private float jumpCharge;
	public float jumpChargeRate;
	public float jumpChargeMax;
	public float defaultJump;
	private Vector3 jumpDirection;
	public bool canJump;

    public bool checkSwipe = true;
    private Vector3 startPos;
    private float startTime;
    private Vector3 swipeDirection = new Vector3(0,0,0);
    private float swipeForce = 0;
    public float bufferZone = 25; // Buffer for player to tap instead of swipe. Must exceed number inorder to begin the swipe
	#endregion

	#region Properties
	//Jumping
	public bool CanJump { get { return canJump; } set { canJump = value; } }
	public bool ChargeInputDown { get { return Input.GetMouseButton(0); } }
	#endregion

	protected InputManager(){}

	public void Reset()
	{
		ResetJump();
	}

	/// <summary>
	/// Should only reset input vars related to jumping
	/// </summary>
	public void ResetJump()
	{
		canJump = true;
		jumpCharge = defaultJump;
		jumpDirection = Vector3.one;
        checkSwipe = true;
        swipeForce = 0;
	}

	void Update()
	{
		//Should check for any inputs in the game

		if (canJump)
		{
			CheckJump();
		}

	}
		
	private void CheckJump()
	{

		if (ChargeInputDown )
		{
            if (checkSwipe) //If player is good to swipe, get all the swipe info and dont check again for a bit
            {
                startPos = Input.mousePosition;
                startTime = Time.time;
                checkSwipe = false;
            }
            if(Mathf.Abs(Vector3.Distance(startPos,Input.mousePosition))<bufferZone){ // Check if player tapped or swiped
			    if (jumpCharge < jumpChargeMax )
			    {
				    //Later this should be changed to a curve
				    jumpCharge += (jumpCharge * jumpChargeRate) * Time.deltaTime;
			    }
			    else
			    {
				    jumpCharge = jumpChargeMax;
			    }

			    //Set the jump direction
			    Vector3 touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));
			    jumpDirection = Vector3.Normalize(touchPosition - GameManager.Instance.player.Position);
                //checkSwipe = false;
            }

            else //Player swiped, reset jump
            {

               // print("ELSE");
                //ResetJump();
            }
		}
		else if (Input.GetMouseButtonUp(0))
		{
            if (Mathf.Abs(Vector3.Distance(startPos, Input.mousePosition)) < bufferZone)
            {
			    //Jump sucker you got nothing on me
			    if (MenuManager.Instance.CurrentScreen == "GameScreen")
			    {
                    //print("JumpDirection: " + jumpDirection + "\nJumpCharge: " + jumpCharge);
				    GameManager.Instance.player.Jump(jumpDirection, jumpCharge);
			    }
            
                canJump = false;
            }
            else if(!checkSwipe) //Player swiped, roll instead of jump
            {
                //print("SWIPE FORCE: " + swipeForce);
                swipeDirection = new Vector3(Input.mousePosition.y-startPos.y,0.0f,startPos.x-Input.mousePosition.x);
                swipeForce = Mathf.Sqrt(Vector3.SqrMagnitude(swipeDirection)) * (Time.time - startTime);
                swipeDirection.Normalize();
                GameManager.Instance.player.Roll(swipeDirection,swipeForce);

            }
		}
	}
}
