using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICharacterController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] protected List<GameObject> _Charpreview;

    [SerializeField] protected List<GameObject> _CharPage;


    
    [Header("ReActive GameObject")]
    [SerializeField] protected GameObject _HeroBtn;
    int i = 0;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    
   public void nextCharacter()
   {
        i++;
        if(i <= _Charpreview.Count -1)
        {
            _Charpreview[i].gameObject.SetActive(true);
            _Charpreview[i-1].gameObject.SetActive(false);
            //PageChange
            _CharPage[i].gameObject.SetActive(true);
            _CharPage[i-1].gameObject.SetActive(false);
        }else if(i >= _Charpreview.Count - 1)
        {
            _Charpreview[i-1].gameObject.SetActive(false);
            _CharPage[i-1].gameObject.SetActive(false);
            i = 0;
            //pageChanges
            _Charpreview[i].gameObject.SetActive(true);
            _CharPage[i].gameObject.SetActive(true);
        }
    }

   public void previousCharacter()
   {
        i--;
        if(i>=0)
        {
            _Charpreview[i].gameObject.SetActive(true);
            _Charpreview[i+1].gameObject.SetActive(false);
            _CharPage[i].gameObject.SetActive(true);
            _CharPage[i+1].gameObject.SetActive(false);
        }else if(i < 0)
        {
            _CharPage[i+1].gameObject.SetActive(false);
            _Charpreview[i+1].gameObject.SetActive(false);
            i = 3;
            _Charpreview[i].gameObject.SetActive(true);
            _CharPage[i].gameObject.SetActive(true);
        }
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
