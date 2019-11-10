using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabJoystick : MonoBehaviour
{
    [SerializeField] Transform m_anchorTransform;
    [SerializeField] Transform m_defaultTransform;
    [SerializeField] Transform m_referenceTransform;

    private void Awake()
    {
        if (m_referenceTransform == null)
            m_referenceTransform = m_defaultTransform;
    }

    private bool m_grabbing {
        get
        {
            // PC testing edit
            //if (Input.GetKey(KeyCode.Space))
            //    return true;
            //else
            //    return false;

            while (OVRInput.Get(OVRInput.Button.PrimaryHandTrigger) || OVRInput.Get(OVRInput.Button.SecondaryHandTrigger))
            {               
                return true;
            }
            return false;
        }
    }

    private void Update()
    {
        if (m_grabbing)
            m_anchorTransform.LookAt(m_referenceTransform);
        else
            m_anchorTransform.LookAt(m_defaultTransform);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Controller")) return;    

        var hand = other.gameObject.transform;
        if (hand == null) { return; }

        m_referenceTransform = hand.transform;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Controller")) return;
        Debug.Log("Controller leaving me");
        m_referenceTransform = m_defaultTransform;
    }
}
