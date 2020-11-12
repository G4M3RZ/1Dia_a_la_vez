using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform _target;
    public float _limitX, _limitY;

    private void Update()
    {
        Vector3 pos = _target.position;
        Vector3 newPos = transform.position;

        if(pos.y >= -_limitY && pos.y <= _limitY)
        {
            newPos.y = Mathf.Lerp(newPos.y, pos.y, Time.deltaTime);
        }
        if(pos.x >= -_limitX && pos.x <= _limitX)
        {
            newPos.x = Mathf.Lerp(newPos.x, pos.x, Time.deltaTime);
        }

        newPos.z = -10;
        transform.position = newPos;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Vector3 size = new Vector3(_limitX * 2, _limitY * 2, 0);
        Gizmos.DrawWireCube(Vector3.zero, size);
    }
}