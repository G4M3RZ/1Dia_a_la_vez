using Pathfinding;
using UnityEngine;

public class movement : MonoBehaviour
{
    public Transform _target;
    [Range(0, 10)] public float _speed;
    
    private Camera _cam;
    private AIPath _path;
    private float _scaleX;

    private void Awake()
    {
        _cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        _path = GetComponent<AIPath>();
        _path.maxSpeed = _speed;
        _scaleX = transform.localScale.x;
    }
    private void Update()
    {
        #region Player Direction Wiev
        Vector3 scale = transform.localScale;

        if (_path.desiredVelocity.x >= 0.01f) 
            scale.x = -_scaleX;
        else if (_path.desiredVelocity.x <= -0.01f)
            scale.x = _scaleX;

        transform.localScale = scale;
        #endregion

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            MovementController(touch.position);
        }
        else if (Input.GetMouseButton(0))
        {
            MovementController(Input.mousePosition);
        }
    }
    private void MovementController(Vector3 newPos)
    {
        Vector3 touchPos = _cam.ScreenToWorldPoint(newPos);
        touchPos.z = 0;

        _target.position = touchPos;
    }
}