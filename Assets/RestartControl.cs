﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using InControl;

public class RestartControl : MonoBehaviour {
	public GameObject Image;
	public GameObject Text;
	bool canRestart = false;
	// Use this for initialization
	void Start () {
		Image.SetActive (false);
		Text.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if(canRestart){
			if(InputManager.ActiveDevice.Action1.IsPressed){
					SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			}
		}
	}

	public void Restart(){
		Image.SetActive (true);
		Text.SetActive (true);
		canRestart = true;
	}
}
