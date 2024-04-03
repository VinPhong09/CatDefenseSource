using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseButton : MonoBehaviour
{
    [Header("Base Button")]
    [SerializeField] protected Button button;

    protected virtual void Start()
    {
        LoadComponents();
        this.AddOnClickEvent();
    }
    
    protected virtual void LoadComponents()
    {
        this.LoadButton();
    }

    protected virtual void LoadButton()
    {
        if(this.button != null) {return ; }
        this.button = this.GetComponent<Button>();
    }


    protected virtual void AddOnClickEvent()
    {
        this.button.onClick.AddListener(this.OnClick);
    }

    protected abstract void OnClick();

    protected virtual void SoundClick()
    {
        /*AudioManager.Instance.PlaySoundOneShot(AudioClipManager.Instance.button);*/
    }
}
