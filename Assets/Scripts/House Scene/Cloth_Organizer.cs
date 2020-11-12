using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cloth_Organizer : MonoBehaviour
{
    public List<Sprite> _characterDress;
    public List<Sprite> _cloth;
    private List<Image> _spot;

    public Image _character;
    public AnimController _graphics;
    private int _clothSelected;

    private void Awake()
    {
        _spot = new List<Image>();

        for (int i = 0; i < transform.GetChild(0).childCount; i++)
        {
            _spot.Add(transform.GetChild(0).GetChild(i).GetComponent<Image>());
            
            if(_cloth.Count > 0)
                _spot[i].sprite = _cloth[i];
        }
    }
    public void ClothSelection(int value)
    {
        _clothSelected = value;
        _character.sprite = _characterDress[value - 1];
        _graphics.ChangeSkin(_graphics._animName + "_Iddle_0" + value);
    }
    public void SaveCloth()
    {
        _graphics._clothNum = _clothSelected;
        PlayerPrefs.SetInt("Cloth", _clothSelected);
        PlayerPrefs.Save();
    }
}