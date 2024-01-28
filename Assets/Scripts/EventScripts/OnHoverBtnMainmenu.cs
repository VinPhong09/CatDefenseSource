using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnHoverBtnMainmenu : MonoBehaviour
{
    // Start is called before the first frame update
    public Text _Text;

    AudioSource _audio;
    void Start()
    {
        _audio = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    /// <summary>
    /// Called when the mouse enters the GUIElement or Collider.
    /// </summary>
    private void OnMouseEnter()
    {
        _Text.color = new Color32(255,247,104,255);
        _audio.Play();

    }
    /// <summary>
    /// Called when the mouse is not any longer over the GUIElement or Collider.
    /// </summary>
    private void OnMouseExit()
    {
        _Text.color = Color.white;
    }
}
