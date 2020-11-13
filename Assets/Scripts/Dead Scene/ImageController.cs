using UnityEngine;

public class ImageController : MonoBehaviour
{
    public GameObject _fade;
    public Animator _anim;

    private void Awake()
    {
        int view = PlayerPrefs.GetInt("Dead", 0);
        _anim.Play("Ui_End_0" + view);
    }
    public void Restart()
    {
        PlayerPrefs.DeleteAll();

        GameObject fade = Instantiate(_fade, transform);
        fade.GetComponent<FadeController>()._sceneName = "00_Game_Menu";
    }
}