using UnityEngine;

public class StaticCharacterAnim : MonoBehaviour
{
    public string _animType, _fAnimName;
    public bool _destroyAfterUse;

    private Animator _anim;
    public int _clothNum;

    private void Awake()
    {
        _clothNum = PlayerPrefs.GetInt("Cloth", 0);
        _anim = GetComponent<Animator>();
        _anim.Play(_animType + "_" + _fAnimName + "_0" + _clothNum);
    }
    public void SetAnim(string animName)
    {
        _anim.Play(_animType + "_" + animName + "_0" + _clothNum);
        
        if(_destroyAfterUse)
            Destroy(this);
    }
}