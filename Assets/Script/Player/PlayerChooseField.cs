﻿using UnityEngine;

/// <summary>
/// Allows to give feedback to the player regarding the chosen plot of land
/// </summary>
public class PlayerChooseField : MonoBehaviour
{
    [SerializeField]
    private PlayerMain _playerMain;

    public SeedBehaviour SeedBehaviour { get; private set; }

    private void Start()
    {
        _playerMain.Field = null;
    }

    /// <summary>
    /// Allows to select a plot of land and give feedback to the player
    /// </summary>
    /// <param name="field"></param>
    public void SelectLand(Field field)
    {
        if (_playerMain.Field != null)
        {
            _playerMain.Field.Select(false);
            _playerMain.Field.IsChoose = false;
        }

        // Selected new field
        _playerMain.Field = field;
        field = _playerMain.PlayerController.GameObjectTouched.GetComponent<Field>();
        field.Select(true);
        field.IsChoose = true;
        SeedBehaviour = field.GetComponentInChildren<SeedBehaviour>();
    }
}
