using UnityEngine;

public class ShipController : MonoBehaviour
{
    public float _speed;
    private Rigidbody2D _rgb;
    private Camera _cam;

    private void Awake()
    {
        _rgb = GetComponent<Rigidbody2D>();
        _cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            MovementController(touch.position);
        }
        else if (Input.GetMouseButton(0))
        {
            MovementController(Input.mousePosition);
        }
        else
        {
            if (_rgb.velocity != Vector2.zero)
                _rgb.velocity = Vector2.Lerp(_rgb.velocity, Vector2.zero, _speed * Time.deltaTime);
        }
    }
    private void MovementController(Vector3 newPos)
    {
        Vector3 touchPos = _cam.ScreenToWorldPoint(newPos);
        touchPos.z = 0;

        Vector3 direction = touchPos - transform.position;
        _rgb.velocity = new Vector2(direction.x, direction.y) * _speed;
    }
}