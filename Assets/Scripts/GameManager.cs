using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int lunaHP;
    public int lunaCurrentHP;
    public int lunaMP;
    public int lunaCurrentMP;
    public int monsterCurrentHP;
    public GameObject battleGo;
    private void Awake()
    {
        Instance=this;
        lunaHP=lunaCurrentHP=100;
        lunaMP=lunaCurrentMP=100;
        monsterCurrentHP=50;
    }

    public void EnterOrExitBattle(bool enter = true)
    {
        UIManger.Instance.ShowOrHideBattlePanel(enter);
        battleGo.SetActive(enter);
    }
    public void AddOrDecreaseHP(int value)
    {
        lunaCurrentHP+=value;
        if (lunaCurrentHP >= lunaHP)
        {
            lunaCurrentHP=lunaHP;
        }
        if (lunaCurrentHP <= 0)
        {
            lunaCurrentHP=0;
        }
        UIManger.Instance.SetHPValue((float)lunaCurrentHP/lunaHP);
    }
    public void AddOrDecreaseMP(int value)
    {
        lunaCurrentMP+=value;
        if (lunaCurrentMP >= lunaMP)
        {
            lunaCurrentMP=lunaMP;
        }
        if (lunaCurrentMP <= 0)
        {
            lunaCurrentMP=0;
        }
        UIManger.Instance.SetMPValue((float)lunaCurrentMP/lunaMP);
    }
    public bool CanUsePlayerMP(int value)
    {
        return lunaCurrentMP>=value;
    }
    public int AddOrDecreaseMonsterHP(int value)
    {
        monsterCurrentHP+=value;
        return monsterCurrentHP;
    }
}
