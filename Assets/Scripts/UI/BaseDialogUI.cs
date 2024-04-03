using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseDialogUI : MonoBehaviour
{
    public Text Content;

    public virtual void SetData(string text)
    {
        Content.text = text;
    }

    public abstract void OnEnable();
    public abstract void OnDisable();
}
