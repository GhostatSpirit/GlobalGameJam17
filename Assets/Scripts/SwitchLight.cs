using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchLight : MonoBehaviour {
	public enum LightProperty {Player1, Player2};
	public LightProperty lightProperty;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "1Pbullet" && lightProperty == LightProperty.Player2){
			Destroy (transform.gameObject);
		} else if(other.tag == "2Pbullet" && lightProperty == LightProperty.Player1){
			Destroy (transform.gameObject);
		}

	}
}
