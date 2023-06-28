using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;

    private Animator _animator;
    private Rigidbody _rigidBody;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidBody = GetComponent<Rigidbody>();

    }

    private void Update()
    {
        Move();
        
    }

    private void Move()
    {
        Vector3 playerDirection = Vector3.ClampMagnitude(new Vector3(_joystick.Horizontal, 0, _joystick.Vertical),1);
        _rigidBody.velocity = playerDirection * _speed;

        if (playerDirection.magnitude > Mathf.Abs(0.1f))
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(playerDirection), Time.deltaTime * _rotationSpeed);

        _animator.SetFloat("speed", playerDirection.magnitude);
    }
}
