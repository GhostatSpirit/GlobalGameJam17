using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroyer : MonoBehaviour {

    public int maxDeflectCount = 10;
    public float maxDistance = 100f;

    private Vector2 initialPos;
	private int deflectCount = 0;

	// Use this for initialization
	void Start () {
        initialPos = transform.position;
	}
	
	void FixedUpdate () {
		float dist = Vector2.Distance (initialPos, transform.position);
		if(dist >= maxDistance){
			Destroy (transform.gameObject);
		}
	}

    void OnCollisionEnter2D(Collision2D coll) {
		deflectCount++;
		if(deflectCount >= maxDeflectCount){
			Destroy (transform.gameObject);
		}
    }
}
