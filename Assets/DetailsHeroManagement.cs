using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DetailsHeroManagement : MonoBehaviour
{
    [Header("CatBoxerDetail and Skill")]
    [SerializeField] protected GameObject _CatBoxer;
    [SerializeField]protected Text _BoxerHptext;
    [SerializeField]protected Text _BoxerDamagetext;
    [SerializeField]protected Text _BoxerCrittext;
    [SerializeField]protected Text _BoxerLifeStealtext;
    [SerializeField]protected Text _BoxerLeveltext;
    //Skill
    [SerializeField]protected Text _BoxerTextSkill;
    [SerializeField]protected Text _BoxerLeveltextSkill;
    int _BoxerLevelSkill;
    //S1
    [SerializeField]protected Text _BoxerTextSkill1;
    [SerializeField]protected Text _BoxerLeveltextSkill1;
    int _BoxerLevelSkill1;
    //S2
    [SerializeField]protected Text _BoxerTextSkill2;
    [SerializeField]protected Text _BoxerLeveltextSkill2;
    int _BoxerLevelSkill2;



    [Header("CatFoloDetail")]
    [SerializeField] protected GameObject _CatFolo;
    [SerializeField]protected Text _CatFoloHptext;
    [SerializeField]protected Text _CatFoloDamagetext;
    [SerializeField]protected Text _CatFoloCrittext;
    [SerializeField]protected Text _CatFoloLifeStealtext;
    [SerializeField]protected Text _CatFoloLeveltext;
    //Skill
    [SerializeField]protected Text _CatFoloTextSkill;
    [SerializeField]protected Text _CatFoloLeveltextSkill;
    int _CatFoloLevelSkill;
    //S1
    [SerializeField]protected Text _CatFoloTextSkill1;
    [SerializeField]protected Text _CatFoloLeveltextSkill1;
    int _CatFoloLevelSkill1;
    //S2
    [SerializeField]protected Text _CatFoloTextSkill2;
    [SerializeField]protected Text _CatFoloLeveltextSkill2;
    int _CatFoloLevelSkill2;

    [Header("CatMuradDetail")]
    [SerializeField] protected GameObject _CatMurad;
    [SerializeField]protected Text _CatMuradHptext;
    [SerializeField]protected Text _CatMuradDamagetext;
    [SerializeField]protected Text _CatMuradCrittext;
    [SerializeField]protected Text _CatMuradLifeStealtext;
    [SerializeField]protected Text _CatMuradLeveltext;
    //Skill
    [SerializeField]protected Text _CatMuradTextSkill;
    //S1
    [SerializeField]protected Text _CatMuradTextSkill1;
    [SerializeField]protected Text _CatMuradLeveltextSkill1;
    int _CatMuradLevelSkill1;
    //S2
    [SerializeField]protected Text _CatMuradTextSkill2;
    [SerializeField]protected Text _CatMuradLeveltextSkill2;
    int _CatMuradLevelSkill2;

    [Header("CatVampireDetail")]
    [SerializeField] protected GameObject _Catvampire;
    [SerializeField]protected Text _CatVampireHptext;
    [SerializeField]protected Text _CatVampireDamagetext;
    [SerializeField]protected Text _CatVampireCrittext;
    [SerializeField]protected Text _CatVampireLifeStealtext;
    [SerializeField]protected Text _CatVampireLeveltext;
    //Skill
    [SerializeField]protected Text _CatVampireTextSkill;
    //S1
    [SerializeField]protected Text _CatVampireTextSkill1;
    [SerializeField]protected Text _CatVampireLeveltextSkill1;
    int _CatVampireLevelSkill1;
    //S2
    [SerializeField]protected Text _CatVampireTextSkill2;
    [SerializeField]protected Text _CatVampireLeveltextSkill2;
    int _CatVampireLevelSkill2;
    // Start is called before the first frame update
    // void Start()
    // {
    //     
    //     _BoxerLevelSkill = 1; _BoxerLevelSkill1 = 1; _BoxerLevelSkill2 = 1;
    //
    //     _CatFoloPro = _CatFolo.GetComponent<CatFoloProperties>();
    //     _CatFoloLevelSkill = 1; _CatFoloLevelSkill1 = 1; _CatFoloLevelSkill2 = 1;
    //
    //     _CatMuradPro = _CatMurad.GetComponent<CatMuradProperties>();
    //     _CatMuradLevelSkill1 = 1; _CatMuradLevelSkill2 = 1;
    //
    //     _CatVampirePro = _Catvampire.GetComponent<CatVampireProperties>();
    //     _CatVampireLevelSkill1 = 1; _CatVampireLevelSkill2 = 1;
    //
    // }

    // Update is called once per frame

    void Update()
    {
        // CatFoloShowDetails();
        // CatMuradShowDetails();
        // CatVampireShowDetails();
    }

#region CaboxerScripts
    /*void CatBoxerShowDetails()
    {
        _BoxerHptext.text = "Máu: " + 
        _BoxerDamagetext.text = "Tấn công: "+ _CatBoxerPro.GetTextDamageMin() + " - " + _CatBoxerPro.GetTextDamageMax();
        _BoxerLifeStealtext.text = "Hút máu: " + Mathf.RoundToInt(_CatBoxerPro.GetRateBlood() *100)+"%";
        _BoxerLeveltext.text ="LV: " + _CatBoxerPro.GetTextLevel();
        _BoxerTextSkill.text = "Nội tại: Đánh thường có 25% tỉ lệ tấn công liên tiếp gây " + Mathf.RoundToInt(100+_CatBoxerPro.GetRateDMGskill()*100)+ "% sát thương";
        _BoxerLeveltextSkill.text = "LV: " + _BoxerLevelSkill;
        _BoxerTextSkill1.text = "Skill1: Đánh thường gây " + Mathf.RoundToInt(_CatBoxerPro.GetRateDMGskill1()*100) + "% sát thương";
        _BoxerLeveltextSkill1.text = "LV: " + _BoxerLevelSkill1;
        _BoxerTextSkill2.text = "Skill2: Đánh thường có 25% tỉ lệ đánh combo gây " +Mathf.RoundToInt(200+_CatBoxerPro.GetRateDMGskil2()*100) +"% sát thương";
        _BoxerLeveltextSkill2.text = "LV: " + _BoxerLevelSkill2;
    }*/

    public void BoxerUpgrageSkill1()
    {
       
        _BoxerLevelSkill1++;
    }

    public void BoxerUpgrageSkill2()
    {
       
        _BoxerLevelSkill2++;
    }
    
    public void BoxerUpgrageSkill()
    {
        
        _BoxerLevelSkill++;
    }

    public void BoxerUpLevel()
    {
        
    }

    public void EquidHeroBoxer(Text _text)
    {
        if(_text.text == "Ra trận")
            _text.text = "Nghỉ";
        else
            _text.text = "Ra trận";
    }
#endregion
//
// #region CatFoloScripts
//     void CatFoloShowDetails()
//     {
//         _CatFoloHptext.text = "Máu: " + _CatFoloPro.GetTextHealth();
//         _CatFoloDamagetext.text = "Tấn công: "+ _CatFoloPro.GetTextDamageMin() + " - " + _CatFoloPro.GetTextDamageMax();
//         _CatFoloLifeStealtext.text = "Hút máu: " + Mathf.RoundToInt(_CatFoloPro.GetRateBlood() *100)+"%";
//         _CatFoloLeveltext.text ="LV: " + _CatFoloPro.GetTextLevel();
//         _CatFoloTextSkill.text = "Nội tại: Đánh thường có 25% tỉ lệ tấn công liên tiếp gây " + Mathf.RoundToInt(100+_CatFoloPro.GetRateDMGskill()*100)+ "% sát thương";
//         _CatFoloLeveltextSkill.text = "LV: " + _CatFoloLevelSkill;
//         _CatFoloTextSkill1.text = "Skill1: Đánh thường gây " + Mathf.RoundToInt(_CatFoloPro.GetRateDMGskill1()*100) + "% sát thương";
//         _CatFoloLeveltextSkill1.text = "LV: " + _CatFoloLevelSkill1;
//         _CatFoloTextSkill2.text = "Skill2: Đánh thường có tỉ lệ 25% đánh combo gây " +Mathf.RoundToInt(200+_CatFoloPro.GetRateDMGskil2()*100) +"% sát thương";
//         _CatFoloLeveltextSkill2.text = "LV: " + _CatFoloLevelSkill2;
//     }
//
//     public void FoloUpgrageSkill1()
//     {
//         _CatFoloPro.SetRateDMGskill1();
//         _CatFoloLevelSkill1++;
//     }
//
//     public void FoloUpgrageSkill2()
//     {
//         _CatFoloPro.SetRateDMGskill2();
//         _CatFoloLevelSkill2++;
//     }
//     
//     public void FoloUpgrageSkill()
//     {
//         _CatFoloPro.SetRateDMGskill();
//         _CatFoloLevelSkill++;
//     }
//
//     public void FoloUpLevel()
//     {
//         _CatFoloPro.UpLevel();
//     }
// #endregion
//
// #region CatMuradScripts
//     void CatMuradShowDetails()
//     {
//         _CatMuradHptext.text = "Máu: " + _CatMuradPro.GetTextHealth();
//         _CatMuradDamagetext.text = "Tấn công: "+ _CatMuradPro.GetTextDamageMin() + " - " + _CatMuradPro.GetTextDamageMax();
//         _CatMuradLifeStealtext.text = "Hút máu: " + Mathf.RoundToInt(_CatMuradPro.GetRateBlood() *100)+"%";
//         _CatMuradLeveltext.text ="LV: " + _CatMuradPro.GetTextLevel();
//         _CatMuradTextSkill.text = "Nội tại: Đánh thường có 50% tỉ lệ gây sát thương chí mạng";
//         _CatMuradTextSkill1.text = "Skill1: Đánh thường gây " + Mathf.RoundToInt(_CatMuradPro.GetRateDMGskill1()*100) + "% sát thương";
//         _CatMuradLeveltextSkill1.text = "LV: " + _CatMuradLevelSkill1;
//         _CatMuradTextSkill2.text = "Skill2: Khi tích đủ nộ tấn công 5 lần gây " +Mathf.RoundToInt(400+_CatMuradPro.GetRateDMGskil2()*100) +"% sát thương";
//         _CatMuradLeveltextSkill2.text = "LV: " + _CatMuradLevelSkill2;
//     }
//
//     public void CatMuradUpgrageSkill1()
//     {
//         _CatMuradPro.SetRateDMGskill1();
//         _CatMuradLevelSkill1++;
//     }
//
//     public void CatMuradUpgrageSkill2()
//     {
//         _CatMuradPro.SetRateDMGskill2();
//         _CatMuradLevelSkill2++;
//     }
//
//     public void MuradUpLevel()
//     {
//         _CatMuradPro.UpLevel();
//     }
// #endregion
//
// #region CatVampireScripts
//     void CatVampireShowDetails()
//     {
//         _CatVampireHptext.text = "Máu: " + _CatVampirePro.GetTextHealth();
//         _CatVampireDamagetext.text = "Tấn công: "+ _CatVampirePro.GetTextDamageMin() + " - " + _CatVampirePro.GetTextDamageMax();
//         _CatVampireLifeStealtext.text = "Hút máu: " + Mathf.RoundToInt(_CatVampirePro.GetRateBlood() *100)+"%";
//         _CatVampireLeveltext.text ="LV: " + _CatVampirePro.GetTextLevel();
//         _CatVampireTextSkill.text = "Nội tại: Hút máu cơ bản 30% và cộng hưởng thêm từ skill 2";
//         _CatVampireTextSkill1.text = "Skill1: Đánh thường gây " + Mathf.RoundToInt(_CatVampirePro.GetRateDMGskill1()*100) + "% sát thương";
//         _CatVampireLeveltextSkill1.text = "LV: " + _CatVampireLevelSkill1;
//         _CatVampireTextSkill2.text = "Skill2: Khi tích đủ nộ giải phóng bản thân tăng " +Mathf.RoundToInt(_CatVampirePro.GetRateBloodEffect()*100) +"% hút máu cho đồng đội 15s trong phạm vi";
//         _CatVampireLeveltextSkill2.text = "LV: " + _CatVampireLevelSkill2;
//     }
//
//     public void CatVampireUpgrageSkill1()
//     {
//         _CatVampirePro.SetRateDMGskill1();
//         _CatVampireLevelSkill1++;
//     }
//
//     public void CatVampireUpgrageSkill2()
//     {
//         _CatVampirePro.UpRateBlood();
//         _CatVampireLevelSkill2++;
//     }
//
//     public void VampireUpLevel()
//     {
//         _CatVampirePro.UpLevel();
//     }
// #endregion
}
