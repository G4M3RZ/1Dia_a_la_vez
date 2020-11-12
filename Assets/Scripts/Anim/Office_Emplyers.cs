using UnityEngine;

public class Office_Emplyers : MonoBehaviour
{
    public AnimationClip _animation;
    private void Awake()
    {
        if(_animation != null)
            GetComponent<Animator>().Play(_animation.name);
    }
}