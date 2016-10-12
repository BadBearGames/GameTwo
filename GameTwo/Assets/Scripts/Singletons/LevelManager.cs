using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

/// <summary>
/// Loads all scenes as levels and stores their data
/// </summary>
public class LevelManager : Singleton<LevelManager>
{
	#region Fields
	List<GameObject> levels = new List<GameObject>();
	#endregion

	#region Properties

	#endregion

	protected LevelManager(){}

	void Awake()
	{
		//Load levels
		/*for(int i = 1; i < SceneManager.sceneCountInBuildSettings; i++)
		{
			SceneManager.LoadSceneAsync(i, LoadSceneMode.Additive);
		}*/
	}
}
