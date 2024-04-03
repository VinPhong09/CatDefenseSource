using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog : BaseDialogUI
{
   public override void OnEnable()
   {
      this.gameObject.SetActive(true);
   }

   public override void OnDisable()
   {
      throw new System.NotImplementedException();
   }
}
