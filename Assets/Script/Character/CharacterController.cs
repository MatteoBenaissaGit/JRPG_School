using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterController : MonoBehaviour
{
    [Header("--- Movement Parameters ---")]
    [Range(0.0f,15.0f)] public float CharacterSpeed;
    [Range(0.0f,15.0f)] public float CharacterAcceleration;
    [Header("--- Debug ---")]
    [SerializeField] private Logger _logger;

    private Vector2 _lastClickedPos;
    private bool _moving;
    private NavMeshAgent _CharacterNavMeshAgent;

    private void Start()
    {
        CharacterNavMeshUpdate();
    }

    private void Update()
    {
        ClickToMove();
        CharacterMovement();
    }

    private void ClickToMove()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _lastClickedPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _moving = true;
            GetComponent<Animator>().SetBool("IsWalking", true);
            _logger.Log($"Move To {_lastClickedPos}", this);
        }
    }

    private void CharacterMovement()
    {
        if (_moving)
        {
            float step = CharacterSpeed * Time.deltaTime;
            _CharacterNavMeshAgent.SetDestination(_lastClickedPos);
            FlipCharacter(); 
        }
        if (_moving && (Vector2)transform.position == (Vector2)_CharacterNavMeshAgent.destination)
        {
            _logger.Log($"Stopped", this);
            _moving = false;
            GetComponent<Animator>().SetBool("IsWalking", false);
        }
    }

    private void FlipCharacter()
    {
        if (_lastClickedPos.x > transform.position.x)
            GetComponent<SpriteRenderer>().flipX = true;
        else
            GetComponent<SpriteRenderer>().flipX = false;

    }

    private void CharacterNavMeshUpdate()
    {
        _CharacterNavMeshAgent = GetComponent<NavMeshAgent>();
        _CharacterNavMeshAgent.updateRotation = false;
        _CharacterNavMeshAgent.updateUpAxis = false;
        _CharacterNavMeshAgent.speed = CharacterSpeed;
        _CharacterNavMeshAgent.acceleration = CharacterAcceleration;
    }
}
