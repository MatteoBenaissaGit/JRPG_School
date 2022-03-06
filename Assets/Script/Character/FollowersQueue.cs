using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowersQueue : MonoBehaviour
{
    [SerializeField] private GameObject _character;

    [SerializeField] [Range(0.1f,5.0f)] private float _timeToRefreshPosition;
    private float _refreshTimer;

    [HideInInspector] public List<NavMeshAgent> FollowersNavMeshList;
    [HideInInspector] public List<Transform> FollowersTransformList;
    [HideInInspector] public List<Animator> FollowersAnimatorList;

    private void Start()
    {
        foreach (Transform child in transform)
        {
            FollowersTransformList.Add(child.GetComponent<Transform>());
            FollowersNavMeshList.Add(child.GetComponent<NavMeshAgent>());
            FollowersAnimatorList.Add(child.GetComponent<Animator>());
        }
        _refreshTimer = _timeToRefreshPosition;
        for (int i = 0; i < FollowersNavMeshList.Count; i++)
        {
            FollowersNavMeshList[i].speed = _character.GetComponent<CharacterController>().CharacterSpeed;
        }
    }

    private void Update()
    {
        _refreshTimer -= Time.deltaTime;
        if (_refreshTimer <= 0)
        {
            _refreshTimer = _timeToRefreshPosition;
            FollowingCharacter();
        }
        FollowersAnimation();
    }

    public void FollowingCharacter()
    {
        for (int i = 0; i < FollowersNavMeshList.Count; i++)
        {
            if (i == 0)
                FollowersNavMeshList[i].SetDestination(_character.transform.position);
            else
                FollowersNavMeshList[i].SetDestination(FollowersNavMeshList[i-1].nextPosition);

        }
    }

    private void FollowersAnimation()
    {
        for (int i = 0; i < FollowersTransformList.Count; i++)
        {
            FollowersTransformList[i].rotation = _character.transform.rotation;
            if (FollowersNavMeshList[i].velocity.magnitude != 0f)
            {
                FollowersAnimatorList[i].SetBool("IsWalking", true);
                if (FollowersNavMeshList[i].nextPosition.x < _character.transform.position.x)
                    FollowersNavMeshList[i].GetComponent<SpriteRenderer>().flipX = true;
                else
                    FollowersNavMeshList[i].GetComponent<SpriteRenderer>().flipX = false;
            }
            else
                FollowersAnimatorList[i].SetBool("IsWalking", false);
        }
    }
}
