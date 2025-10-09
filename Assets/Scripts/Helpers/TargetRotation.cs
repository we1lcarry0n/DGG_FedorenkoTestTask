using UnityEngine;

public class TargetRotation : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private bool _rotateCurved;

    private float _currentYOffset;

    private void Start()
    {
        _currentYOffset = transform.position.y;
    }

    private void Update()
    {
        transform.RotateAround(Vector3.zero, Vector3.up, _rotationSpeed * Time.deltaTime);
        if (_rotateCurved)
        {
            ApplySinFluctuation();
        }
    }

    private void ApplySinFluctuation()
    {
        float sin = Mathf.Sin((transform.rotation.eulerAngles.y * Mathf.PI)/180f*2f);
        transform.position = new Vector3(0, sin + _currentYOffset, 0);
    }
}
