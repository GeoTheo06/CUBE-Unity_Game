using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour {
	public Rigidbody rb;
	public Transform player;

	Vector3 initialPlayerPosition;

	public int upMoveForce = 4000;
	public int downMoveForce = -200;

	public float horizontalControl;

	public float continuousForce;
	public int horizontalMoveForce;

	public bool remainIdle;
	public bool playerIsOnFloor;
	public bool jump;
	public bool hasReachedMaxHeight;
	bool stopCounting;
	float timer;
	void Start() {
		horizontalMoveForce = PlayerPrefs.GetInt("horizontalControlForce");
		initialPlayerPosition = player.position;
		remainIdle = true;
		playerIsOnFloor = false;
		jump = false;
		hasReachedMaxHeight = false;
		stopCounting = false;
		timer = 0;
		continuousForce = 2500;
		horizontalControl = 0.5f;
		i = 1;
		i2 = 0;
	}

	private void Update() {
		horizontalMoveForce = PlayerPrefs.GetInt("horizontalControlForce");

		if (Input.touchCount == 1) {
			if (Input.GetTouch(0).phase == TouchPhase.Began) {
				Touch touch = Input.GetTouch(0);

				//if not touching UI
				if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId)) {
					clicked = true;
				}
			}
		}

		//if they're touching the ui while pressing to jump
		if (Input.touchCount == 2) {
			if (Input.GetTouch(1).phase == TouchPhase.Began) {
				Touch touch = Input.GetTouch(1);
				clicked = true;
			}
		}
	}

	public GameManager1 gameManager;
	bool goRight;
	bool goLeft;

	public void right() {
		goRight = true;
		goLeft = false;
	}
	public void left() {
		goLeft = true;
		goRight = false;
	}
	public void leftUp() {
		goLeft = false;
	}
	public void rightUp() {
		goRight = false;
	}

	public Joystick joystick;
	float i;
	float i2;
	public void FixedUpdate() //using FixedUpdate instead of Update to make physics smoother
	{
		continuousForce += 0.0001f;
		//this force is the one that makes the character go forward.
		rb.AddForce(continuousForce * Time.deltaTime, 0, 0);


		//Make character go left, right based on input
		if (goLeft && !goRight) {
			player.position = new Vector3(player.position.x, player.position.y, player.position.z + horizontalControl);
		}
		if (goRight && !goLeft) {
			player.position = new Vector3(player.position.x, player.position.y, player.position.z - horizontalControl);
		}

		//simulate gravity
		if (player.position.y < 2) {
			player.position = new Vector3(player.position.x, player.position.y - 0.5f, player.position.z);
		}

		//jump
		if (jump == true) {

			if (!hasReachedMaxHeight) {
				player.position = new Vector3(player.position.x, player.position.y + i, player.position.z);
				i -= 0.03f;
			} else {
				if (remainIdle) {
					rb.useGravity = false;

					if (!stopCounting) {
						timer += Time.deltaTime;
					}

					if (timer > 0.25) {
						stopCounting = true;
						remainIdle = false;
					}

				} else {
					rb.useGravity = true;
					player.position = new Vector3(player.position.x, player.position.y - i2, player.position.z);
					i2 += 0.03f;


					if (playerIsOnFloor) {
						playerIsOnFloor = false;
						hasReachedMaxHeight = false;
						jump = false;
						remainIdle = true;
						stopCounting = false;
						timer = 0;
						i = 1;
						i2 = 0;
					}
				}
			}

			if (player.position.y >= 18) {
				hasReachedMaxHeight = true;
			}
		}
	}

	public bool clicked = false;

	//make character jump on space bar
	void OnCollisionStay(Collision collisionInfo) {
		if (collisionInfo.collider.name == "Ground") {
			playerIsOnFloor = true;
		}

		if (collisionInfo.collider.tag == "ableToJumpOn" && clicked) {
			jump = true;
			clicked = false;
		}
	}

	private void OnCollisionExit(Collision collision) {
		if (collision.collider.name == "Ground") {
			playerIsOnFloor = false;
		}
	}
}