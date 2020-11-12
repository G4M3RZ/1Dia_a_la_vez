using UnityEngine;
using UnityEngine.UI;

public class StressBar : MonoBehaviour
{
    public int _deadScene;
    private Transform _bar;
    private float _barProgress;

    private Image _barImage;
    private Vector2 size;

    private void Awake()
    {
        _bar = transform.GetChild(0);
        _barImage = _bar.GetComponent<Image>();
        _barProgress = PlayerPrefs.GetFloat("StressBar", 1);

        size = _bar.localScale;
        size.x = _barProgress;
        _bar.localScale = size;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            SetStressBar(_barProgress - 0.1f, Color.red);
        if (Input.GetKeyDown(KeyCode.R))
            SetStressBar(_barProgress + 0.1f, Color.green);

        size = _bar.localScale;
        if (size.x != _barProgress)
        {
            _barImage.color = Color.Lerp(_barImage.color, Color.white, Time.deltaTime * 5);
            size.x = Mathf.Lerp(size.x, _barProgress, Time.deltaTime * 5);
            _bar.localScale = size;
        }

        if(_barProgress == 0)
        {
            Debug.Log("Perdiste");
            PlayerPrefs.SetInt("Dead", _deadScene);
            //cambiar a escena de perder
            this.enabled = false;
        }
    }
    public void SetStressBar(float value, Color color)
    {
        _barProgress = Mathf.Clamp(_barProgress - value, 0, 1);
        _barImage.color = color;
        PlayerPrefs.SetFloat("StressBar", _barProgress);
        PlayerPrefs.Save();
    }
}