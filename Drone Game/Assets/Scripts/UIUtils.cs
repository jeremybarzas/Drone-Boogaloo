using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class UIUtils : MonoBehaviour
{
    private static Transform m_playerTransform;

    public void RotateDoor(Transform t)
    {
        t.Rotate(0, 180, 0);
    }

    public void MoveToGarage(Transform t)
    {
        t.localPosition = new Vector3(t.localPosition.x, -10.5f, t.localPosition.z);
    }

    public void MoveToCommand(Transform t)
    {
        t.localPosition = new Vector3(t.localPosition.x, 0.5f, t.localPosition.z);
    }

    public void TeleportPlayer(Transform t)
    {
        if(m_playerTransform == null)
        {
            m_playerTransform = FindObjectOfType<OVRManager>().transform;
        }

        m_playerTransform.position = t.position;
    }

    private IEnumerator WaitForAnimator(Animator a){
        
        yield return new WaitUntil(() => a.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1);
    }

    public void SetSceneMessage(string s){
        SceneLoader._instance.SetSoloMessage(s);
    }

    public void GoToScene(int index)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(index);
    }

    public void GoToScene(string name)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(name);
    }

    public void ReloadCurrentScene()
    {
        GoToScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    public void GoToScene(Dropdown dropdown)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(dropdown.captionText.text);
    }

    public void GoToSceneAsync(int index)
    {
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(index);
    }

    public void GoToSceneAsync(string name)
    {
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(name);
    }

    public void LoadRandomScene(Transform parent)
    {
        var buttonList = parent.GetComponentsInChildren<Button>();
        buttonList[Random.Range(0, buttonList.Length)].onClick.Invoke();
    }

    public void ReloadCurrentSceneAsync()
    {
        GoToSceneAsync(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    public void GoToSceneAsync(TMPro.TMP_Dropdown dropdown)
    {
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(dropdown.captionText.text);
    }


    public static void StaticReloadCurrentSceneAsync()
    {
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    public void ToggleGameobjectEnable(GameObject go)
    {
        go.SetActive(!go.activeSelf);
    }

    public void QuitApplication()
    {
        Application.Quit();
    }

    public void NotifySubscribers(string subscription)
    {
        Mouledoux.Components.Mediator.instance.NotifySubscribers(subscription, new object[]{});
    }
    
    public void ClickButton(Button b){
        b.onClick.Invoke();
    }

    public void ToggleBool(Toggle t){
        t.isOn = !t.isOn;
    }

    public void ChangeContentType(InputField field){
        if(field.contentType == InputField.ContentType.Password){
            field.contentType = InputField.ContentType.Standard;
        }

        else{
            field.contentType = InputField.ContentType.Password;
        }
    }

    public void CheckInput(InputField field){
        if(field.text == "Play"){
            Mouledoux.Components.Mediator.instance.NotifySubscribers("startreel");
        }
    }

    public void DestroyGO(GameObject go){
        Destroy(go);
    }
}