using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singletone
    private static GameManager instance = null;

    public static GameManager GetInstance()
    {
        if (instance == null)
        {
            GameObject go = new GameObject("@GameManager");
            instance = go.AddComponent<GameManager>();

            DontDestroyOnLoad(go);
        }

        return instance;
    }
    #endregion
    public Character playerData;
   
    public Character[] PlayerDatas = new Character[]
   {                     // Img, playerName, level, totalHp, curHp, gold
        new Character("Character1","³ìÁ¶¸ÅÁö¼Ç",1,100,100,10000),
        new Character("Character2","ºÓÀº¸ÁÅä",1,120,120,10000)     

   };
    
    public int characterIdx = 0; // 0 = mage , 1 = red

    //³ìÁ¶¸ÅÁö¼Ç
    //public int mageHp = 100;
    //public string mageImg = "Character";

    ////ºÓÀº¸ÁÅä
    //public int redHp = 120;
    //public string redImg = "Character2";

    // string playerName, int level, int totalHp, int curHp, int gold
    public void LoadData()
    {
        playerData.playerImg = PlayerPrefs.GetString("playerName", PlayerDatas[characterIdx].playerImg);
        
        playerData.playerName = PlayerPrefs.GetString("playerName", PlayerDatas[characterIdx].playerName);
       
        playerData.level = PlayerPrefs.GetInt("level", PlayerDatas[characterIdx].level);
       
        playerData.totalHp = PlayerPrefs.GetInt("totalHp", PlayerDatas[characterIdx].totalHp);
        playerData.curHp = PlayerPrefs.GetInt("curHp", PlayerDatas[characterIdx].curHp);
       
        playerData.gold = PlayerPrefs.GetInt("gold", PlayerDatas[characterIdx].gold);

        //playerName = PlayerPrefs.GetString("playerName", "Chad");

        //level = PlayerPrefs.GetInt("level", 1);
        //gold = PlayerPrefs.GetInt("gold", 500);
        //totalHp = PlayerPrefs.GetInt("totalHp", 100);
        //curHp = PlayerPrefs.GetInt("curHp", 100);
    }

    // key            level  gold    totalHp    curHp
    // value            1    500     100        100


    public void SaveData()
    {
        PlayerPrefs.SetString("playerName" , PlayerDatas[characterIdx].playerName);

        PlayerPrefs.SetInt("level", PlayerDatas[characterIdx].level);
        PlayerPrefs.SetInt("gold", PlayerDatas[characterIdx].gold);
        PlayerPrefs.SetInt("totalHp", PlayerDatas[characterIdx].totalHp);
        PlayerPrefs.SetInt("curHp", PlayerDatas[characterIdx].curHp);
    }

    public void AddGold(int gold)
    {
        this.PlayerDatas[characterIdx].gold += gold;
        SaveData();
    }

    public bool SpendGold(int gold)
    {
        if (this.PlayerDatas[characterIdx].gold >= gold)
        {
            this.PlayerDatas[characterIdx].gold -= gold;
            SaveData();
            return true;
        }

        return false;
    }

    public void IncreaseTotalHP(int addHp)
    {
        PlayerDatas[characterIdx].totalHp += addHp;
        SaveData();
    }

    public void SetCurrentHP(int hp)
    {
        PlayerDatas[characterIdx].curHp += hp;

        //   110  >  100
        if (PlayerDatas[characterIdx].curHp > PlayerDatas[characterIdx].totalHp)
            PlayerDatas[characterIdx].curHp = PlayerDatas[characterIdx].totalHp; // cur -> 100

        //    -20 < 0
        if (PlayerDatas[characterIdx].curHp < 0)
            PlayerDatas[characterIdx].curHp = 0;  // cur -> 0

        SaveData();
        // curHp = Mathf.Clamp(curHp, 0, 100);
    }
}