using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public GameObject _fade;
    public List<Sprite> _sprites;
    public List<string> _dayNight;
    private Image _image;
    private string _sceneName;

    private void Awake()
    {
        _sceneName = PlayerPrefs.GetString("Scene");
        _image = GetComponent<Image>();

        for (int i = 0; i < 2; i++)
            SetTutorial("Bus_Scene_" + _dayNight[i], 0);

        SetTutorial("Office_Scene", 1);
        SetTutorial("Party_Scene", 2);

        Invoke("ChangeScene", 5);
    }
    void SetTutorial(string name, int num)
    {
        if (_sceneName == name)
            _image.sprite = _sprites[num];
    }
    void ChangeScene()
    {
        GameObject fade = Instantiate(_fade, transform.parent);
        fade.GetComponent<FadeController>()._sceneName = _sceneName;
    }
    public void SkipTuto()
    {
        CancelInvoke();
        ChangeScene();
    }
}