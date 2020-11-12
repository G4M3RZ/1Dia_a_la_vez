using UnityEngine;

public class UI_InGame : MonoBehaviour
{
    private Vector2 startPos;

    private void Awake()
    {
        startPos = transform.position;
    }
    private void Update()
    {
        transform.position = startPos;
    }
}