using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIShopController : MonoBehaviour
{
    [SerializeField] protected GameObject _HeroShop;
    [SerializeField] protected List<GameObject> _HerosShopPage;

    [SerializeField] protected GameObject _ItemShop;
    // Start is called before the first frame update
    int i = 0;

    [SerializeField] protected GameObject _ShopBtn;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void nextHerosPage()
    {
        i++;
        if(i <= _HerosShopPage.Count -1)
        {
            _HerosShopPage[i].gameObject.SetActive(true);
            _HerosShopPage[i-1].gameObject.SetActive(false);
        }else if(i >= _HerosShopPage.Count - 1)
        {
            _HerosShopPage[i-1].gameObject.SetActive(false);
             i = 0;
            _HerosShopPage[i].gameObject.SetActive(true);
        }
    }
    public void previousHerosPage()
    {
        i--;
        if(i>=0)
        {
            _HerosShopPage[i].gameObject.SetActive(true);
            _HerosShopPage[i+1].gameObject.SetActive(false);
        }else if(i < 0)
        {
            _HerosShopPage[i+1].gameObject.SetActive(false);
            i = 1;
            _HerosShopPage[i].gameObject.SetActive(true);
        }
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
    public void QuitShop(GameObject gameObject)
   {
     this.gameObject.SetActive(false);
     _ShopBtn.SetActive(true);
     gameObject.GetComponent<Button>().interactable = true;
   }
   public void QuitShop2(GameObject gameObject)
   {
     this.gameObject.SetActive(false);
     _ShopBtn.SetActive(true);
     gameObject.GetComponent<Button>().interactable = true;
   }
}
