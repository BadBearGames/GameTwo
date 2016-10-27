using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Attached to main canvas in scene. Menu manager holds references to all ui screens.
/// Should cycle through ui in a stack. Holds methods to go to each screen and an all encompassing back method.
/// </summary>
public class MenuManager : Singleton<MenuManager>
{
	#region Fields
	//Screens
	Dictionary<string, GameObject> screens = new Dictionary<string, GameObject>();
	Stack<string> screenStack = new Stack<string>();
	#endregion

	#region Properties
	public Dictionary<string, GameObject> Screens { get { return screens; } }
	public string CurrentScreen { get { return screenStack.Peek(); } }
	#endregion

	protected MenuManager(){}

	void Awake()
	{
		//Load all screens below the canvas into a dictionary for reference
		for (int i = 0; i < gameObject.transform.childCount; i++)
		{
			screens.Add(gameObject.transform.GetChild(i).name, gameObject.transform.GetChild(i).gameObject);
		}
	}

	void Start()
	{
		GoToScreen("MainMenu");
	}

	/// <summary>
	/// goes to a screen given a name
	/// </summary>
	/// <param name="name">Name.</param>
	public void GoToScreen(string name)
	{
		if (screenStack.Count > 0)
		{
			screens[screenStack.Peek()].SetActive(false);
		}
		screenStack.Push(name);
		screens[name].SetActive(true);
	}

	public void Back()
	{
		screens[screenStack.Peek()].SetActive(false);
		screenStack.Pop();
		screens[screenStack.Peek()].SetActive(true);
	}
}
