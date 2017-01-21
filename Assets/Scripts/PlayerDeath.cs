using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour {
	public string enemyBulletTag;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D coll){
		if(coll.transform.tag == enemyBulletTag){
			// the player has crushed into an enemy bullet
			// she is dead now
			KillPlayer ();
		}
	}

	void KillPlayer(){
		GetComponent<PlayerMovement> ().moveEnabled = false;
		GetComponent<SpriteRenderer> ().color = Color.red;
	}
}
