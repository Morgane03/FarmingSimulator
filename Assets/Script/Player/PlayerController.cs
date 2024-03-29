using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Allows different actions of the player
/// </summary>
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private PlayerMain _playerMain;

    [SerializeField]
    private int _playerSpeed;

    [SerializeField]
    private LayerMask _layerMask;

    [SerializeField]
    private GameObject _dealerCanva;

    private Rigidbody _rb;
    private Vector3 _directionPlayer;

    public GameObject GameObjectTouched { get; private set; }

    // Start is called before the first frame update
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// Defined the movement of the player
    /// </summary>
    /// <param name="context"></param>
    public void OnMove(InputAction.CallbackContext context)
    {
        _directionPlayer = context.ReadValue<Vector3>();
    }

    /// <summary>
    /// Defined the interaction of the player
    /// Thank's Kylian for showing me how
    /// </summary>
    /// <param name="context"></param>
    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            GameObjectTouched = StartRaycast();
            if (GameObjectTouched != null)
            {
                switch (GameObjectTouched.tag)
                {
                    case "Market":
                        _dealerCanva.SetActive(true);
                        break;
                    case "Land":
                        Field field = GameObjectTouched.GetComponent<Field>();
                        _playerMain.PlayerChooseField.SelectLand(field);
                        break;
                }
            }
        }
    }

    /// <summary>
    /// Defined the action of the player to farm
    /// </summary>
    /// <param name="context"></param>
    public void OnFarm(InputAction.CallbackContext context)
    {
        if (!context.started)
        {
            return;
        }

        _playerMain.Field.PlanteSeed();
        _playerMain.Field.Harvest();
    }

    /// <summary>
    /// Defined the player’s raycast
    /// </summary>
    /// <returns></returns>
    private GameObject StartRaycast()
    {
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

        // Cast a ray from the mouse position and check if it hits an object
        if (Physics.Raycast(ray, out RaycastHit hit, 100f, _layerMask))
        {
            return hit.collider.gameObject;
        }
        else
        {
            return null;
        }
    }

    private void Update()
    {
        _rb.velocity = _directionPlayer * _playerSpeed;
    }
}
