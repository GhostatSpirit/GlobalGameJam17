using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeaconControl : MonoBehaviour {
	public Transform GridSystem;
	bool ignited = false;
	Player ignitingPlayer;

	public Sprite igniteSprite;
	public AudioClip igniteSound;

	AudioSource myAudioSource;
	SpriteRenderer mySpriteRenderer;
	void Start(){
		myAudioSource = GetComponent<AudioSource> ();
		mySpriteRenderer = GetComponent<SpriteRenderer> ();
	}

	void OnCollisionEnter2D(Collision2D coll){
		if(GridSystem.GetComponent<GridSystemControl>() != null && !ignited){
			if(coll.transform.tag == "1Pbullet"){
				ignitingPlayer = Player.Player1;
			} else if(coll.transform.tag == "2Pbullet"){
				ignitingPlayer = Player.Player2;
			} else{
				return;
			}
			if(ignited == false){
				// ignite the grid
				GridSystem.GetComponent<GridSystemControl> ().DrawGrid (ignitingPlayer);
				ignited = true;
				// play ignition sound
				myAudioSource.PlayOneShot(igniteSound);
				// switch sprite 
				mySpriteRenderer.sprite = igniteSprite;
				// switch box collider to polygon collider
				if(GetComponent<BoxCollider2D> () != null 
					&& GetComponent<PolygonCollider2D> () != null){
					GetComponent<BoxCollider2D> ().enabled = false;
					GetComponent<PolygonCollider2D> ().enabled = true;
				}

			}
		}
	}
}
