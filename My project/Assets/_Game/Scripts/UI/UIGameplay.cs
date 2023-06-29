using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIGameplay : UICanvas
{
    public TextMeshProUGUI characterAmountTxt;

    public override void Setup()
    {
        base.Setup();
        UpdateTotalCharacter();
    }

    public override void Open()
    {
        base.Open();
        GameManager.Ins.ChangeState(GameState.GamePlay);
        LevelManager.Ins.SetTargetIndicatorAlpha(1);
    }

    public override void CloseDirectly()
    {
        base.CloseDirectly();
        LevelManager.Ins.SetTargetIndicatorAlpha(0);
    }

    public void SettingButton()
    {
        UIManager.Ins.OpenUI<UISetting>();
    }
    public void UpdateTotalCharacter()
    {
        characterAmountTxt.text = LevelManager.Ins.TotalCharacter.ToString();
    }
}
