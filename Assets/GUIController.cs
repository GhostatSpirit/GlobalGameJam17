using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GUIController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void LoadScene(int sceneIndex){
		SceneManager.LoadScene (sceneIndex);
	}

	public void QuitApp(){
		Application.Quit ();
	}
}