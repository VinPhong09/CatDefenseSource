using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateScript : MonoBehaviour
{
    public GameObject TowerLV;
    static int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
    }
    public void LevelUp()
    {
        TowerLV.SetActive(true);
    }
    public void AddLV()
    {
        
        Debug.Log("Add: " + i++);
    }
}
