using UnityEngine;

public class ClimbArea : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Luna"))
        {
            collision.GetComponent<LunaController>().Climb(true);
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Luna"))
        {
            collision.GetComponent<LunaController>().Climb(false);
        }
    }
}
