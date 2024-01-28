using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesManage : MonoBehaviour
{
   [SerializeField] protected List<Resource> resources;

   public void Resourced(Resource R)
   {
      resources.Add(R);
   }
}
