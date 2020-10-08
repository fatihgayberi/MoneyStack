using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed;
    public Vector3 offset;
    public Vector3 perspctive;

    private void Start()
    {
        PerspectiveSettings();
    }

    private void LateUpdate()
    {
        Follow();
    }

    // kamera takibini yapar
    void Follow()
    {
        Vector3 desiredPosition = offset + new Vector3(target.position.x / 8, target.position.y, target.position.z);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * smoothSpeed);
        transform.position = smoothedPosition;
    }

    // kameranin perspektifini ayarlar 
    void PerspectiveSettings()
    {
        transform.rotation = Quaternion.Euler(perspctive);
    }
}
