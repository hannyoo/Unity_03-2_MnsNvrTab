using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIProfile : MonoBehaviour
{
    public Slider hpBar;
    public Image imgFill;

    public TMP_Text txtHp;

    public TMP_Text txtLevel;
    public TMP_Text txtName;
    public TMP_Text txtGold;
    
    void Start()
    {
        RefreshState();
    }

    public void RefreshState()
    {
        var aa = GameManager.GetInstance().PlayerDatas[GameManager.GetInstance().characterIdx];


        txtLevel.text = $"Lv. {aa.level}";
        txtName.text = $"{aa.playerName}";
        txtGold.text = $"{aa.gold}g";

        hpBar.maxValue = aa.totalHp;
        hpBar.value = aa.curHp;

        txtHp.text = $"{aa.curHp} / {aa.totalHp}";
    }
}
