using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerConsole : MonoBehaviour
{
    [SerializeField] List<SignalTransmitter> m_signalTowers;
    [SerializeField] List<PowerChipSocket> m_powerChipSockets;

    private void Awake()
    {
        m_signalTowers = new List<SignalTransmitter>();
        m_powerChipSockets = new List<PowerChipSocket>();
    }
}
