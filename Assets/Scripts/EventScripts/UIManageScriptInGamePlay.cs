using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManageScriptInGamePlay : MonoBehaviour
{

    [SerializeField] protected GameObject _MenuSetting;
    [SerializeField] protected GameObject _TowerScript;
    [SerializeField] protected GameObject _Shop;
    [SerializeField] protected GameObject _HeroSelections;


    private UIShopController _uiShopController;
    bool _isclickAudio = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnOpenHeroShop()
    {
        //Test in this time
        var gameObjecs = GetGameObjectsInParent();
        _uiShopController = _Shop.GetComponent<UIShopController>();
        _uiShopController.init(gameObjecs);
    }

    public GameObject[] GetGameObjectsInParent()
    {
        var gos = new GameObject[_HeroSelections.transform.childCount];
        for (int i = 0; i < _HeroSelections.transform.childCount; i++)
        {
            Transform childTransform = _HeroSelections.transform.GetChild(i);
            GameObject childObject = childTransform.gameObject;
            gos[i] = childObject;
            
        }

        return gos;
    }
    // Update is called once per frame
    void Update()
    {
        if(_TowerScript.gameObject.GetComponent<TowerScripts>().getHealth()<=0)
        {
            _MenuSetting.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void Setting(GameObject gameObject)
    {
         _MenuSetting.gameObject.SetActive(true);
        gameObject.GetComponent<Button>().interactable = false;
    }
    public void Setting1(GameObject gameObject)
    {
        gameObject.GetComponent<Button>().interactable = false;
    }
    public void Setting2(GameObject gameObject)
    {
        gameObject.GetComponent<Button>().interactable = false;
    }
    public void AudioSetting()
    {
        _isclickAudio = !_isclickAudio;
        if(_isclickAudio)
        {
            AudioListener.volume = 0;
        }else if (!_isclickAudio)
        {
             AudioListener.volume = 1;
        }

    }
}
