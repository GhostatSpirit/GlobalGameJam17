using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class PlayerDeath : MonoBehaviour {
	public string enemyBulletTag;
	public GameObject deadPlayer;
	public Transform playerCamera;
	public Transform restartControl;
	// Use this for initialization]
	SpriteRenderer mySpriteRenderer;
	void Start () {
		mySpriteRenderer = GetComponent<SpriteRenderer> ();
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
		// 1. instantiate a dead player GameObject
		// 2. call the RespawnSys that this player has been dead
		// 3. add the score
		// 4. after respawn delay, respawn the player and destory the dead player GO
		GameObject deadPlayerGO = Instantiate(deadPlayer, transform.position, transform.rotation);
		playerCamera.GetComponent<Camera2DFollow> ().target = deadPlayerGO.transform;
		deadPlayerGO.transform.localScale = transform.localScale;

		// show restart screen
		restartControl.GetComponent<RestartControl> ().Restart ();


		Destroy (transform.gameObject);

	}
}
