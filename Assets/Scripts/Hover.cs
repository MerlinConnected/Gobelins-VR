using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : MonoBehaviour
{
    public float hoverHeight = 0.2f;
    public float hoverSpeed = 1f;
    public float tiltAngle = 10.0f;
    public float tiltSpeed = 0.5f;

    private Vector3 startPosition;
    private Quaternion startRotation;
    private float hoverOffset;
    private float tiltOffset;

    void Start()
    {
        startPosition = transform.position;
        startRotation = transform.rotation;

        hoverOffset = Random.Range(0.0f, 2.0f * Mathf.PI);
        tiltOffset = Random.Range(0.0f, 2.0f * Mathf.PI);
    }

    void Update()
    {
        float newY = startPosition.y + (Mathf.Sin((Time.time + hoverOffset) * hoverSpeed) * hoverHeight);

        float tiltX = Mathf.Sin((Time.time + tiltOffset) * tiltSpeed) * tiltAngle;
        float tiltZ = Mathf.Cos((Time.time + tiltOffset) * tiltSpeed * 0.7f) * tiltAngle;

        Quaternion tilt = Quaternion.Euler(tiltX, 0, tiltZ);

        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
        transform.rotation = startRotation * tilt;
    }
}
