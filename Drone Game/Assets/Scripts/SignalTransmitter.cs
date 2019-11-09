using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class SignalTransmitter : MonoBehaviour
{
    SphereCollider m_signalArea;
    [SerializeField] bool isTransmitting;
    [SerializeField] DroneSignalReciever m_droneReciever;
    float m_signalStrength;

    public float SignalStength => (m_signalStrength);

    private void Start()
    {
        m_signalArea = GetComponent<SphereCollider>();    
    }

    private void Update()
    {
        if (!isTransmitting && m_signalArea.enabled)
            m_signalArea.enabled = false;
        if (isTransmitting && !m_signalArea.enabled)
            m_signalArea.enabled = true;

        if (!isTransmitting) return;

        SignalStrengthCalculator();
    }

    public void TransmitterOn()
    {
        isTransmitting = true;
    }

    public void TransmitterOff()
    {
        isTransmitting = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("DroneReciever")) return;

        m_droneReciever = other.gameObject.GetComponent<DroneSignalReciever>();
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("DroneReciever")) return;
        m_droneReciever = null;
    }

    void SignalStrengthCalculator()
    {
        if (m_droneReciever == null) return;

        var drone = m_droneReciever.gameObject.transform.position;
        m_signalStrength = Vector3.Distance(drone, transform.position);        
    }
}
