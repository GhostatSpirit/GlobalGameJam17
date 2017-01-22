using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {
	public float initialVelocity = 30f;
	public string shootTriggerName;
	public GameObject bulletPrefab;
	public float coolDownDelay = 5f;

	private bool m_isAxisInUse;
	//private bool isCooledDown;

	public bool isPS4Controller;

	public AudioClip shootSound;

	AudioSource myAudioSource;
	// Use this for initialization
	void Start () {
		//isCooledDown = true;
		myAudioSource = transform.parent.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {

		float triggerAxis = Input.GetAxis (shootTriggerName);
		//Debug.Log (triggerAxis);
		if(isPS4Controller){
			// -1 ~ 1 -> 0 ~ 1
			triggerAxis = triggerAxis / 2.0f + 0.5f;
		}

		if(Input.GetAxis(shootTriggerName) > 0.5f && !m_isAxisInUse){

			m_isAxisInUse = true;
			ShootWave ();

		}
		if(Input.GetAxis(shootTriggerName) == 0){
			m_isAxisInUse = false;
		}
	}

	void ShootWave(){
		if(bulletPrefab == null){
			return;
		}

		// check if there are enough bullets
		if(transform.parent.GetComponentInChildren<BulletInventSys>().GetBullet() > 0){
			// use 1 bullet
			transform.parent.GetComponentInChildren<BulletInventSys> ().UseBullet (1);
			// instantiate the bullet prefab
			GameObject bulletObj = Instantiate (bulletPrefab, transform.position, transform.rotation);
			// set init velocity of the bullet
			bulletObj.GetComponent<Rigidbody2D> ().velocity = transform.up.normalized * initialVelocity;
			// tell the bulletObj the init velocity
			bulletObj.GetComponent<BulletDeflect> ().initialVelocity = initialVelocity;
			// play shoot sound
			myAudioSource.PlayOneShot(shootSound);
		}
	}

	void CoolDown(){
		//isCooledDown = true;
	}
}
