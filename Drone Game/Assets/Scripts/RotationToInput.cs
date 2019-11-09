using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationToInput : MonoBehaviour
{
    Transform m_reference;

    private void Awake()
    {
        if (m_reference == null)
            m_reference = transform;
    }

    void Update()
    {
        GetInput();   
    }

    public float GetInput()
    {
        Vector3 currRot = new Vector3(m_reference.rotation.x, m_reference.rotation.y, m_reference.rotation.z);

        float value = Vector3.Distance(currRot, Vector3.zero);

        if (value == 0f) return 0;

        Debug.Log(value.ToString());

        return value;
    }
}
