public class Character
{
    public string playerImg;
    public string playerName;

    public int level;
    public int totalHp; // ����
    public int curHp;
    public int gold; // �߰�, ����

    public Character(string playerImg, string playerName, int level, int totalHp, int curHp, int gold)
    {
        this.playerImg = playerImg;
        this.playerName = playerName;
        this.level = level;
        this.totalHp = totalHp;
        this.curHp = curHp;        
        this.gold = gold;
    }

}


