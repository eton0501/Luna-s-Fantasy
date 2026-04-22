using UnityEngine;

public class LunaController : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    public float moveSpeed;
    private int maxHealth;
    public int MaxHealth{get{return maxHealth;}}
    private int currentHealth;
    public int Health{get{return currentHealth;}}
    void Start()
    {
        rigidbody2D=GetComponent<Rigidbody2D>();
        maxHealth=5;
        currentHealth=maxHealth;
    }

    void Update()
    {
        float horizontal=Input.GetAxis("Horizontal");
        float vertical=Input.GetAxis("Vertical");
        Vector2 position=transform.position;
        position.x=position.x+moveSpeed*horizontal*Time.deltaTime;
        position.y=position.y+moveSpeed*vertical*Time.deltaTime;
        rigidbody2D.MovePosition(position);
    }
    public void ChangeHealth(int amount)
    {
        currentHealth=Mathf.Clamp(currentHealth+amount,0,maxHealth);
        Debug.Log(currentHealth+""+maxHealth);
    }
}
