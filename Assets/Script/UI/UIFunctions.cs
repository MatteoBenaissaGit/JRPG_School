using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFunctions : MonoBehaviour
{
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private Logger _logger;

    public void BlockPlayerMovement()
    {
        _characterController.Canmove = false;
        _logger.Log($"Player canmove : {_characterController.Canmove}", this);
    }
    public void AllowPlayerMovement()
    {
        _characterController.Canmove = true;
        _logger.Log($"Player canmove : {_characterController.Canmove}", this);
    }
}
