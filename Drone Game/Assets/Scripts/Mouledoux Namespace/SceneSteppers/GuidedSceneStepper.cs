using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewSceneStepper", menuName = "ScriptableObjects/GuidedSceneStepper")]
public class GuidedSceneStepper : ScriptableObject
{
    public bool random;
    public string defaultScene;
    public string defaultSceneMessage;
    public List<SceneScenario> originalScenarios = new List<SceneScenario>();
    public List<SceneScenario> scenarios = new List<SceneScenario>();

    public void CopyList(ref List<SceneScenario> emptyList, ref List<SceneScenario> listToCopy)
    {
        emptyList.Clear();

        foreach (SceneScenario value in listToCopy)
        {
            emptyList.Add(new SceneScenario(value));
        }
    }

    public SceneScenario GetNextScenarioInfo()
    {
        if (scenarios.Count == 0) return new SceneScenario(defaultScene, defaultSceneMessage, 0, 0);

        Random.InitState((int)Time.time);
        int returnIndex = random ? Random.Range(0, scenarios.Count) : 0;
        
        if (scenarios[returnIndex].replays <= 0)
        {
            scenarios.RemoveAt(returnIndex);
            return GetNextScenarioInfo();
        }
        else
        {
            scenarios[returnIndex].replays--;
        }

        return scenarios[returnIndex];
    }

    [System.Serializable]
    public class SceneScenario
    {
        public string scene;
        public string sceneMessage;
        [Tooltip("How many times the scenario can be re-selected. 0 means it can only be played once")]
        public int replays = 0;

        public SceneScenario() { }

        public SceneScenario(string a_scene, string a_sceneMessage, int a_difficulty, int a_replays)
        {
            scene = a_scene;
            sceneMessage = a_sceneMessage;
            replays = a_replays;
        }

        public SceneScenario(SceneScenario ss)
        {
            scene = ss.scene;
            sceneMessage = ss.sceneMessage;
            replays = ss.replays;
        }

        static public bool operator==(SceneScenario lhs, SceneScenario rhs)
        {
            return(lhs.scene == rhs.scene && lhs.sceneMessage == rhs.sceneMessage);
        }
        static public bool operator!=(SceneScenario lhs, SceneScenario rhs)
        {
            return(lhs.scene != rhs.scene || lhs.sceneMessage != rhs.sceneMessage);
        }

        public override bool Equals(object obj)
        {
            return base.Equals (obj);
        }
        
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}