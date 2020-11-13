using Pathfinding;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimController : MonoBehaviour
{
    [HideInInspector] public int _clothNum;
    private Animator _anim;
    public string _animName;
    public float _fAnimTime;

    private movement _moves;
    private AIPath _paht;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
        _paht = GetComponentInParent<AIPath>();
        _moves = GetComponentInParent<movement>();
        
        if (SceneManager.GetActiveScene().name == "House_Scene_Day")
        {
            _clothNum = 0;
            PlayerPrefs.SetInt("Cloth", 0);
            _paht.enabled =_moves.enabled = false;
            StartCoroutine(FirstAnim());
        }
        else
        {
            _clothNum = PlayerPrefs.GetInt("Cloth");
            _anim.Play(_animName + "_Iddle_0" + _clothNum);
            StartCoroutine(MoveAnim());
        }       
    }
    public void ChangeSkin(string name)
    {
        _anim.Play(name);
    }
    IEnumerator MoveAnim()
    {
        while (true)
        {
            yield return new WaitUntil(() => _paht.desiredVelocity == Vector3.zero);
            ChangeSkin(_animName + "_Iddle_0" + _clothNum);
            yield return new WaitUntil(() => _paht.desiredVelocity != Vector3.zero);
            //ChangeSkin("Move_0" + _clothNum);
        }
    }
    IEnumerator FirstAnim()
    {
        yield return new WaitForSeconds(_fAnimTime);
        _moves.enabled = _paht.enabled = true;
        StartCoroutine(MoveAnim());
    }
}