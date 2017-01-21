// Script by Yang Liu

using UnityEngine;
using System.Collections;

public class PlayerMovement: MonoBehaviour {

    public float moveSpeed = 50f;

	public string horizontalAxisName = "Horizontal";
	public string verticalAxisName = "Vertical";

	public enum Direction {UP, DOWN, LEFT, RIGHT};

	public Direction initialFacing = Direction.DOWN;
	//public Transform playerFeet;

	public Sprite upSprite;
	public Sprite downSprite;
	public Sprite leftSprite;
	public Sprite rightSprite;


	public bool moveEnabled;
	public bool turnEnabled;

    Vector2 moveVector;
    Rigidbody2D myRigidbody;
	SpriteRenderer mySpriteRenderer;


	// Use this for initialization
	void Start () {
        myRigidbody = GetComponent<Rigidbody2D>();

		mySpriteRenderer = GetComponent<SpriteRenderer> ();

		moveEnabled = true;
		turnEnabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		// get the axis values, construct a vector and normalize it
		float horizontal = Input.GetAxis (horizontalAxisName);
		float vertical = Input.GetAxis(verticalAxisName);
        moveVector = new Vector2(horizontal, vertical);

		if(moveVector.magnitude > 1f){
			moveVector.Normalize ();
		}


		if (moveVector.magnitude != 0f) {
			// change sprite according to moveVector
			Direction currentDir = Vector2Direction (moveVector);
			if (currentDir == Direction.DOWN) {
				mySpriteRenderer.sprite = downSprite;
			} else if (currentDir == Direction.LEFT) {
				mySpriteRenderer.sprite = leftSprite;
			} else if (currentDir == Direction.RIGHT) {
				mySpriteRenderer.sprite = rightSprite;
			} else if (currentDir == Direction.UP) {
				mySpriteRenderer.sprite = upSprite;
			}
		}

	}

    void FixedUpdate() {

		if (moveEnabled) {
			myRigidbody.velocity = moveVector * moveSpeed * Time.deltaTime * 10f;
		}

		

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
