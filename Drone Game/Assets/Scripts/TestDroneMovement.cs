﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDroneMovement : MonoBehaviour
{    
    public float m_moveSpeed = 1;
    public float m_turnSpeed = 1;
  
    void Update()
    {
        float inputY = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(0, 0, inputY);
        float inputX = Input.GetAxis("Horizontal");
        Vector3 turn = new Vector3(0, inputX, 0);
        transform.Translate(move * m_moveSpeed);
        transform.Rotate(turn * m_turnSpeed);
    }
}
