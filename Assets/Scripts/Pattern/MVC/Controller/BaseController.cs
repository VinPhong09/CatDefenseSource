using System.Collections;
using System.Collections.Generic;
using Interface;
using UnityEngine;

public class BaseController: IController
{
    protected BaseModel BaseModel;
    protected BaseView BaseView;
    
    public virtual void SetData(IModel characterModel, IView characterView, CharacterEvent characterEvent, IAttack characterAttack)
    {
        throw new System.NotImplementedException();
    }

    public virtual void Initialize()
    {
        throw new System.NotImplementedException();
    }

    public virtual void Handle()
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

    public CharacterView GetCharacterView()
    {
        throw new System.NotImplementedException();
    }

    public CharacterModel GetCharacterModel()
    {
        throw new System.NotImplementedException();
    }
}
