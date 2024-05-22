using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.VinExtension;
public class HeroItemUI : BaseItemUI
{
   public void SetData(GameObject gameObject)
   {
      gameObject.SetActive(true);
      gameObject.gameObject.transform.position = ItemPreview.transform.position;
      var characterName = EnumParse.StringToEnum<CharacterName>(gameObject.name);
      ItemName.text = gameObject.name;
      BuyItemBtn.GetComponent<BuyHeroButton>().SetData(characterName);
   }
   
   public override void OnUpdateUI()
   {
     
      
   }
}
