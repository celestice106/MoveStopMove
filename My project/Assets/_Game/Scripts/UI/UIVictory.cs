using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIVictory : UICanvas
{
    private int coin;
    [SerializeField] TextMeshProUGUI coinTxt;
    [SerializeField] RectTransform x3Point;
    [SerializeField] RectTransform mainMenuPoint;

    public override void Open()
    {
        base.Open();
        GameManager.Ins.ChangeState(GameState.Finish);
    }

    public void x3Button()
    {
        UIVfx.Ins.AddCoin(9, coin * 3, x3Point.position, UIVfx.Ins.CoinPoint);
        UserData.Ins.SetIntData(UserData.Key_Coin, ref UserData.Ins.coin, UserData.Ins.coin + coin * 3);
        LevelManager.Ins.NextLevel();
        LevelManager.Ins.Home();
    }

    public void NextAreaButton()
    {
        UIVfx.Ins.AddCoin(3, coin, mainMenuPoint.position, UIVfx.Ins.CoinPoint);
        UserData.Ins.SetIntData(UserData.Key_Coin, ref UserData.Ins.coin, UserData.Ins.coin + coin);
        LevelManager.Ins.NextLevel();
        LevelManager.Ins.Home();
    }
    public void SetCoin(int coin)
    {
        this.coin = coin;
        coinTxt.SetText(coin.ToString());
    }
}
