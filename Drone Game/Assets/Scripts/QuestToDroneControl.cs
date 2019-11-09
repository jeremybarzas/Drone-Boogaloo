using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestToDroneControl : MonoBehaviour
{
    private bool m_grabbing {
        get
        {
            if(OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) && OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger))
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

        }
    }

}
