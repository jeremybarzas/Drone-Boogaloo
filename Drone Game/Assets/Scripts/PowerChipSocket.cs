using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerChipSocket : MonoBehaviour
{
    [SerializeField] GameObject m_powerChip;
    [SerializeField] SignalTransmitter m_signalTransmitter;

    private void Update()
    {
        if (m_powerChip == null)
            m_signalTransmitter.PowerOff();
        else
            m_signalTransmitter.PowerOn();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("PowerChip")) return;
        if (m_powerChip == null)
            m_powerChip = other.gameObject;
    }
}
