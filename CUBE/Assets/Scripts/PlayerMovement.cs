using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class PlayerMovement : MonoBehaviour
{
	public Rigidbody rb;
	public Transform player;
	public inGameOptions options;

	Vector3 initialPlayerPosition;
	Vector3 currentPlayerPosition;

	public int upMoveForce = 2000;
	public int downMoveForce = -100;

	public float continuousForce = 4000;
	public int horizontalMoveForce;

	
	void Start()
	{
		horizontalMoveForce = PlayerPrefs.GetInt("horizontalControlForce");
		initialPlayerPosition = player.position;
	}

	private void Update() {
		horizontalMoveForce = PlayerPrefs.GetInt("horizontalControlForce");
	}

	public GameManager1 gameManager;
	void FixedUpdate() //using FixedUpdate instead of Update to make physics smoother
	{
			currentPlayerPosition = player.position;

			continuousForce += 0.2f;

			//this force is the one that makes the character go forward.
			rb.AddForce(continuousForce * Time.deltaTime, 0, 0);

			
			//Make character go left, right based on input
			if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow)) {
			if (!options.unrealisticMovement) {
				rb.AddForce(0, 0, horizontalMoveForce * Time.deltaTime, ForceMode.VelocityChange); //forceMode.VelocityChange ignores the mass of our object.
			} else {
				player.position = new Vector3(player.position.x, player.position.y, player.position.z + 1f);
			}

			}
			if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow)) {
			if (!options.unrealisticMovement) {
				rb.AddForce(0, 0, -horizontalMoveForce * Time.deltaTime, ForceMode.VelocityChange);
			} else {
				player.position = new Vector3(player.position.x, player.position.y, player.position.z - 1f);
			}
		}
		//make collision (when falling from the edges - in experimental mode) with wall
		if (options.unrealisticMovement && player.position.y <= 2.4 && player.position.z <= 93.9) {
			player.position = new Vector3(player.position.x, player.position.y, player.position.z + 1);
		} else if (options.unrealisticMovement && player.position.y <= 2.4 && player.position.z >= -1.9) {
			player.position = new Vector3(player.position.x, player.position.y, player.position.z - 1);
		}

			//make player-fall -from jump- look more realistic
			if (((rb.position.y > 5) && (rb.velocity.y < 45)) || ((rb.velocity.y > -60) && (rb.velocity.y < -1.5))) //first case for when character has jumped so the velocity is big. Second case is for when the character is simply falling from the edge so the velocity is really small and hard to detect. The thrid case is there because of the bug where in the forth continuous jump the player jumped way to high for some reason
			{
				rb.AddForce(0, downMoveForce * Time.deltaTime, 0, ForceMode.VelocityChange);
			}
	}

	//make character jump on space bar
	void OnCollisionStay(Collision collisionInfo)
	{
			if (collisionInfo.collider.tag == "ableToJumpOn" && (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))) {
				rb.AddForce(0, upMoveForce * Time.deltaTime, 0, ForceMode.VelocityChange);
			}
	}

}
