using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIFail : UICanvas
{
    private int coin;
    [SerializeField] TextMeshProUGUI coinTxt;
    [SerializeField] RectTransform x3Point;
    [SerializeField] RectTransform mainMenuPoint;

    public TextMeshProUGUI rank;

    public override void Open()
    {
        base.Open();
        GameManager.Ins.ChangeState(GameState.Finish);
        rank.text = "#" + LevelManager.Ins.TotalCharacter.ToString();
    }

    public void x3Button()
    {
        UIVfx.Ins.AddCoin(9, coin * 3, x3Point.position, UIVfx.Ins.CoinPoint);
        UserData.Ins.SetIntData(UserData.Key_Coin, ref UserData.Ins.coin, UserData.Ins.coin + coin * 3);
        LevelManager.Ins.Home();
    }
    public void MainMenuButton()
    {
        UIVfx.Ins.AddCoin(3, coin, x3Point.position, UIVfx.Ins.CoinPoint);
        UserData.Ins.SetIntData(UserData.Key_Coin, ref UserData.Ins.coin, UserData.Ins.coin + coin);
        LevelManager.Ins.Home();
    }

    public void SetCoin(int coin)
    {
        this.coin = coin;
        coinTxt.SetText(coin.ToString());
    }

}
