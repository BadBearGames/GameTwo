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

	//Spawn Timer
	private float spawnTimer = 1f; // in seconds
	private bool spawn = false;
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
		spawn = true;
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

		InputManager.Instance.ResetJump();
	}

	/// <summary>
	/// When the player lands on a new platform this should be called
	/// </summary>
	public void LandedOnNewPlatform(Platform platform)
	{
		if (!platform.HasLandedOn && MenuManager.Instance.CurrentScreen == "GameScreen")
		{
			SoundManager.Instance.PlaySfx("point");
			currentPlatform = platform;
			score++;
		}
		player.Land();
		if (MenuManager.Instance.CurrentScreen == "GameScreen")
		{
			InputManager.Instance.ResetJump();
		}
	}

	//comments need to happen guys
    public void CollectedCoin(Coin coin)
	{
        if (coin.IsCollected)
        {
			SoundManager.Instance.PlaySfx("coin");
            score += 10;
        }
    }

    void Update()
    {
        //check if player is dead and start new round if so
        if (player.IsDead) { StartRound(); }

		if (spawn && spawnTimer > 0f)
		{
			spawnTimer -= Time.deltaTime;

			if (spawnTimer <= 0f)
			{
				spawnTimer = 0f;
				spawn = false;
				StartRound();
			}
		}
    }
}
