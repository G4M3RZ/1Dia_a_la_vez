using System.Collections.Generic;
using UnityEngine;

public class EnemyPath : MonoBehaviour
{
    [Range(0, 0.5f)] public float _danger;
    [Range(0, 2)] public float _speed;
    public List<Vector2> _pos;
    public StressBar _bar;

    private Vector2 pos;
    private int _wayPoint;

    private void Awake()
    {
        transform.position = _pos[0];
    }
    private void Update()
    {
        if (Vector2.Distance(transform.position, _pos[_wayPoint]) <= 0.01f)
        {
            _wayPoint = (_wayPoint == 0) ? 1 : 0;
            pos = _pos[_wayPoint];
        }

        float speed = Time.deltaTime / Vector2.Distance(transform.position, _pos[_wayPoint]);
        transform.position = Vector2.Lerp(transform.position, pos, speed * _speed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            _bar.SetStressBar(_danger, Color.red);
    }
}