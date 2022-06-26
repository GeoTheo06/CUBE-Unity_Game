using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deadlyCubesMovement : MonoBehaviour
{
	public float speed;

	//float[] randomYvalues = new float[10];
	private void Start()
	{
		/*for (int i = 0; i < 10; i++)
		{
			randomYvalues[i] = Random.Range(0.01f, 0.101f);//from 0.01 to 0.1
		}*/
		float randomSpeedNumber = Random.Range(0.01f, 0.101f);//from 0.01 to 0.1
		speed = randomSpeedNumber;
	}

	bool goingRight = true;

	public GameManager1 gameManager;
	private void FixedUpdate()
	{
			Vector3 currentCubePosition = transform.localPosition;

			Vector3 localPosition_LeftSide = new Vector3(currentCubePosition.x, currentCubePosition.y, 15.1f);
			Vector3 localPosition_RightSide = new Vector3(currentCubePosition.x, currentCubePosition.y, 3.31f);

			if (goingRight) {
				transform.localPosition = Vector3.MoveTowards(currentCubePosition, localPosition_RightSide, speed); //I need local position because the object is under a parent, so "local position" != "world position"
				if (currentCubePosition.z == localPosition_RightSide.z) {
					goingRight = false;
				}

			} else {
				transform.localPosition = Vector3.MoveTowards(currentCubePosition, localPosition_LeftSide, speed);
				if (currentCubePosition.z == localPosition_LeftSide.z) {
					goingRight = true;
				}
			}
	}
}
