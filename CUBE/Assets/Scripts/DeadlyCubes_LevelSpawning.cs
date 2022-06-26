using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadlyCubes_LevelSpawning : MonoBehaviour
{
    public Transform player;
    public Transform level1;
    public Transform level2;
    public Transform level3;
    public Transform level4;
    public Transform level5;
    public Transform level6;
    public Transform level7;
    public Transform level8;
    public Transform level9;
    public Transform level10;
    public Transform level11;

    public int nextSpawnObjectDistance;
    public int distanceBetweenPlayerAndNextObjectSpawnPoint;
    void Start()
    {
        nextSpawnObjectDistance = 250; //The x coord in which the first object will spawn
        distanceBetweenPlayerAndNextObjectSpawnPoint = 400; //distance between the player and the spawn of the next level.
    }
    public int i = 0;
    int[] previousLevelSpawnNumber = new int [2];
    public int randomLevelSpawnNumber;
    void FixedUpdate()
    {
        if (player.position.x > nextSpawnObjectDistance - distanceBetweenPlayerAndNextObjectSpawnPoint)
        {
            randomLevelSpawnNumber = Random.Range(1, 12);
            if (previousLevelSpawnNumber[0] != randomLevelSpawnNumber && previousLevelSpawnNumber[1] != randomLevelSpawnNumber && randomLevelSpawnNumber != 7) 
            {
                if (randomLevelSpawnNumber == 1)
                {
                    level1.transform.position = new Vector3(nextSpawnObjectDistance, level1.position.y, level1.position.z);
                } else if (randomLevelSpawnNumber == 2)
                {
                     //distance between parent object and first object of the level. (The middle of the level and the start of the level)
                    level2.transform.position = new Vector3(nextSpawnObjectDistance, level2.position.y, level2.position.z);
                    nextSpawnObjectDistance += 110; //Level Length
                } else if (randomLevelSpawnNumber == 3)
                {
                    level3.transform.position = new Vector3(nextSpawnObjectDistance, level3.position.y, level3.position.z);
                    nextSpawnObjectDistance += 40;
                } else if (randomLevelSpawnNumber == 4)
                {
                    level4.transform.position = new Vector3(nextSpawnObjectDistance, level4.position.y, level4.position.z);
                } else if (randomLevelSpawnNumber == 5)
                {
                    level5.transform.position = new Vector3(nextSpawnObjectDistance, level5.position.y, level5.position.z);
                    nextSpawnObjectDistance += 190;
                } else if (randomLevelSpawnNumber == 6)
                {
                    level6.transform.position = new Vector3(nextSpawnObjectDistance, level6.position.y, level6.position.z);
                    nextSpawnObjectDistance += 340;

                } else if (randomLevelSpawnNumber == 7)
                {
                    level7.transform.position = new Vector3(nextSpawnObjectDistance, level7.position.y, level7.position.z);
                    nextSpawnObjectDistance += 170;
                } else if (randomLevelSpawnNumber == 8)
                {
                    level8.transform.position = new Vector3(nextSpawnObjectDistance, level8.position.y, level8.position.z);
                } else if (randomLevelSpawnNumber == 9)
                {
                    level9.transform.position = new Vector3(nextSpawnObjectDistance, level9.position.y, level9.position.z);
                } else if (randomLevelSpawnNumber == 10)
                {
                    level10.transform.position = new Vector3(nextSpawnObjectDistance, level10.position.y, level10.position.z);
                    nextSpawnObjectDistance += 170;
                } else if (randomLevelSpawnNumber == 11)
                {
                    level11.transform.position = new Vector3(nextSpawnObjectDistance, level11.position.y, level11.position.z);
                    nextSpawnObjectDistance += 180;
                }
                nextSpawnObjectDistance += 150; //gap between current level and next
                previousLevelSpawnNumber[i] = randomLevelSpawnNumber;
                if (i == 0)
                {
                    i++;
                } else
                {
                    i = 0;
                }
            }
        }
    }
}
