using System.Collections;
using System.Collections.Generic;
using Interface;
using UnityEngine;

public abstract class BaseFactory<M,V,C> where M: BaseModel where V: BaseView where C: BaseController
{
    protected M Model;
    protected V View;
    protected C Controller;

    public abstract void Create(CharacterType characterType, CharacterName characterName);
}
