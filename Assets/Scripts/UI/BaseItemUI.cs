using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseItemUI : MonoBehaviour
{
    public TextMeshProUGUI ItemName;
    public GameObject ItemPreview;
    public Button BuyItemBtn;

    public abstract void OnUpdateUI();
}
