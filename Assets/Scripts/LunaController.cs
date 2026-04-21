using UnityEngine;

public class LunaController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal=Input.GetAxis("Horizontal");
        float vertical=Input.GetAxis("Vertical");
        Vector2 position=transform.position;
        position.x=position.x+3*horizontal*Time.deltaTime;
        position.y=position.y+3*vertical*Time.deltaTime;
        transform.position=position;
    }
}
