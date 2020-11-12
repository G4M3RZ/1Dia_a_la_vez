using UnityEngine;
using UnityEngine.UI;

public class Clock_Controller : MonoBehaviour
{
    public bool _waitClock;
    public Image _clock;
    [Range(0, 50)] public float _timeGame;
    [HideInInspector] public bool _startTimer;
    private float _timer;

    private void Awake()
    {
        if (!_waitClock)
            _startTimer = false;
        else
            _startTimer = true;
        
        _timer = _timeGame;
    }
    private void Update()
    {
        if (_startTimer)
        {
            _timer = Mathf.Clamp(_timer -= Time.deltaTime, 0, _timeGame);
            _clock.fillAmount = _timer / _timeGame;

            if (_timer == 0)
            {
                //salir de la oficina
                _startTimer = false;
            }
        }
    }
}