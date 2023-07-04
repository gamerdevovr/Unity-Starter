using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField]
    private Vector3 _moveMent = new Vector3(1, 0, 0);

    [SerializeField]
    private Vector3 _position = new Vector3(-10, 0.17f, 0);

    private void Start()
    {
        transform.position = _position;
    }

    private void FixedUpdate()
    {
        transform.position = transform.position + _moveMent * Time.fixedDeltaTime;

        //transform.LookAt(new Vector3(0, 0, 0));
    }
}
