using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class obj_new_scene : MonoBehaviour
{
    private Image _image;
    public List<Sprite> _sprites;

    public GameObject _fade;
    public string _sceneName;
    private bool _ui, _changeScene;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }
    public void ChangeScene()
    {
        if (_ui && !_changeScene)
        {
            GameObject fade = Instantiate(_fade, transform.parent);
            fade.GetComponent<FadeController>()._sceneName = _sceneName;
            _changeScene = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && _fade != null && !_ui)
        {
            _image.sprite = _sprites[1];
            _ui = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && _fade != null && !_ui)
        {
            _image.sprite = _sprites[0];
            _ui = false;
        }
    }
}