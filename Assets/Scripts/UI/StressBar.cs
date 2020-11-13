using UnityEngine;
using UnityEngine.UI;

public class StressBar : MonoBehaviour
{
    public GameObject _fade;

    [Range(0, 10)]
    public int _barValue;
    public int _deadScene;
    private Transform _bar;
    private float _barProgress;

    private Image _barImage;
    private Vector2 size;

    private void Awake()
    {
        _bar = transform.GetChild(0);
        _barImage = _bar.GetComponent<Image>();
        _barProgress = PlayerPrefs.GetFloat("StressBar", _barValue);

        size = _bar.localScale;
        size.x = _barProgress / _barValue;
        _bar.localScale = size;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            SetStressBar(_barProgress - 0.1f, Color.red);
        if (Input.GetKeyDown(KeyCode.R))
            SetStressBar(_barProgress + 0.1f, Color.green);

        size = _bar.localScale;
        if (size.x != _barProgress / _barValue || _barImage.color != Color.white)
        {
            _barImage.color = Color.Lerp(_barImage.color, Color.white, Time.deltaTime * 5);
            size.x = Mathf.Lerp(size.x, _barProgress / _barValue, Time.deltaTime * 5);
            _bar.localScale = size;
        }

        if(_barProgress == 0)
        {
            PlayerPrefs.SetInt("Dead", _deadScene);
            GameObject fade = Instantiate(_fade, transform.parent);
            fade.GetComponent<FadeController>()._sceneName = "Lose_Scene";
            this.enabled = false;
        }
    }
    public void SetStressBar(float value, Color color)
    {
        _barProgress = Mathf.Clamp(_barProgress + value, 0, _barValue);
        _barImage.color = color;
        PlayerPrefs.SetFloat("StressBar", _barProgress);
        PlayerPrefs.Save();
    }
}