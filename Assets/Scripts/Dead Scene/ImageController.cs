using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageController : MonoBehaviour
{
    public Image _image;
    public List<Sprite> _sprites;

    private void Awake()
    {
        int view = PlayerPrefs.GetInt("Dead", 0);
        _image.sprite = _sprites[view];
    }
}