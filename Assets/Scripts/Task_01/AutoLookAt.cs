
using UnityEngine;

public class AutoLookAt : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private bool _lockYAxis;

    private Transform _target;
    private Vector3 _targetPosition;

    private void Start()
    {
        _target = GameObject.FindGameObjectWithTag("Target").transform;
    }

    private void Update()
    {
        _targetPosition = _lockYAxis ? new Vector3(_target.position.x, 0, _target.position.z) : _target.position - transform.position;
        Quaternion rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(_targetPosition), _rotationSpeed * Time.deltaTime);
        transform.rotation = rotation;
    }
}
