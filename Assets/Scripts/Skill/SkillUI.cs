using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillUI : SkillBaseUI
{
    private void OnMouseOver()
    {
        SkillToolTip.gameObject.SetActive(true);
    }

    private void OnMouseExit()
    {
        SkillToolTip.gameObject.SetActive(false);
    }
}
