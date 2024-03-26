using System.Collections;
using System.Collections.Generic;
using Interface;
using UnityEngine;

public class BaseController: IController
{
    protected BaseModel BaseModel;
    protected BaseView BaseView;
    
    public virtual void SetData(IModel characterModel, IView characterView, CharacterEvent characterEvent)
    {
        throw new System.NotImplementedException();
    }

    public void Initialize()
    {
        throw new System.NotImplementedException();
    }

    public void Handle()
    {
        throw new System.NotImplementedException();
    }

    public void Move()
    {
        throw new System.NotImplementedException();
    }

    public void Attack()
    {
        throw new System.NotImplementedException();
    }

    public void DetectEnemies()
    {
        throw new System.NotImplementedException();
    }

    public void DetectTarget()
    {
        throw new System.NotImplementedException();
    }
}
