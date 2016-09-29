using UnityEngine;
using System.Collections;

/// <summary>
/// Handles main play cycle logic. Anything within game manager should happen during gameplay
/// and terminate when advancing to other menus.
/// </summary>
public class GameManager : Singleton<GameManager>
{
	#region Fields
	//Assigned in inspector
	public Player player;

	//Platform
	private Platform currentPlatform;

	//Objective
	public int score;
	#endregion

	#region Properties
	//Objective
	public int Score { get { return score; } }
	#endregion

	protected GameManager(){}

	void Awake()
	{
		StartRound();
	}

	void FixedUpdate()
	{
		if (currentPlatform != null)
		{
			float rate = 0.995f;
			currentPlatform.transform.localScale = new Vector3(currentPlatform.transform.localScale.x * rate, currentPlatform.transform.localScale.y, currentPlatform.transform.localScale.z * rate);
		}
	}

	/// <summary>
	/// Will be called in other places later on
	/// </summary>
	public void StartRound()
	{
		score = 0;
	}

	/// <summary>
	/// When the player lands on a new platform this should be called
	/// </summary>
	public void LandedOnNewPlatform(Platform platform)
	{
		if (!platform.HasLandedOn)
		{
			currentPlatform = platform;
			score++;
		}
		player.Land();
		InputManager.Instance.ResetJump();
	}
}
