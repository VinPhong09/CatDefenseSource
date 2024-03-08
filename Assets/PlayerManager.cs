using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public CharacterView characterView;

    public CharacterModel characterModel;

    public CharacterController characterController;

    public CharacterEvent characterEvent;
    // Start is called before the first frame update
    void Start()
    {
        characterModel = new CatBoxerModel();
        characterView = gameObject.AddComponent<CatBoxerView>();
        characterEvent = new CharacterEvent();
        characterController = new CharacterController(characterModel, characterView, characterEvent);
    }

    // Update is called once per frame
    void Update()
    {
        characterController.Handle();
    }
}
