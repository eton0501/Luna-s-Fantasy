using System.Collections;
using DG.Tweening;
using UnityEditor.Rendering;
using UnityEngine;

public class BattleController : MonoBehaviour
{
    public Animator lunaAnimator;
    public Transform lunaTrans;
    public Transform monsterTrans;
    private Vector3 monsterInitPos;
    private Vector3 lunaInitPos;
    public SpriteRenderer monsterSr;
    public SpriteRenderer lunaSr;
    public GameObject skillEffectGo;
    public GameObject healEffectGo;
    void Awake()
    {
        monsterInitPos=monsterTrans.localPosition;
        lunaInitPos=lunaTrans.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnable()
    {
        monsterSr.DOFade(1,0.1f);
        lunaSr.DOFade(1,0.1f);
        lunaTrans.localPosition=lunaInitPos;
        monsterTrans.localPosition=monsterInitPos;
    }

    public void LunaAttack()
    {
        StartCoroutine(PerformAttackLogic());
    }
    public void LunaDefend()
    {
        StartCoroutine(PeformDefendLogic());
    }
    public void LunaSkill()
    {
        if (!GameManager.Instance.CanUsePlayerMP(30))
        {
            return;
        }
        StartCoroutine(PeformSkillLogic());
    }
    public void LunaRecoverHP()
    {
        if (!GameManager.Instance.CanUsePlayerMP(50))
        {
            return;
        }
        StartCoroutine(PerformRecoverHPLogic());
    }

    public void LunaEscape()
    {
        UIManger.Instance.ShowOrHideBattlePanel(false);
        lunaTrans.DOLocalMove(lunaInitPos+new Vector3(5, 0, 0), 0.5f).OnComplete(() =>
        {
            GameManager.Instance.EnterOrExitBattle(false);
        });
        lunaAnimator.SetBool("MoveState",true);
        lunaAnimator.SetFloat("MoveValue",1);
    }

    IEnumerator PerformRecoverHPLogic()
    {
        UIManger.Instance.ShowOrHideBattlePanel(false);
        lunaAnimator.CrossFade("RecoverHP",0);
        GameManager.Instance.AddOrDecreaseMP(-50);
        yield return new WaitForSeconds(0.1f);
        GameObject go=Instantiate(healEffectGo,lunaTrans);
        go.transform.localPosition=Vector3.zero;
        GameManager.Instance.AddOrDecreaseHP(40);
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(MonsterAttack());
    }

    IEnumerator PerformAttackLogic()
    {
        UIManger.Instance.ShowOrHideBattlePanel(false);
        lunaAnimator.SetBool("MoveState",true);
        lunaAnimator.SetFloat("MoveValue",-1);
        lunaTrans.DOLocalMove(monsterInitPos+new Vector3(2,0,0),0.5f).OnComplete
        (
            () =>
            {
                lunaAnimator.SetBool("MoveState",false);
                lunaAnimator.SetFloat("MoveValue",0);
                lunaAnimator.CrossFade("Attack",0);
                monsterSr.DOFade(0.3f,0.2f).OnComplete(()=>{JudgeMonsterHP(-20);});
            }
        );
        yield return new WaitForSeconds(1.167f);
        lunaAnimator.SetBool("MoveState",true);
        lunaAnimator.SetFloat("MoveValue",1);
        lunaTrans.DOLocalMove(lunaInitPos,0.5f).OnComplete(()=>{lunaAnimator.SetBool("MoveState",false);});
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(MonsterAttack());
    }
    IEnumerator PeformDefendLogic()
    {
        UIManger.Instance.ShowOrHideBattlePanel(false);
        lunaAnimator.SetBool("Defend",true);
        monsterTrans.DOLocalMove(lunaInitPos-new Vector3(1.5f,0,0),0.5f);
        yield return new WaitForSeconds(1f);
        monsterTrans.DOLocalMove(lunaInitPos, 0.2f).OnComplete(() =>
        {
            monsterTrans.DOLocalMove(lunaInitPos-new Vector3(1.5f,0,0),0.2f);
            lunaTrans.DOLocalMove(lunaInitPos+new Vector3(1, 0, 0), 0.2f).OnComplete(() =>
            {
                lunaTrans.DOLocalMove(lunaInitPos,0.2f);
            });
        });
        yield return new WaitForSeconds(0.4f);
        monsterTrans.DOLocalMove(monsterInitPos, 0.5f).OnComplete(() =>
        {
            UIManger.Instance.ShowOrHideBattlePanel(true);
            lunaAnimator.SetBool("Defend",false);
        });
    }
    IEnumerator PeformSkillLogic()
    {
        UIManger.Instance.ShowOrHideBattlePanel(false);
        lunaAnimator.CrossFade("Skill",0);
        GameManager.Instance.AddOrDecreaseMP(-30);
        yield return new WaitForSeconds(0.35f);
        GameObject go=Instantiate(skillEffectGo,monsterTrans);
        go.transform.localPosition=Vector3.zero;
        yield return new WaitForSeconds(0.4f);
        monsterSr.DOFade(0.3f, 0.2f).OnComplete(() =>
        {
            JudgeMonsterHP(-40);
        });
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(MonsterAttack());

    }

    IEnumerator MonsterAttack()
    {
        monsterTrans.DOLocalMove(lunaInitPos-new Vector3(1.5f,0,0),0.5f);
        yield return new WaitForSeconds(1f);
        monsterTrans.DOLocalMove(lunaInitPos, 0.2f).OnComplete(() =>
        {
            monsterTrans.DOLocalMove(lunaInitPos-new Vector3(1.5f,0,0),0.2f);
            lunaAnimator.CrossFade("Hit",0);
            lunaSr.DOFade(0.3f,0.2f).OnComplete(()=>{lunaSr.DOFade(1,0.2f);});
            JudgeLunaHP(-20);
        });
        yield return new WaitForSeconds(0.4f);
        monsterTrans.DOLocalMove(monsterInitPos, 0.5f).OnComplete(() =>
        {
            UIManger.Instance.ShowOrHideBattlePanel(true);
        });
    }
    private void JudgeMonsterHP(int value)
    {
        if (GameManager.Instance.AddOrDecreaseMonsterHP(value) <= 0)
        {
            monsterSr.DOFade(0, 0.4f).OnComplete(() =>
            {
                GameManager.Instance.EnterOrExitBattle(false);
            });
        }
        else
        {
            monsterSr.DOFade(1,0.2f);
        }
    }
    private void JudgeLunaHP(int value)
    {
        GameManager.Instance.AddOrDecreaseHP(value);
        if (GameManager.Instance.lunaCurrentHP <= 0)
        {
            lunaAnimator.CrossFade("Die",0);
            lunaSr.DOFade(0, 0.8f).OnComplete(() =>
            {
                GameManager.Instance.EnterOrExitBattle(false);
            });

        }
    }
}
