﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotion : MonoBehaviour
{
    private Transform lookAt;
    private Vector3 startOffset;
    private Vector3 moveVector;

    private float transition = 0.0f;
    private float animationDuration = 1.0f;
    private Vector3 animationCameraOffset = new Vector3(0, 0, 4); 

    void Start()
    {
        lookAt = GameObject.FindGameObjectWithTag ("Player").transform;
        startOffset = transform.position - lookAt.position;
    }

    void Update()
    {
        moveVector = lookAt.position + startOffset;
        //x
        moveVector.x = 0;
        //y
        moveVector.y = Mathf.Clamp(moveVector.y, 2, 4); //3 i 5 default

        if (transition > 1.0f)
        {
            transform.position = moveVector;
        }
        else
        {
            transform.position = Vector3.Lerp(moveVector
                + animationCameraOffset, moveVector, transition);
            transition += Time.deltaTime * 1 / animationDuration;
            transform.LookAt(lookAt.position + Vector3.up);
        }
    }
}
