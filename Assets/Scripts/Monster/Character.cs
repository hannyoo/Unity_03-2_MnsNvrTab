public class Character
{
    public string playerImg;
    public string playerName;

    public int level;
    public int totalHp; // 증가
    public int curHp;
    public int gold; // 추가, 삭제

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


