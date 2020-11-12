using UnityEngine;
using UnityEngine.UI;

public class SitPlace : MonoBehaviour
{
    [HideInInspector] public Image _image;
    [HideInInspector] public Transform _transform;
    public bool _enemyIsHere;
    public Image _enemyImage;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _transform = transform;
    }
}