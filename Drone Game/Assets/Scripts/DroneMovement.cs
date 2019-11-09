using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneMovement : MonoBehaviour
{
    public Transform m_controlReference;
    public float m_speed = 1f;
    public float m_rotationSpeed = 1f;
    private Quaternion m_origin;
    private Rigidbody m_rigid;

    void Start()
    {
        m_origin = m_controlReference.rotation;
        m_rigid = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 movement = Vector3.zero;
        float rotation = m_controlReference.rotation.z * m_rotationSpeed;


        movement += transform.forward * m_speed * m_controlReference.rotation.x;

        transform.Rotate(new Vector3(0, rotation, 0));

        m_rigid.AddForce(movement * 50);
    }
}
