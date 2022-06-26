
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    void FixedUpdate() //it's being executed right after Update()
    {
        transform.position = target.position + offset;

        if (offset.x < 0)
        {
            offset.x += 0.08f;
        }
    }
}
