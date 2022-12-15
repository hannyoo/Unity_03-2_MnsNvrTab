using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScene : MonoBehaviour
{
    Animator characterAnimator;

    // Start is called before the first frame update
    void Start()
    {
        //GameManager.GetInstance().LoadData();

        string characterName = "";
        if (GameManager.GetInstance().characterIdx == 0 )
        { 
            characterName = GameManager.GetInstance().PlayerDatas[GameManager.GetInstance().characterIdx].playerImg; 
            // GameManager.GetInstance().totalHp = GameManager.GetInstance().mageHp;
           //  GameManager.GetInstance().curHp = GameManager.GetInstance().mageHp;
        }
       
        else
        {
            characterName =  GameManager.GetInstance().PlayerDatas[GameManager.GetInstance().characterIdx].playerImg;
           //  GameManager.GetInstance().totalHp = GameManager.GetInstance().redHp;
           //  GameManager.GetInstance().curHp = GameManager.GetInstance().redHp;
        }

        GameObject go = ObjectManager.GetInstance().CreateCharacter(characterName);
        go.transform.localScale = new Vector3(2, 2, 2);
        go.transform.localPosition = new Vector3(0, 1.1f, 0);

        characterAnimator = go.GetComponent<Animator>();

        UIManager.GetInstance().SetEventSystem();
        UIManager.GetInstance().OpenUI("UIProfile");
        UIManager.GetInstance().OpenUI("UIActionMenu");
    }
}
