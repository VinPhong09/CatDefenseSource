using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesGenerator : MonoBehaviour
{
   [SerializeField] protected ResourceName resourceName;


    private void FixedUpdate()
    {
        Generating();
    }
   protected virtual void Generating()
   {
        if(this.resourceName == ResourceName.noResource) return;
   }
}
