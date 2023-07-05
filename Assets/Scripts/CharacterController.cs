using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField]
    private Vector3 _position = new Vector3(-10, 0.17f, 0);
    [SerializeField]
    private float _jumpForce;
    [SerializeField]
    private float _speedWalk;

    private PlayerControls _conrols;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _conrols = new PlayerControls();
        _conrols.Player.Jump.performed += _ => Jump();

        _rigidbody = GetComponent<Rigidbody>();

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

        _rigidbody.AddForce(moveDirection_v3 * _speedWalk);
    }

    private void Jump()
    {
        _rigidbody.AddForce(new Vector3(0, _jumpForce, 0), ForceMode.Impulse);
    }
}
