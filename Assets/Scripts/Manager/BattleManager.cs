using System.Collections;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    #region Singletone
    private static BattleManager instance = null;

    public static BattleManager GetInstance()
    {
        if (instance == null)
        {
            GameObject go = new GameObject("@BattleManager");
            instance = go.AddComponent<BattleManager>();

            DontDestroyOnLoad(go);
        }

        return instance;
    }
    #endregion

    public Monster1 monsterData;

    public Monster1[] monsterDatas = new Monster1[]
    {
        new Monster1("Monster1",10,10,2.5f,300),
        new Monster1("Monster2",10,15,2f,1000),
        new Monster1("Monster3",10,5,3f,100),
        new Monster1("Monster4",10,8,2f,1000)

    };
   
    
    public Monster1 GetRandomMonster()
    {
        int rand = Random.Range(0, monsterDatas.Length);

        return monsterDatas[rand];
    }

    public void BattleStart(Monster1 monster)
    {
        monsterData = monster;

        EffectManager.GetInstance().InitEffectPool(10);

        UIManager.GetInstance().OpenUI("UITab");

        StartCoroutine("BattleProgress");
    }

    // 2~3 �� �ð� ������ ���Ͱ� ���� ����
    IEnumerator BattleProgress()
    {
        while (GameManager.GetInstance().PlayerDatas[GameManager.GetInstance().characterIdx].curHp > 0)
        {
            yield return new WaitForSeconds(monsterData.delay);

            int damage = monsterData.atk;
            GameManager.GetInstance().SetCurrentHP(-damage);

            GameObject ui = UIManager.GetInstance().GetUI("UIProfile");
            if (ui != null)
                ui.GetComponent<UIProfile>().RefreshState();

            Debug.Log($"���Ͱ� �÷��̾�� ������ �߽��ϴ� - ������ : {damage}     ���� ü�� : {GameManager.GetInstance().PlayerDatas[GameManager.GetInstance().characterIdx].curHp}");
        }

        Lose();
    }

    public void AttackMonster()
    {
        EffectManager.GetInstance().UseEffect();

        monsterData.hp--;
                

        if (monsterData.hp <= 0)
        {
            Victory();
        }
    }

    void Victory()
    {
        Debug.Log("���ӿ��� �¸��߽��ϴ�.");
        StopCoroutine("BattleProgress");
        UIManager.GetInstance().CloseUI("UITab");

        GameManager.GetInstance().AddGold(monsterData.gold);

        Invoke("MoveToMain", 2.5f);
    }

    void Lose()
    {
        Debug.Log("���ӿ��� �й��߽��ϴ�.");
        UIManager.GetInstance().CloseUI("UITab");

        if (GameManager.GetInstance().SpendGold(500))
            GameManager.GetInstance().SetCurrentHP(80);
        else
            GameManager.GetInstance().SetCurrentHP(10);

        Invoke("MoveToMain", 2.5f);
    }

    void MoveToMain()
    {
        ScenesManager.GetInstance().ChangeScene(Scene.Main);
    }
}
