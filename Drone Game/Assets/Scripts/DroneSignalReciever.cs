using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class DroneSignalReciever : MonoBehaviour
{
    [SerializeField] bool m_hasSignal;
    [SerializeField]SignalTransmitter m_closetTransmitter;
    [SerializeField]List<SignalTransmitter> m_inRangeTransmitters;

    public bool HasSignal => (HasSignal);
    public SignalTransmitter ClosestTransmitter => (m_closetTransmitter);

    private void Awake()
    {
        m_inRangeTransmitters = new List<SignalTransmitter>();
    }

    private void Update()
    {
        if (m_inRangeTransmitters.Count <= 0)
        {
            m_hasSignal = false;
            return;
        }
        else
            m_hasSignal = true;

        if (!m_hasSignal)
            GetComponentInParent<TestDroneMovement>().enabled = false;
        else
            GetComponentInParent<TestDroneMovement>().enabled = true;

        CheckSignalStrength();
    }

    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("SignalArea")) return;
        if (m_inRangeTransmitters.Count <= 0)
        {
            m_inRangeTransmitters.Add(other.gameObject.GetComponent<SignalTransmitter>());
            m_closetTransmitter = other.gameObject.GetComponent<SignalTransmitter>();
        }
        if (!m_inRangeTransmitters.Contains(other.gameObject.GetComponent<SignalTransmitter>()))
        {
            m_inRangeTransmitters.Add(other.gameObject.GetComponent<SignalTransmitter>());
        }   
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("SignalArea")) return;
        if (m_inRangeTransmitters.Count <= 0) return;
        if (!m_inRangeTransmitters.Contains(other.gameObject.GetComponent<SignalTransmitter>()));
            m_inRangeTransmitters.Add(other.gameObject.GetComponent<SignalTransmitter>());
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("SignalArea")) return;
        if (m_inRangeTransmitters.Count <= 0) return;
        m_inRangeTransmitters.Remove(other.gameObject.GetComponent<SignalTransmitter>());
    }

    void CheckSignalStrength()
    {
        if (m_inRangeTransmitters.Count <= 0) return;
        if (m_closetTransmitter == null)
            m_closetTransmitter = m_inRangeTransmitters[0];
        foreach (SignalTransmitter st in m_inRangeTransmitters)
        {
            if (m_closetTransmitter.SignalStength > st.SignalStength)
                m_closetTransmitter = st;
        }
    }
}
