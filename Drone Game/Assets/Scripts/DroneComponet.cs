using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneComponet : MonoBehaviour
{
    public string m_actionCall;
    public GameObject m_target;

    [ContextMenu("Use Tool")]
    public void OnInvokePart()
    {
        Mouledoux.Components.Mediator.instance.NotifySubscribers(m_target.GetInstanceID().ToString() + m_actionCall);
    }
}
