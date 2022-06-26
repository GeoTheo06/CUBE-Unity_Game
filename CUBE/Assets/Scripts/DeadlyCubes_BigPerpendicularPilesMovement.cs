using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadlyCubes_BigPerpendicularPilesMovement : MonoBehaviour
{
    public Transform player;
    public Transform parent;
    bool addAFive;

    public GameManager1 gameManager;
    void FixedUpdate()
    {
            if (player.position.x > parent.position.x + 180) {
                float randomZCoord = Random.Range(0, 9); //distance from the right to the left side of the floor

                int decideIfTheRandomsHaveAFive = Random.Range(0, 2);
                if (decideIfTheRandomsHaveAFive == 0) {
                    transform.position = new Vector3(transform.position.x, transform.position.y, (randomZCoord * 10) + 5);
                } else {
                    transform.position = new Vector3(transform.position.x, transform.position.y, randomZCoord * 10);
                }
        }
    }
}
