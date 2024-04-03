using System.Collections;
using System.Collections.Generic;
using Interface;
using UnityEngine;
using UnityEngine.UI;

public class HeroStatManager : MonoBehaviour
{
    public Text HeroNameTxt;
    public Text HpTxt;
    public Text DamageTxt;
    public Text CritRateTxt;
    public Text LifeStealTxt;
    public Text HeroLevelTxt;

    public List<SkillUI> SkillUis;
    
    private CharacterView _characterView;
    private CharacterController _characterController;
    private CharacterModel _characterModel;
    public void SetData(IController heroController)
    {
        _characterController =(CharacterController)heroController;
        _characterView = _characterController.GetCharacterView();
        _characterModel = _characterController.GetCharacterModel();
        OnUpdateUI();
    }

    public void OnUpdateUI()
    {
        HeroNameTxt.text = _characterView.name;
        HpTxt.text = $"HP: {_characterModel.MaxHealth}";
        DamageTxt.text = $"Damage: {_characterModel.DamageMin} - {_characterModel.DamageMax}";
        CritRateTxt.text = $"CritRate: {_characterModel.CritRate * 100}%";
        LifeStealTxt.text = $"LifeSteal: {_characterModel.LifeSteal*100}%";
        HeroLevelTxt.text = $"Level: {_characterModel.Level}";
        //Set Skill UI Data
        var i = 0;
        foreach (var s in _characterView.Skills)
        {
            var skillUI = SkillUis[i];
            skillUI.GetComponent<Image>().sprite = s.Image;
            skillUI.SkillName.text = s.Name;
            skillUI.SkillLevel.text = s.Level;
            skillUI.ToolTipTxt.text = s.Description;
            if(!s.HasUpgrade)
                skillUI.SkillUpgradeBtn.SetActive(false);
            i++;
        }
    }
    
    
}
