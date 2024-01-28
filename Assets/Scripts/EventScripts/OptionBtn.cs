using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionBtn : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] protected GameObject _Herotabs;
    [SerializeField] protected GameObject _Shop;
    [SerializeField] protected GameObject _StartLevel;

    [Header("Button GameObject")]

    [SerializeField] protected GameObject _HeroBtn;
    [SerializeField] protected GameObject _ShopBtn;
    [SerializeField] protected GameObject _StartLevelBtn;
    [SerializeField] protected GameObject _SettingBtn;

    [SerializeField] protected GameObject _AudioBtn;
    

    void Start()
    {
        _HeroBtn.GetComponent<Button>().interactable = false;
        _ShopBtn.GetComponent<Button>().interactable = false;
        _SettingBtn.GetComponent<Button>().interactable = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OpenHerotab(GameObject _Gameobject)
    {
        _Herotabs.gameObject.SetActive(true);
        _Gameobject.SetActive(false);
        _ShopBtn.GetComponent<Button>().interactable = false;
        _SettingBtn.GetComponent<Button>().interactable = false;
    }

    public void OpenShop(GameObject _Gameobject)
    {
        _HeroBtn.GetComponent<Button>().interactable = false;
        _SettingBtn.GetComponent<Button>().interactable = false;
        _Shop.gameObject.SetActive(true);
        _Gameobject.SetActive(false);
    }
    public void StartLevel(GameObject _Gameobject)
    {
        _StartLevel.SetActive(true);
        _Gameobject.SetActive(false);
        _HeroBtn.GetComponent<Button>().interactable = true;
        _ShopBtn.GetComponent<Button>().interactable = true;
        _SettingBtn.GetComponent<Button>().interactable = true;
    }

}
