using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class obj_ui_window : MonoBehaviour
{
    private Image _image;
    public GameObject _window;
    public List<Sprite> _changeSprite;

    private movement _movement;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _image.sprite = _changeSprite[0];

        _movement = GameObject.FindGameObjectWithTag("Player").GetComponent<movement>();
    }
    public void Window(bool active)
    {
        _window.SetActive(active);
        _movement.enabled = !active;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && _window != null)
            _image.sprite = _changeSprite[1];
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && _window != null)
            _image.sprite = _changeSprite[0];
    }
}