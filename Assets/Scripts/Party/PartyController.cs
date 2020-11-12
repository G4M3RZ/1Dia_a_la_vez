using System.Collections;
using UnityEngine;

public class PartyController : MonoBehaviour
{
    public GameObject _qteButton;
    public Camera _cam;

    [Range(0, 2)] public float _qteTimer;
    [Range(1, 10)] public float _eventDelay;

    public GameObject _fade;
    public string _sceneName;

    private bool _qte, _active;
    private Clock_Controller _clock;
    private float _lenth, _heigh;

    private void Awake()
    {
        _lenth = Screen.width * 6;
        _heigh = Screen.height * 2;

        _qteButton.SetActive(false);
        _clock = GetComponent<Clock_Controller>();

        StartCoroutine(QTEController());
    }
    IEnumerator QTEController()
    {
        yield return new WaitUntil(() => _clock._startTimer = true);

        while (_clock._startTimer)
        {
            yield return new WaitUntil(() => _qte == false);

            float time = Random.Range(_eventDelay / 2, _eventDelay);
            yield return new WaitForSeconds(time);

            if (_clock._startTimer)
            {
                //animacion de tomar?
                _active = false;
                _qte = true;
                StartCoroutine(QTE_Event());
            }
        }

        GameObject fade = Instantiate(_fade, transform.parent);
        fade.GetComponent<FadeController>()._sceneName = _sceneName;
    }
    IEnumerator QTE_Event()
    {
        _qteButton.SetActive(true);
        Vector3 pos;
        pos.x = Random.Range(-_lenth, _lenth);
        pos.y = Random.Range(-_heigh, _heigh);
        pos.z = 0;
        _qteButton.transform.position = _cam.ScreenToViewportPoint(pos);
        
        yield return new WaitForSeconds(_qteTimer);

        if (_active) StopCoroutine(QTE_Event()); else Debug.Log("Hurt Herself"); //bajar barra

        _qte = false;
        _qteButton.SetActive(false);
    }
    public void QTEButton()
    {
        Debug.Log("Succesful Drink");

        _active = true;
        _qte = false;
        _qteButton.SetActive(false);
    }
}