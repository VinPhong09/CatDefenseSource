using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIShopController : MonoBehaviour
{
    [SerializeField] protected GameObject _HeroShop;
    [SerializeField] protected GameObject _ItemShop;
    // Start is called before the first frame update
    int indexShop = 0;

    [SerializeField] protected GameObject _ShopBtn;
    public HeroItemUI[] HeroItemUis;
    public GameObject[] HeroSelections;
    public void init(GameObject[] heroSelections)
    {
        HeroSelections = heroSelections;
        HeroItemUis = GetComponentsInChildren<HeroItemUI>();
        nextHerosPage();
    }

    // Update is called once per frame
    public void nextHerosPage()
    {
        OnDisableHeroSelection();
        for (int i = indexShop; i < HeroItemUis.Length + indexShop; i++)
        {
            if(i <= HeroSelections.Length - 1)
                OnLoadItem(HeroSelections[i], i - indexShop);
        }
        
        indexShop += 3;
    }
    public void previousHerosPage()
    {
        
        OnDisableHeroSelection();
        for (int i = indexShop; i > HeroItemUis.Length + indexShop; i--)
        {
            if(i >= HeroSelections.Length - 1)
                OnLoadItem(HeroSelections[i], i - indexShop);
        }
        
        indexShop -= 3;
    }
    
    public void OnLoadItem(GameObject gameObject, int index)
    {
        var heroSelect = gameObject;
        HeroItemUis[index].SetData(heroSelect);
    }
    public void OpenHeroShop()
    {
        _HeroShop.SetActive(true);
        _ItemShop.SetActive(false);
    }
     public void OpenItemShop()
    {
        _HeroShop.SetActive(false);
        _ItemShop.SetActive(true);
    }

    public void OnDisableHeroSelection()
    {
        foreach (var VARIABLE in HeroSelections)
        {
            VARIABLE.SetActive(false);
        }
    }

    public void QuitShop(GameObject gameObject)
    {
        OnDisableHeroSelection();
        indexShop = 0;
     this.gameObject.SetActive(false);
     _ShopBtn.SetActive(true);
     gameObject.GetComponent<Button>().interactable = true;
   }
   public void QuitShop2(GameObject gameObject)
   {
       OnDisableHeroSelection();
       indexShop = 0;
     this.gameObject.SetActive(false);
     _ShopBtn.SetActive(true);
     gameObject.GetComponent<Button>().interactable = true;
   }
}
