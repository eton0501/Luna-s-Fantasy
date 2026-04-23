using UnityEngine;

public class LunaController : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    public float moveSpeed;
    
    private Animator animator;
    private Vector2 lookDirection=new Vector2(1,0);
    private float moveScale;
    private Vector2 move;
    void Start()
    {
        rigidbody2D=GetComponent<Rigidbody2D>();
        
        animator=GetComponentInChildren<Animator>();
    }


    void Update()
    {
        float horizontal=Input.GetAxisRaw("Horizontal");
        float vertical=Input.GetAxisRaw("Vertical");
        move=new Vector2(horizontal,vertical);
        if (!Mathf.Approximately(move.x, 0) || !Mathf.Approximately(move.y, 0))
        {
            lookDirection.Set(move.x,move.y);
            lookDirection.Normalize();
        }
        animator.SetFloat("LookX",lookDirection.x);
        animator.SetFloat("LookY",lookDirection.y);
        moveScale=move.magnitude;
        if (move.magnitude > 0)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                moveScale=1;
                moveSpeed=2;
            }
            else
            {
                moveScale=2;
                moveSpeed=3.5f;
            }
        }
        animator.SetFloat("MoveValue",moveScale);

    }
    void FixedUpdate()
    {
        Vector2 position=transform.position;
        position=position+moveSpeed*move*Time.fixedDeltaTime;
        rigidbody2D.MovePosition(position);
    }
    

    public void Climb(bool start)
    {
        animator.SetBool("Climb",start);
    }

    public void Jump(bool start)
    {
        animator.SetBool("Jump",start);
        rigidbody2D.simulated=!start;
    }
}
