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
	}

	public void StartGame()
	{
		MenuManager.Instance.GoToScreen("GameScreen");
		StartRound();
	}

	/// <summary>
	/// Will be called in other places later on
	/// </summary>
	public void StartRound()
	{
        //set score to zero
		score = 0;

        //set player to not be dead
        player.IsDead = false;
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

    void Update()
    {
        //check if player is dead and start new round if so
        if (player.IsDead) { StartRound(); }
    }
}
