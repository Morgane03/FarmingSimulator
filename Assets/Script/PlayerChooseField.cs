using UnityEngine;

/// <summary>
/// Allows to give feedback to the player regarding the chosen plot of land
/// </summary>
public class PlayerChooseField : MonoBehaviour
{
    [SerializeField]
    private PlayerMain _playerMain;

    [SerializeField]
    private Field _selectedField = null;

    public void SelectLand(Field field)
    {
        if (_selectedField != null)
        {
            _selectedField.Selecte(false);
        }

        // Selected new field
        _selectedField = field;
        field = _playerMain.PlayerController._gameObjectTouched.GetComponent<Field>();
        field.Selecte(true);
    }
}
