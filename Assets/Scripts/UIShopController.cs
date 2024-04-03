using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIShopController : MonoBehaviour
{
    [SerializeField] protected GameObject _HeroShop;
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
        
    }
    public void previousHerosPage()
    {
        i--;
        
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
