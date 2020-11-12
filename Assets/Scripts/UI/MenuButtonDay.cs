using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButtonDay : MonoBehaviour
{
    public Image _imageButton;
    public Button _menuButton;
    public List<Sprite> _buttonIddle;
    public List<Sprite> _buttonPress;

    private void Awake()
    {
        int day = PlayerPrefs.GetInt("DayCount", 1);

        _imageButton.sprite = _buttonIddle[day - 1];
        SpriteState buttonSate = new SpriteState();
        buttonSate = _menuButton.spriteState;
        buttonSate.pressedSprite = _buttonPress[day - 1];
        _menuButton.spriteState = buttonSate;
    }
}