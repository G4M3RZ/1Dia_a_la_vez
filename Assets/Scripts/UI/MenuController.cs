using UnityEngine;

public class MenuController : MonoBehaviour
{
    public Transform _parent;
    public GameObject _fadePrefab;
    private bool _sceneChanged;
    public void SceneManager(string newSceneName)
    {
        if (!_sceneChanged && newSceneName != "")
        {
            GameObject fade = Instantiate(_fadePrefab, _parent);
            fade.GetComponent<FadeController>()._sceneName = newSceneName;
            _sceneChanged = true;
        }
    }
}