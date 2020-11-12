using UnityEngine;

public class Set_Office_Pos : MonoBehaviour
{
    [Range(0, 5)]
    public float _speed;
    public Transform _target;
    private Clock_Controller _clockController;

    private void Awake()
    {
        GameObject controller = GameObject.FindGameObjectWithTag("GameController");
        _clockController = controller.GetComponent<Clock_Controller>();
    }
    private void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * _speed);

        if (transform.position.x >= _target.position.x)
        {
            _clockController._startTimer = true;
            Destroy(_target.gameObject);
            Destroy(this);
        }
    }
}