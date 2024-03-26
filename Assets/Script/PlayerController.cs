using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int _playerSpeed;

    private Rigidbody _rb;
    private Vector3 _directionPlayer;

    // Start is called before the first frame update
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
            _directionPlayer = context.ReadValue<Vector3>();
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        // Not used
    }

    private void Update()
    {
        _rb.velocity = _directionPlayer;
    }
}
