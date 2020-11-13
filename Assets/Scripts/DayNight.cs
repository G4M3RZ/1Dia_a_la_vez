using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class DayNight : MonoBehaviour
{
    public bool _needTuto;
    [Range(0,1)] public int _dayNight;
    public GameObject _partyWindow, _fade;
    public TextMeshProUGUI _dayText;

    public List<Color> _dayNightColors;
    public List<SpriteRenderer> _sprites;
    public List<Image> _images;

    private int dayCount, _party;

    private void Awake()
    {
        dayCount = PlayerPrefs.GetInt("DayCount", 1);
        _party = PlayerPrefs.GetInt("Party", 0);

        if(_dayText != null)
            _dayText.text = "Día " + dayCount;

        for (int i = 0; i < _sprites.Count; i++)
            _sprites[i].color = _dayNightColors[_dayNight];

        for (int i = 0; i < _images.Count; i++)
            _images[i].color = _dayNightColors[_dayNight];

        if(_partyWindow != null && SceneManager.GetActiveScene().name == "House_Scene_Night")
            StartCoroutine(PartyWindow());
    }
    IEnumerator PartyWindow()
    {
        _partyWindow.SetActive(false);

        yield return new WaitForSeconds(1.5f);

        int random = Random.Range(0, 2);

        if (random == 0 && _party == 0)
            _partyWindow.SetActive(true);
        else
        {
            if (dayCount < 5)
                NoGoToParty("House_Scene_Day");
            else
            {
                PlayerPrefs.SetInt("Dead", 0);
                NoGoToParty("Lose_Scene");
            }
        }
    }
    public void GoToParty(string sceneName)
    {
        PlayerPrefs.SetInt("Party", 1);

        if (_needTuto)
        {
            PlayerPrefs.SetString("Scene", sceneName);
            ChangeScene("Tutorial");
        }
        else
            ChangeScene(sceneName);
    }
    public void NoGoToParty(string sceneName)
    {
        ChangeScene(sceneName);
        PlayerPrefs.SetInt("DayCount", dayCount + 1);
        PlayerPrefs.SetInt("Party", 0);
    }
    void ChangeScene(string sceneName)
    {
        GameObject fade = Instantiate(_fade, transform);
        fade.GetComponent<FadeController>()._sceneName = sceneName;
    }
    private void Update() //test only
    {
        if (Input.GetKeyDown(KeyCode.Return))
            PlayerPrefs.DeleteAll();
    }
}