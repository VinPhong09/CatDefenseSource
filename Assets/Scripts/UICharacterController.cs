using System;
using System.Collections;
using System.Collections.Generic;
using Interface;
using UnityEngine;
using UnityEngine.UI;

public class UICharacterController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] protected List<GameObject> _Charpreview;

    public HeroStatManager HeroStatManager;
   

    private List<GameObject> _herosGameObject;
    private List<IController> _heroControllers;
    public void Init()
    {
        _herosGameObject = CharacterManager.Instance.GetHeroGameObjectList();
        _heroControllers = CharacterManager.Instance.GetHeroControllerList();
        HeroStatManager.SetData(_heroControllers[0]);
    }

    [Header("ReActive GameObject")]
    [SerializeField] protected GameObject _HeroBtn;
    int i = 1;
    
   public void nextCharacter()
   {
        i++;
        if (i > _heroControllers.Count-1)
        {
            i = 0;
        }
        HeroStatManager.SetData(_heroControllers[i]);
   }

   public void previousCharacter()
   {
        i--;
        if (i < 0)
        {
            i = _heroControllers.Count-1;
        }
        HeroStatManager.SetData(_heroControllers[i]);
   }
   public void QuitHerosTab(GameObject gameObject1)
   {
     this.gameObject.SetActive(false);
     _HeroBtn.SetActive(true);
     gameObject1.GetComponent<Button>().interactable = true;
   }
   public void QuitHerosTab2(GameObject gameObject1)
   {
     this.gameObject.SetActive(false);
     _HeroBtn.SetActive(true);
     gameObject1.GetComponent<Button>().interactable = true;
   }
}
