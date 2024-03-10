using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FindEnemyFixed : MonoBehaviour
{

    
    private void Update()
    {
        FindFixed();
    }

    void FindFixed()
    {
        GameObject[] _AllChar = GameObject.FindGameObjectsWithTag("Character");
        foreach (GameObject _Char in _AllChar)
        {
            Component [] c = _Char.GetComponents<MonoBehaviour>();
        }
    }

}