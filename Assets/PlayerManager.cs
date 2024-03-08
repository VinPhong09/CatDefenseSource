using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject Ins;
    public CharacterView characterView;

    public CharacterModel characterModel;

    public CharacterController characterController;

    public CharacterEvent characterEvent;
    // Start is called before the first frame update
    void Start()
    {
        characterModel = new CatBoxerModel();
        characterView = Ins.gameObject.GetComponent<CatBoxerView>();
        characterEvent = Ins.gameObject.AddComponent<CharacterEvent>();
        characterController = new CharacterController(characterModel, characterView, characterEvent);
        characterController.Initialize();
       
    }

    // Update is called once per frame
    void Update()
    {
        characterController.Handle();
    }
}
