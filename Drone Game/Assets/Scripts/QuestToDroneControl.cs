using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestToDroneControl : MonoBehaviour
{
    public float m_handpower = 10;
    public float m_lockDown = 45;
    private Vector3 m_lastPostion;

    private bool m_grabbing {
        get
        {
            // PC testing edit
            if (Input.GetKeyDown("Space")) return true;

            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) && OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        var hand = other.gameObject.GetComponent<OVRControllerHelper>();
        if(hand == null) { return; }

        if (m_grabbing)
        {
            var dist = (hand.transform.position - transform.position) * m_handpower;

            transform.eulerAngles = new Vector3(Mathf.Clamp(dist.x, -m_lockDown, m_lockDown), 0, Mathf.Clamp(dist.z, -m_lockDown, m_lockDown));
        }
    }

}
