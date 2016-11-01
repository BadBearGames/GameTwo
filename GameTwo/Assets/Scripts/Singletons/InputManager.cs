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
    private Vector2 startPos;
    private float startTime;

    public float bufferZone = 50; // Buffer for player to tap instead of swipe. Must exceed number inorder to begin the swipe
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
	}

	void Update()
	{
		//Should check for any inputs in the game

		if (canJump)
		{
			CheckJump();
		}
        print("TIME: " + Mathf.Abs(Time.time - startTime)+"\nCheckSwipe: "+checkSwipe);
        if (Mathf.Abs(Time.time - startTime) > 1)
        {
            checkSwipe = true;
        }
	}
		
	private void CheckJump()
	{

		if (ChargeInputDown )
		{
            if (checkSwipe)
            {
                startPos = Input.mousePosition;
                startTime = Time.time;
                checkSwipe = false;
            }
            
            if(Vector2.Distance(startPos,Input.mousePosition)<bufferZone){
                print(Vector2.Distance(startPos, Input.mousePosition));
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
            else
            {
                jumpCharge = 0;
                Gizmos.DrawLine(startPos, Input.mousePosition);
            }
		}
		else if (Input.GetMouseButtonUp(0))
		{
			//Jump sucker you got nothing on me
			if (MenuManager.Instance.CurrentScreen == "GameScreen")
			{
				GameManager.Instance.player.Jump(jumpDirection, jumpCharge);
			}
			canJump = false;
		}
	}
}
