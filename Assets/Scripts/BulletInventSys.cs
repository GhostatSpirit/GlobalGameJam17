using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletInventSys : MonoBehaviour {
	// Tag for this player's bullet
	public string bulletTag = "1Pbullet";
	// Num of bullets player initially have
	public int initBulletCount = 1;
	int bulletCount = 0;
	// distance when player can retrieve the bullet
	public float retrieveDist = 2.0f;
	// attract force
	//public float attractForce = 2.0f;
	//bool leftTrigger = false;
	//bool enteredTrigger = false;
	//Hashtable bulletSet = new Hashtable();
	public float regenerateDelay = 5f;

	public Text bulletStatusText;

	void Start(){
		bulletCount = initBulletCount;
		bulletStatusText.text = "Bullet: " + bulletCount.ToString ();
	}

	void OnTriggerLeave2D(Collider2D other){
//		if(bulletSet.Contains(other.gameObject)){
//			bulletSet.Remove (other.gameObject);
//		}
	}

	void OnTriggerEnter2D(Collider2D other){
//		if (!bulletSet.Contains (other.gameObject)) {
//			bulletSet.Add (other.gameObject, other.gameObject);
//		}
	}

	void OnTriggerStay2D(Collider2D other){
		if(other.tag == bulletTag){
			if(!other.transform.GetComponent<BulletInitCoolDown>().isCooledDown()){
				// if the bullet hasn't been cooled down, just return and wait
				return;
			}

			// first check the dist and see if we could retrieve the bullet
			//Debug.Log (Vector2.Distance (other.transform.position, transform.position));
			if (Vector2.Distance (other.transform.position, transform.position) <= retrieveDist){
				// retrieve the bullet
				Debug.Log ("bullet in");
				AddBullet (1);
//				bulletSet.Remove (other.gameObject);
				Destroy (other.gameObject);
				return;
			}
//			// if we cannot retrieve the bullet yet, try to attract it
//			Vector2 forceDir = transform.position - other.transform.position;
//			float distance = forceDir.magnitude;
//			forceDir = forceDir.normalized;
//
//			Rigidbody2D bulletRigid = other.GetComponent<Rigidbody2D> ();
//			bulletRigid.AddForce (forceDir * attractForce / distance);

		}
	}


//	void FixedUpdate(){
//		// add force to each of the bullets in range
//		foreach(DictionaryEntry de in bulletSet){
//			GameObject bulletGO = de.Key as GameObject;
//			if(bulletGO == null){
//				bulletSet.Remove (bulletGO);
//				continue;
//			}
//			Vector2 forceDir = transform.position - bulletGO.transform.position;
//			float distance = forceDir.magnitude;
//			forceDir = forceDir.normalized;
//
//			Rigidbody2D bulletRigid = bulletGO.GetComponent<Rigidbody2D> ();
//			bulletRigid.AddForce (forceDir * attractForce / distance);
//		}
//	}

	public void BulletConsumed(){
		Invoke ("AddOneBullet", regenerateDelay);
		bulletStatusText.text = "Reloading...";
	}

	void AddOneBullet(){
		bulletCount++;
		bulletStatusText.text = "Bullet: " + bulletCount.ToString ();
	}

	public void AddBullet(int addCount){
		bulletCount += addCount;
		bulletStatusText.text = "Bullet: " + bulletCount.ToString ();
	}

	public void UseBullet(int minusCount){
		bulletCount -= minusCount;
		bulletStatusText.text = "Bullet: " + bulletCount.ToString ();
	}

	public int GetBullet(){
		return bulletCount;
	}

}
