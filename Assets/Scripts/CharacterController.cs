using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _shootPoint1;
    [SerializeField] private Transform _shootPoint2;
    [SerializeField] private Vector3 _position = new Vector3(-10, 0.17f, 0);
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _gunForce;
    [SerializeField] private float _speedWalk;

    private PlayerControls _conrols;
    private Rigidbody _rigidbody;
    private Animator _animator;

    private void Awake()
    {
        _conrols = new PlayerControls();
        _conrols.Player.Jump.performed += _ => Jump();
        _conrols.Player.Shoot.performed += _ => Shoot();

        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();

        transform.position = _position;
    }

    private void Start()
    {
    }

    private void OnEnable()
    {
        _conrols.Player.Enable();
    }

    private void OnDisable()
    {
        _conrols.Player.Disable();
    }

    private void Update()
    {
        
    }    

    private void FixedUpdate()
    {
        Vector2 moveDirection_v2 = _conrols.Player.Move.ReadValue<Vector2>();
        Vector3 moveDirection_v3 = new Vector3(moveDirection_v2.x, 0, moveDirection_v2.y);

        float speedMoving = new Vector3(_rigidbody.velocity.x, 0f, _rigidbody.velocity.z).magnitude;

        _animator.SetFloat("Speed", speedMoving / 3f);
        _animator.speed = 3f;

        _rigidbody.AddForce(moveDirection_v3 * _speedWalk);
    }

    private void Jump()
    {
        _animator.SetTrigger("IsJump");
        _rigidbody.AddForce(new Vector3(0, _jumpForce, 0), ForceMode.Impulse);
    }

    private void Shoot()
    {
        CreateBullet(_shootPoint1.position);
        CreateBullet(_shootPoint2.position);
    }

    private void CreateBullet(Vector3 position)
    {
        GameObject bullet = Instantiate(_bullet, position, Quaternion.identity);
        Rigidbody rigidbody = bullet.GetComponent<Rigidbody>();

        rigidbody.AddForce(transform.forward * _gunForce, ForceMode.Impulse);

        Destroy(bullet, 5f);
    }
}
