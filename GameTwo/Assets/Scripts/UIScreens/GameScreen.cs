using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameScreen : UIScreen
{
	#region Fields
	public Text scoreText;
	#endregion

	void Update()
	{
		scoreText.text = GameManager.Instance.Score.ToString();
	}
}
