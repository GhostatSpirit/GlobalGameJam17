using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Soundtrack1 : MonoBehaviour 
{	
	public AudioClip playSound;
	AudioSource audioSource;


	void Start () 
	{
		audioSource = gameObject.AddComponent<AudioSource> ();
		audioSource.playOnAwake = false;
	}

	public void ring()
	{
			audioSource.PlayOneShot ( playSound );
	}

}
