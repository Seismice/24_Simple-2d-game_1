using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaneraFollow_1 : MonoBehaviour
{
    public Transform followTransform;
    public float smoothTime = 0.2f;
    public float yOffset = 1.5f;
    private Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        if (followTransform != null)
        {
            Vector3 targetPosition = new Vector3(followTransform.position.x, followTransform.position.y + yOffset, transform.position.z);
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
    }
}
