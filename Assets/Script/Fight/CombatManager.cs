using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{

    public GameObject PlayerManagerObj;

    int Attacker = 0;
    int Target = 0;


    public void AllyAttack()
    {
        int charid = PlayerManagerObj.GetComponent<PlayerManager>().SelectedCharacterID;
        CharacterCombatAttributes character = PlayerManagerObj.GetComponent<PlayerManager>().ListChars[charid];

        



    }


}
