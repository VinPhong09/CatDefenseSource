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
    public GameObject PreviewHeroPosition;
    public HeroStatManager HeroStatManager;
    public GameObject HeroSelectionUI;

    private List<GameObject> _herosGameObject;
    private List<IController> _heroControllers;

    private int _index;
    public void Init()
    {
        Debug.Log("Init");
        _heroControllers = CharacterManager.Instance.GetHeroControllerList();
        Debug.Log(_heroControllers.Count);
        HeroStatManager.SetData(_heroControllers[0]);
        OnHeroPreView(_heroControllers[0].GetCharacterView().name);
        _index = 1;
    }

    [Header("ReActive GameObject")]
    [SerializeField] protected GameObject _HeroBtn;
    
   public void nextCharacter()
   { 
       OnDisableHeroPreView();
        _index++;
        if (_index > _heroControllers.Count-1)
        {
            _index = 0;
        }
        HeroStatManager.SetData(_heroControllers[_index]);
        OnHeroPreView(_heroControllers[_index].GetCharacterView().name);
   }

   public void previousCharacter()
   {
       OnDisableHeroPreView();
       _index--;
        if (_index < 0)
        {
            _index = _heroControllers.Count-1;
        }
        HeroStatManager.SetData(_heroControllers[_index]);
        OnHeroPreView(_heroControllers[_index].GetCharacterView().name);
   }

   public void OnHeroPreView(string name)
   {
       for (int i = 0; i < _heroControllers.Count; i++)
       {
           if (HeroSelectionUI.transform.GetChild(i).name.Equals(name))
           {
               Debug.Log("ChilName - " + HeroSelectionUI.transform.GetChild(i).name +"ControllerName - " +name);
               HeroSelectionUI.transform.GetChild(i).transform.position = PreviewHeroPosition.transform.position;
               HeroSelectionUI.transform.GetChild(i).gameObject.SetActive(true);
               return;
           }
       }
   }
   public void OnDisableHeroPreView()
   {
       for (int i = 0; i < _heroControllers.Count; i++)
       {
               HeroSelectionUI.transform.GetChild(i).gameObject.SetActive(false);
       }
   }
   public void QuitHerosTab(GameObject gameObject1)
   {
       OnDisableHeroPreView();
     this.gameObject.SetActive(false);
     _HeroBtn.SetActive(true);
     gameObject1.GetComponent<Button>().interactable = true;
   }
   public void QuitHerosTab2(GameObject gameObject1)
   {
       OnDisableHeroPreView();
     this.gameObject.SetActive(false);
     _HeroBtn.SetActive(true);
     gameObject1.GetComponent<Button>().interactable = true;
   }
}
