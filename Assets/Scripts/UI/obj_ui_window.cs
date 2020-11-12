using Pathfinding;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class obj_ui_window : MonoBehaviour
{
    private Image _image;
    public GameObject _window;
    public List<Color> _changeColor;

    private AIPath _path;
    private movement _movement;
    private bool _UI;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _image.color = _changeColor[0];

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        _movement = player.GetComponent<movement>();
        _path = player.GetComponent<AIPath>();

        _UI = false;
    }
    public void Show_Window()
    {
        if (_UI)
        {
            _window.SetActive(true);
            _movement.enabled = _path.enabled = false;
        }
    }
    public void Hide_Window()
    {
        _window.SetActive(false);
        _movement.enabled = _path.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && _window != null)
        {
            _image.color = _changeColor[1];
            _UI = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && _window != null)
        {
            _image.color = _changeColor[0];
            _UI = false;
        }
    }
}