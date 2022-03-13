using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private Collider2D _characterCollider;
    [SerializeField] private Logger _logger;

    public void BlockPlayerMovement()
    {
        _characterController.Canmove = false;
        _characterCollider.enabled = false;
        _logger.Log($"Player canmove : {_characterController.Canmove}", this);
    }
    public void AllowPlayerMovement()
    {
        _characterController.Canmove = true;
        _characterCollider.enabled = true;
        _logger.Log($"Player canmove : {_characterController.Canmove}", this);
    }
}
