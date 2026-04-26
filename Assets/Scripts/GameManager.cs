using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int lunaHP;
    public float lunaCurrentHP;
    public int lunaMP;
    public float lunaCurrentMP;
    public int monsterCurrentHP;
    public int dialogInfoIndex;
    public bool canControlLuna;
    public bool hasPetTheDog;
    public int candleNum;
    public int killNum;
    public GameObject battleGo;
    public GameObject monsterGo;
    public NPCDialog npc;
    public bool enterBattle;
    public GameObject battleMonsterGo; 
    public AudioSource audioSource;
    public AudioClip normalClip;
    public AudioClip battleClip;
    private void Awake()
    {
        Instance=this;
        lunaCurrentHP=100;
        lunaCurrentMP=100;
        lunaHP=100;
        lunaMP=100;
        monsterCurrentHP=50;
    }

    void Update()
    {
        if (!enterBattle)
        {
            if (lunaCurrentHP <= 100)
            {
                AddOrDecreaseHP(Time.deltaTime);
            }
            if (lunaCurrentHP <= 100)
            {
                AddOrDecreaseMP(Time.deltaTime);
            }
        }
    }

    public void EnterOrExitBattle(bool enter = true,int addKillNum = 0)
    {
        UIManger.Instance.ShowOrHideBattlePanel(enter);
        battleGo.SetActive(enter);
        if (!enter)
        {
            killNum += addKillNum;
            if (addKillNum > 0)
            {
                DestoryMonster();
            }
            monsterCurrentHP = 50;
            PlayMusic(normalClip);
            if (lunaCurrentHP <= 0)
            {
                lunaCurrentHP = 100;
                lunaCurrentMP = 0;
                battleMonsterGo.transform.position += new Vector3(0, 2, 0);
            }
        }
        else
        {
            PlayMusic(battleClip);
        }
        enterBattle = enter;
    }
    public void DestoryMonster()
    {
        Destroy(battleMonsterGo);
    }
    public void SetMonster(GameObject go)
    {
        battleMonsterGo = go;
    }
    public void AddOrDecreaseHP(float value)
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
        UIManger.Instance.SetHPValue(lunaCurrentHP/lunaHP);
    }
    public void AddOrDecreaseMP(float value)
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
        UIManger.Instance.SetMPValue(lunaCurrentMP/lunaMP);
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
    public void ShowMonsters()
    {
        if (!monsterGo.activeSelf)
        {
            monsterGo.SetActive(true);
        }
    }
    public void SetContentIndex()
    {
        npc.SetContentIndex();
    }
    public void PlayMusic(AudioClip audioClip)
    {
        if (audioSource.clip != audioClip)
        {
            audioSource.clip = audioClip;
            audioSource.Play();
        }
    }
    public void PlaySound(AudioClip audioClip)
    {
        if (audioClip)
        {
            audioSource.PlayOneShot(audioClip);
        }
    }
}
