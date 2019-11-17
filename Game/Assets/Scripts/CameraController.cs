using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float spped = 2.0f;
    [SerializeField] Transform target;

    private void Awake()
    {
        if (!target) target = FindObjectOfType<CharMovement>().transform; 
    } 

    private void Update()
    {
        Vector3 position = target.position; position.z = -10.0F;
        transform.position = Vector3.Lerp(transform.position, position, spped * Time.deltaTime);
    }
}
