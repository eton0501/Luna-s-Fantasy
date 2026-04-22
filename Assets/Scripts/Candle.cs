using UnityEngine;

public class Candle : MonoBehaviour
{
    public GameObject effectGo;

    void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(effectGo,transform.position,Quaternion.identity);
        Destroy(gameObject);
    }
}
