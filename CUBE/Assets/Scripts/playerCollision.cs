
using UnityEngine;

public class playerCollision : MonoBehaviour
{
	public Rigidbody rb;

	public PlayerMovement movement;
	public  GameManager1 gameManager;

	public Transform ground;
	public Transform ground1;
	public Transform lava;
	public Transform lava1;
	public Transform Wall1;
	public Transform Wall2;
	public Transform Wall3;
	public Transform Wall4;
	public Transform Wall5;
	public Transform Wall6;
	bool alreadyCollidedWithDeadlyCube = false;

	public AudioSource metalicHit;
	public AudioSource deadlyCubeHit;
	void OnCollisionEnter(Collision collisionInfo) {
			//If player touches ground or deadly obstacles he dies.
			if (collisionInfo.collider.tag == "GameOver Objects" && !alreadyCollidedWithDeadlyCube) {
				movement.enabled = false;
				movement.upMoveForce = 0; //Previous line doesn't work for jump (obviously) so I have to do it manually
				alreadyCollidedWithDeadlyCube = true;
				gameManager.RestartGame();
				deadlyCubeHit.Play();
			}

			//make infinite terrain
			if (collisionInfo.collider.name == "Ground (1)") {
				ground.position = new Vector3((ground1.position.x + ground.localScale.z), ground1.position.y, ground1.position.z);
				lava.position = new Vector3((lava1.position.x + ground.localScale.z), lava1.position.y, lava1.position.z);
				Wall1.position = new Vector3((Wall3.position.x + ground.localScale.z), Wall3.position.y, Wall3.position.z);
				Wall2.position = new Vector3((Wall4.position.x + ground.localScale.z), Wall4.position.y, Wall4.position.z);
				Wall5.position = new Vector3((Wall6.position.x + ground.localScale.z), Wall6.position.y, Wall6.position.z);
				metalicHit.Play();

			}

			if (collisionInfo.collider.name == "Ground") {
				ground1.position = new Vector3((ground.position.x + ground1.localScale.z), ground.position.y, ground.position.z);
				lava1.position = new Vector3((lava.position.x + ground.localScale.z), lava.position.y, lava.position.z);
				Wall3.position = new Vector3((Wall1.position.x + ground.localScale.z), Wall1.position.y, Wall1.position.z);
				Wall4.position = new Vector3((Wall2.position.x + ground.localScale.z), Wall2.position.y, Wall2.position.z);
				Wall6.position = new Vector3((Wall5.position.x + ground.localScale.z), Wall5.position.y, Wall5.position.z);
				metalicHit.Play();
			}
	}
}
