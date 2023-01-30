using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovment : MonoBehaviour
{
    private Transform lookAt;
    private Vector3 startOffset;
    void Start()
    {
       lookAt = GameObject.FindGameObjectWithTag("Player").transform;
        startOffset = transform.position - lookAt.position;


    }

    
    void Update()
    {
        transform.position = lookAt.position + startOffset;
    }
    
}
