using UnityEngine;
using DG.Tweening;

public class JumpArea : MonoBehaviour
{
    public Transform JumpPointA;
    public Transform JumpPointB;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Luna"))
        {
            LunaController lunaController=collision.transform.GetComponent<LunaController>();
            lunaController.Jump(true);
            float distanceA=Vector3.Distance(lunaController.transform.position,JumpPointA.transform.position);
            float distanceB=Vector3.Distance(lunaController.transform.position,JumpPointB.transform.position);
            Transform targetTrans;
            if (distanceA < distanceB)
            {
                targetTrans=JumpPointB;
            }
            else
            {
                targetTrans=JumpPointA;
            }
            lunaController.transform.DOMove(targetTrans.position,0.5f).SetEase(Ease.Linear).OnComplete(()=>{EndJump(lunaController);});
            Transform lunaLocalTrans=lunaController.transform.GetChild(0);
            Sequence sequence=DOTween.Sequence();
            sequence.Append(lunaLocalTrans.DOLocalMoveY(1.5f,0.25f).SetEase(Ease.InOutSine));
            sequence.Append(lunaLocalTrans.DOLocalMoveY(0.46f,0.25f).SetEase(Ease.InOutSine));
            sequence.Play();

        }
    }
    private void EndJump(LunaController lunaController)
    {
        lunaController.Jump(false);
    }
}
