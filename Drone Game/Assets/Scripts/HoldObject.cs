using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldObject : MonoBehaviour
{
    public GameObject m_heldObject;
    public GameObject prefab;

    private bool m_grabbing
    {
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

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Chip")) return;
        if (m_grabbing)
        {            
            other.transform.parent = transform;            
        }   
    }
}
