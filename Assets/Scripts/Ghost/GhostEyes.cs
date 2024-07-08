using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GhostEyes : MonoBehaviour
{
    public GameObject eye;

    // The speed of rotation
    public float rotationSpeed = 10f;
    // The radius of the orbit
    public float orbitRadius = 5f;

    private float angle = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        angle += rotationSpeed * Time.deltaTime;

        float x = eye.transform.position.x + Mathf.Sin(angle) * orbitRadius;
        float z = eye.transform.position.z;
        float y = eye.transform.position.y + Mathf.Cos(angle) * orbitRadius; // Keep the same height as the central sphere

        transform.DORotate(new Vector3(x, y, z), 0.1f);
    }
}
