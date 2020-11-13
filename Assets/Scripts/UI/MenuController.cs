using UnityEngine;

public class MenuController : MonoBehaviour
{
    public bool _needTuto;
    public Transform _parent;
    public GameObject _fadePrefab;
    private bool _sceneChanged;
    public void SceneManager(string newSceneName)
    {
        if (!_sceneChanged && newSceneName != "")
        {
            if (_needTuto)
            {
                PlayerPrefs.SetString("Scene", newSceneName);
                ChangeScene("Tutorial");
            }
            else
                ChangeScene(newSceneName);
        }
    }
    void ChangeScene(string sceneName)
    {
        GameObject fade = Instantiate(_fadePrefab, _parent);
        fade.GetComponent<FadeController>()._sceneName = sceneName;
        _sceneChanged = true;
    }
}