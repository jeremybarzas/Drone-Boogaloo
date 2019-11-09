using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractiableObs : MonoBehaviour
{
    public string m_actionCall;
    public UnityEvent m_action;
    private Mouledoux.Components.Mediator.Subscriptions m_subs = new Mouledoux.Components.Mediator.Subscriptions();

    private void Start()
    {
        m_subs.Subscribe(gameObject.GetInstanceID().ToString()+m_actionCall, delegate{ m_action.Invoke(); });
    }

    private void OnTriggerEnter(Collider other)
    {
        var ints = other.gameObject.GetComponent<DroneComponet>();
        if(ints != null)
        {
            ints.m_target = gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var ints = other.gameObject.GetComponent<DroneComponet>();
        if (ints != null)
        {
            ints.m_target = null;
        }
    }
}
