using System.Collections;
using UnityEngine;

public class DelayEventOnStart : MonoBehaviour
{
    public float m_delay;

    [SerializeField]
    private bool m_onStart, m_selfDestruct;

    public UnityEngine.Events.UnityEvent m_action;

    private void OnEnable()
    {
        if(m_selfDestruct) m_action.AddListener(delegate{Destroy(this);});
        if(m_onStart) BeginCountdown();
    }

    public void BeginCountdown()
    {
        StartCoroutine(_BeginCountdown());
    }

	IEnumerator _BeginCountdown()
    {
		yield return new WaitForSeconds(m_delay);
        m_action.Invoke();
	}

    [ContextMenu("Invoke")]
    private void Invoke(){
        m_action.Invoke();
    }
}
