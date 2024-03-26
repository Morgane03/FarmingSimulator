﻿using UnityEngine;
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

    public GameObject _gameObjectTouched;

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
        //not implemented
    }

    // thank's Kylian for showing me how
    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            _gameObjectTouched = StartRaycast();
            if (_gameObjectTouched != null)
            {
                switch (_gameObjectTouched.tag)
                {
                    case "Market":
                        Debug.Log(_gameObjectTouched.name);

                        // MerchantFound();
                        break;
                    case "Land":
                        Field field = _gameObjectTouched.GetComponent<Field>();
                        _playerMain.PlayerChooseField.SelectLand(field);
                        break;
                    case "Plant":
                        Debug.Log(_gameObjectTouched.name);

                        // HarvestPlant();
                        break;
                }
            }
        }
    }

    private GameObject StartRaycast()
    {
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit hit;

        // Cast a ray from the mouse position and check if it hits an object
        if (Physics.Raycast(ray, out hit, 100f, _layerMask))
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
        _rb.velocity = _directionPlayer;

        if(Input.GetKeyDown(KeyCode.F))
        {
            _playerMain.Field.PlanteSeed();
        }
    }
}
