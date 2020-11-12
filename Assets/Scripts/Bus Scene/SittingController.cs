using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SittingController : MonoBehaviour
{
    public Transform _player;
    [Range(0, 3)] public float _changeTime, _qteTime;
    
    public Sprite _icon, _null;
    public List<Sprite> _enemys;
    public List<SitPlace> _sits;
    private int _currentSit;

    public GameObject _fade;
    public string _sceneName;

    private Clock_Controller _clock;
    private bool _selected, _qte;

    private void Awake()
    {
        _clock = GetComponentInParent<Clock_Controller>();
        StartCoroutine(RidersController());
    }
    private void Start()
    {
        SitIcon(_icon);
    }
    IEnumerator RidersController()
    {
        yield return new WaitUntil(() => _selected == true);
        _clock._startTimer = true;
        _selected = false;

        while (_clock._startTimer)
        {
            yield return new WaitForSeconds(_changeTime);
            SetRiders();
            StartCoroutine(QuickTimeEvent());
            yield return new WaitUntil(() => _selected == true);

            _qte = true;
            _selected = false;

            SitIcon(_null);

            if (_sits[_currentSit]._enemyIsHere)
                Debug.Log("hace daño");
        }

        GameObject fade = Instantiate(_fade, transform.parent);
        fade.GetComponent<FadeController>()._sceneName = _sceneName;
    }
    IEnumerator QuickTimeEvent()
    {
        _qte = false;
        yield return new WaitForSeconds(_qteTime);
        if (!_qte) _selected = true; else StopCoroutine(QuickTimeEvent());
    }
    void SitIcon(Sprite icon)
    {
        for (int i = 0; i < _sits.Count; i++)
            _sits[i]._image.sprite = icon;
    }
    void SetRiders()
    {
        for (int i = 0; i < _sits.Count; i++)
        {
            _sits[i]._enemyIsHere = false;
            _sits[i]._image.sprite = _icon;
            _sits[i]._enemyImage.sprite = _null;
        }

        int random = Random.Range(2, _sits.Count);

        int e = 0;
        do
        {
            int sitNum = Random.Range(0, _sits.Count);
            if (!_sits[sitNum]._enemyIsHere)
            {
                _sits[sitNum]._enemyIsHere = true;
                _sits[sitNum]._enemyImage.sprite = _enemys[Random.Range(0, _enemys.Count)];
                e++;
            }
        } 
        while (e < random);
    }
    public void SitSelect(int numSit)
    {
        if (!_qte && _sits[numSit]._image.sprite != null)
        {
            _selected = true;
            _currentSit = numSit;
            _player.position = _sits[numSit]._transform.position;
            StopCoroutine(QuickTimeEvent());
            SitIcon(_null);
        }
    }
}