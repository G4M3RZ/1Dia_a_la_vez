using System.Collections;
using UnityEngine;

public class Office_hiding_place : MonoBehaviour
{
    public GameObject _qteButton;
    public Animator _boss, _player;

    [Range(0, 2)] public float _qteTimer;
    [Range(1,10)] public float _eventDelay;

    public GameObject _fade;
    public string _sceneName;

    private bool _qte, _active;
    private Clock_Controller _clock;

    private void Awake()
    {
        _qteButton.SetActive(false);
        _clock = GetComponent<Clock_Controller>();
        StartCoroutine(QTEController());
    }
    IEnumerator QTEController()
    {
        yield return new WaitUntil(() => _clock._startTimer == true);

        while (_clock._startTimer)
        {
            yield return new WaitUntil(() => _qte == false);

            float time = Random.Range(_eventDelay / 2, _eventDelay);
            yield return new WaitForSeconds(time);

            if (_clock._startTimer)
            {
                _boss.Play("boss_anim");
                _active = false;
                _qte = true;
                StartCoroutine(QTE_Event());
            }
        }

        PlayerPrefs.SetInt("DayNight", 1);
        GameObject fade = Instantiate(_fade, transform.parent);
        fade.GetComponent<FadeController>()._sceneName = _sceneName;
    }
    IEnumerator QTE_Event()
    {
        _qteButton.SetActive(true);
        _player.Play("Ui_Alert_00");
        yield return new WaitForSeconds(_qteTimer);

        if (_active) StopCoroutine(QTE_Event());
        else
        {
            Debug.Log("Hurt Herself"); //bajar barra
            _player.Play("Ui_Iddle_00");
        }

        _qte = false;
        _qteButton.SetActive(false);
    }
    public void QTEButton(AnimationClip animName)
    {
        Debug.Log("Succesful Hiding"); //subir barra
        _player.Play(animName.name);

        _active = true;
        _qte = false;
        _qteButton.SetActive(false);
    }
}