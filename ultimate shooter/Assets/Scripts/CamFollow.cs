using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform target;  // The target object to follow
    private float smoothSpeed = 0.125f;  // The smoothness of the camera movement
    public Vector3 offset;  // The offset from the target position

    void LateUpdate()
    {
        if (target == null)
        {
            Debug.LogWarning("No target object set for CameraFollow script!");
            return;
        }

        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        //transform.LookAt(target);
    }
}
