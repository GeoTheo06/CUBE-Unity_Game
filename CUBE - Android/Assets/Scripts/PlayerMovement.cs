using UnityEngine;
using UnityEngine.UI;

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
	}

	private void Update() {
		horizontalMoveForce = PlayerPrefs.GetInt("horizontalControlForce");
	}

	public GameManager1 gameManager;

	public Joystick joystick;
	public void FixedUpdate() //using FixedUpdate instead of Update to make physics smoother
	{

		//this force is the one that makes the character go forward.
		rb.AddForce(continuousForce * Time.deltaTime, 0, 0);


		//Make character go left, right based on input
		if (joystick.Horizontal <= -0.7f) {
			player.position = new Vector3(player.position.x, player.position.y, player.position.z + horizontalControl);
		}
		if (joystick.Horizontal >= 0.7f) {
			player.position = new Vector3(player.position.x, player.position.y, player.position.z - horizontalControl);
		}

		//jump
		if (jump == true) {

			if (!hasReachedMaxHeight) {
				player.position = new Vector3(player.position.x, player.position.y + 1, player.position.z);
			} else {
				if (remainIdle) {
					rb.useGravity = false;

					if (!stopCounting) {
						timer += Time.deltaTime;
					}

					if (timer > 0.5) {
						stopCounting = true;
						remainIdle = false;
					}

				} else {
					rb.useGravity = true;
					player.position = new Vector3(player.position.x, player.position.y - 0.2f, player.position.z);

					if (playerIsOnFloor) {
						playerIsOnFloor = false;
						hasReachedMaxHeight = false;
						jump = false;
						remainIdle = true;
						stopCounting = false;
						timer = 0;
					}
				}
			}

			if (player.position.y >= 18) {
				hasReachedMaxHeight = true;
			}
		}
	}

	public bool clicked = false;
	public void onClick() {
		clicked = true;
	}

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