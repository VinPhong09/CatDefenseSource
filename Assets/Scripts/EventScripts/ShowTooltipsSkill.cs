using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowTooltipsSkill : MonoBehaviour
{
    public GameObject BoxShow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver()
    {
        BoxShow.gameObject.SetActive(true);
    }

    /// <summary>
    /// Called when the mouse is not any longer over the GUIElement or Collider.
    /// </summary>
    private void OnMouseExit()
    {
        BoxShow.gameObject.SetActive(false);
    }
}
