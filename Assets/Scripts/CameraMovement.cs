using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public float smooth;
    public Vector2 max;
    public Vector2 min;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position != target.position)
        {
            Vector3 TARGET = new Vector3(target.position.x, target.position.y, transform.position.z);
            TARGET.x = Mathf.Clamp(TARGET.x, min.x, max.x);
            TARGET.y = Mathf.Clamp(TARGET.y, min.y, max.y);
            transform.position = Vector3.Lerp(transform.position, TARGET, smooth);
        }
    }
}
