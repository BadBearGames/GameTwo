using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Should load all sound files from resources and store them in a dictionary on awake.
/// A play sound method should be defined for looping and one shot sounds.
/// Any calls to sound manager should be made in code.
/// Any ui sounds will be handled seperately through canvas.
/// </summary>
public class SoundManager : Singleton<SoundManager>
{
	#region Fields
	private AudioSource sfxSource;

	private AudioClip musicClip;
	private Dictionary<string, AudioClip> effects = new Dictionary<string, AudioClip>();
	#endregion

	protected SoundManager() {}

	void Awake()
	{
		DontDestroyOnLoad(this);
	}

	void Start()
	{
		//Just add the audio source
		sfxSource = gameObject.AddComponent<AudioSource>();

		//init clips
		effects.Add("coin", Resources.Load("Sfx/coin") as AudioClip);
		effects.Add("point", Resources.Load("Sfx/point") as AudioClip);
		effects.Add("jump", Resources.Load("Sfx/jump") as AudioClip);
		effects.Add("die", Resources.Load("Sfx/die") as AudioClip);
	}

	public void PlaySfx(string name)
	{
		sfxSource.PlayOneShot(effects[name]);
	}
}
