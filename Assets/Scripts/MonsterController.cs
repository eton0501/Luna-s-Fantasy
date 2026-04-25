using UnityEngine;

public class MonsterController : MonoBehaviour
{
    //軸向控制
    public bool vertical;
    public float speed=5;
    //方向控制
    private int direction=1;
    //方向改變時間間隔
    public float changeTime=5;
    //計時器
    private float timer;
    //剛體組件引用，為了使用剛體進行移動
    private Rigidbody2D rigidbody2D;
    //動畫控制器組件引用，為了播放動畫
    private Animator animator;
    
    void Start()
    {
        rigidbody2D=GetComponent<Rigidbody2D>();
        timer=changeTime;
        animator=GetComponent<Animator>();
    }

    
    void Update()
    {
        timer-=Time.deltaTime;
        if (timer < 0)
        {
            direction=-direction;
            timer=changeTime;
        }
    }

    void FixedUpdate()
    {
        Vector3 pos=rigidbody2D.position;
        if (vertical)
        {
            animator.SetFloat("LookX",0);
            animator.SetFloat("LookY",direction);
            pos.y=pos.y+speed*direction*Time.fixedDeltaTime;
        }
        else
        {
            animator.SetFloat("LookX",direction);
            animator.SetFloat("LookY",0);
            pos.x=pos.x+speed*direction*Time.fixedDeltaTime;
        }
        rigidbody2D.MovePosition(pos);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Luna"))
        {
            GameManager.Instance.EnterOrExitBattle();
        }
    }
}
