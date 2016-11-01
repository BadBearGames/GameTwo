using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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

    //levels
    public int level;
    public List<GameObject> levels;

	//Objective
	public int score;
	public float timer;
	bool enableTimer;

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
        level = 0;
	}

	/// <summary>
	/// Will be called in other places later on
	/// </summary>
	public void StartRound()
	{
        //set score to zero
		score = 0;
		timer = 0.00f;
		enableTimer = true;

        //set player to not be dead
        player.IsDead = false;

		InputManager.Instance.ResetJump();
	}

    /// <summary>
    /// starts round, and moves us to the next level
    /// </summary>
    public void NextLevel()
    {
        //move player
        player.transform.position = new Vector3(20, -.4f, .5f);
        //save current score
        int save = score;

        //start a new round
        StartRound();

        //turn off current level
        levels[level].SetActive(false);

        //up the current level
        level++;

        if(level == levels.Count) //check if we are at the end of the levels
        {
            level = 0; //goto beginign again
        }

        //set the new current level active
        levels[level].SetActive(true);

        //give back score
        score = save;
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
            score += 9;
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

		//increase timer
		if (enableTimer)
		{
			timer += Time.deltaTime;
		}
    }
}
