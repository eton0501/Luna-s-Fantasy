using UnityEngine;

public class LunaController : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    public float moveSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidbody2D=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal=Input.GetAxis("Horizontal");
        float vertical=Input.GetAxis("Vertical");
        Vector2 position=transform.position;
        position.x=position.x+moveSpeed*horizontal*Time.deltaTime;
        position.y=position.y+moveSpeed*vertical*Time.deltaTime;
        rigidbody2D.MovePosition(position);
    }
}
