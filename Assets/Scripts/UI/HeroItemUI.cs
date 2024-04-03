using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroItemUI : BaseItemUI
{
   public void Start()
   {
      SetData(this.ItemPreview);
      OnUpdateUI();
   }

   public void SetData(GameObject gameObject)
   {
      ItemPreview = gameObject;
      CharacterName characterName =(CharacterName) Enum.Parse(typeof(CharacterName), ItemPreview.name);
      BuyItemBtn.GetComponent<BuyHeroButton>().SetData(characterName);
   }
   
   public override void OnUpdateUI()
   {
      ItemName.text = ItemPreview.name;
      
   }
}
