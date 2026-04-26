using Unity.VisualScripting;
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
        if (GameManager.Instance.enterBattle)
        {
            return;
        }
        if (!GameManager.Instance.canControlLuna)
        {
            return;
        }

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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Talk();
        }

    }
    void FixedUpdate()
    {
        if (GameManager.Instance.enterBattle)
        {
            return;
        }
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
    public void Talk()
    {
        Collider2D collider=Physics2D.OverlapCircle(rigidbody2D.position,0.5f,LayerMask.GetMask("NPC"));
        if (collider != null)
        {
            if (collider.name == "Nala")
            {
                GameManager.Instance.canControlLuna=false;
                collider.GetComponent<NPCDialog>().DisplayDialog();
            }
            else if (collider.name == "Dog" && !GameManager.Instance.hasPetTheDog && GameManager.Instance.dialogInfoIndex == 2)
            {
                PetTheDog();
                GameManager.Instance.canControlLuna=false;
                collider.GetComponent<Dog>().BeHappy();
            }
        }
    }
    public void PetTheDog()
    {
        animator.CrossFade("PetTheDog",0);
        transform.position=new Vector3(-1.19f,-7.8f,0);
    }
}
