using UnityEngine;

public class BusCharacterAnim : MonoBehaviour
{
    public string _animType;
    private Animator _anim;
    private int _clothNum;

    private void Awake()
    {
        _clothNum = PlayerPrefs.GetInt("Cloth");
        _anim = GetComponent<Animator>();
        _anim.Play(_animType + "_Iddle_0" + _clothNum);
    }
    public void SetAnim()
    {
        _anim.Play(_animType + "_Sit_0" + _clothNum);
        Destroy(this);
    }
}