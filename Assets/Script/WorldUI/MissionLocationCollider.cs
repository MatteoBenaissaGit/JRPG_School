using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionLocationCollider : MonoBehaviour
{
    [SerializeField] private int _MissionNumber;
    [SerializeField] private Missions _missions;
    [SerializeField] private GameObject _character;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == _character)
        {
            _missions.ListMissions[_MissionNumber]._isMissionCompleted = true;
        }
    }
}
