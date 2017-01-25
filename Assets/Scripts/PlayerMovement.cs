// Script by Yang Liu
using UnityEngine;
using System.Collections;
using InControl;

public class PlayerMovement: MonoBehaviour {

    public float moveSpeed = 50f;

	// commented out Unity Input scripts
	// public string horizontalAxisName = "Horizontal";
	// public string verticalAxisName = "Vertical";
	public int playerIndex = 0;
	public Transform deviceAssigner;

	public enum Direction {UP, DOWN, LEFT, RIGHT};

	public Direction initialFacing = Direction.DOWN;
	//public Transform playerFeet;

	public Sprite[] upSprite;
	public Sprite[] downSprite;
	public Sprite[] leftSprite;
	public Sprite[] rightSprite;

	public float frameDuration = 0.16f;

	public bool moveEnabled;
	public bool turnEnabled;

	public AudioClip moveSound;
	// default: delay 1 second and play again
	public float playSoundGap = 1f;
	public float volumeScale = 0.8f;
	bool playingSound = false;

    Vector2 moveVector;
    Rigidbody2D myRigidbody;
	SpriteRenderer mySpriteRenderer;
	InputDevice myInputDevice;

	Direction lastDir;
	float deltaTime = 0f;
	int frameIter = 0;

	AudioSource myAudioSource;

	// Use this for initialization
	void Start () {
        myRigidbody = GetComponent<Rigidbody2D>();
		mySpriteRenderer = GetComponent<SpriteRenderer> ();
		myAudioSource = GetComponent<AudioSource> ();

		moveEnabled = true;
		turnEnabled = true;

		lastDir = initialFacing;

		if (initialFacing == Direction.DOWN) {
			mySpriteRenderer.sprite = downSprite[0];
		} else if (initialFacing == Direction.LEFT) {
			mySpriteRenderer.sprite = leftSprite[0];
		} else if (initialFacing == Direction.RIGHT) {
			mySpriteRenderer.sprite = rightSprite[0];
		} else if (initialFacing == Direction.UP) {
			mySpriteRenderer.sprite = upSprite[0];
		}
	}

	// Update is called once per frame
	void Update () {
		// get the axis values, construct a vector and normalize it
		// commented out Unity Input scripts
//		float horizontal = Input.GetAxis (horizontalAxisName);
//		float vertical = Input.GetAxis(verticalAxisName);
		myInputDevice = deviceAssigner.
						GetComponent<DeviceAssigner>().GetPlayerDevice(playerIndex);
		
		if(myInputDevice == null){
			return;
		}

		float horizontal = myInputDevice.LeftStickX;
		float vertical = myInputDevice.LeftStickY;

        moveVector = new Vector2(horizontal, vertical);

		if(moveVector.magnitude > 1f){
			moveVector.Normalize ();
		}


		if (moveVector.magnitude != 0f) {
			// change sprite according to moveVector
			Direction currentDir = Vector2Direction (moveVector);

			if (lastDir == currentDir) {
				deltaTime += Time.deltaTime;
				if (deltaTime > frameDuration) {
					// switch to the next Sprit
					deltaTime = 0;
					frameIter++;
					if (currentDir == Direction.DOWN) {
						if (frameIter >= downSprite.Length) {
							frameIter -= downSprite.Length;
						}
						mySpriteRenderer.sprite = downSprite [frameIter];
					} else if (currentDir == Direction.LEFT) {
						if (frameIter >= leftSprite.Length) {
							frameIter -= leftSprite.Length;
						}
						mySpriteRenderer.sprite = leftSprite [frameIter];
					} else if (currentDir == Direction.RIGHT) {
						if (frameIter >= rightSprite.Length) {
							frameIter -= rightSprite.Length;
						}
						mySpriteRenderer.sprite = rightSprite [frameIter];
					} else if (currentDir == Direction.UP) {
						if (frameIter >= upSprite.Length) {
							frameIter -= upSprite.Length;
						}
						mySpriteRenderer.sprite = upSprite [frameIter];
					}
				}
			} else {
				frameIter = 0;
				if (currentDir == Direction.DOWN) {
					mySpriteRenderer.sprite = downSprite [0];
				} else if (currentDir == Direction.LEFT) {
					mySpriteRenderer.sprite = leftSprite [0];
				} else if (currentDir == Direction.RIGHT) {
					mySpriteRenderer.sprite = rightSprite [0];
				} else if (currentDir == Direction.UP) {
					mySpriteRenderer.sprite = upSprite [0];
				}
				lastDir = currentDir;
			}

			// deal with sounds here
			if(!playingSound && moveVector.magnitude > 0.5f){
				playingSound = true;
				myAudioSource.PlayOneShot (moveSound, volumeScale);
				Invoke ("ResetSound", playSoundGap);
			}

		}

	}

    void FixedUpdate() {
		if(myInputDevice == null){
			return;
		}
		if (moveEnabled) {
			myRigidbody.velocity = moveVector * moveSpeed * Time.deltaTime * 10f;
		}

		

    }

	void ResetSound(){
		playingSound = false;
	}

	// translate a Direction enum to a normalized Vector3
	Direction Vector2Direction(Vector2 vec){
		if(vec.magnitude == 0f){
			Debug.Log ("Warning: vec.magnitude == 0f");
			return Direction.RIGHT;
		}

		Vector2 rightVector = new Vector2 (1f, 0f);

		float angle = Vector2.Angle (rightVector, vec);

		if(vec.y < 0f){
			angle = 360f - angle;
		}
		// play "going up" animation if angle between 45° and 135°
		// (= in radians, PI/4 and 3PI/4)
		if (angle > 45f && angle <= 135f)
		{
			return Direction.UP;// up
		}
		// play "going left" animation if angle between 135° and 225°
		// (= in radians, 3PI/4 and 5PI/4)
		else if (angle > 135f && angle <= 225f)
		{
			return Direction.LEFT;// left
		}
		// play "going down" animation if angle between 225° and 315°
		// (= in radians, 5PI/4 and 7PI/4)
		else if (angle > 225f && angle < 315f)
		{
			return Direction.DOWN;// down
		}
		else{
			return Direction.RIGHT;
		}


		//Debug.Log (angle);
	}
}

