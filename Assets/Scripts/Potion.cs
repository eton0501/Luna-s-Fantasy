using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Potion : MonoBehaviour
{
    public GameObject effectGo;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameManager.Instance.lunaCurrentHP < GameManager.Instance.lunaHP)
            {
                GameManager.Instance.AddOrDecreaseHP(40);
                Instantiate(effectGo,transform.position,Quaternion.identity);
                Destroy(gameObject);
            }   
    }
}
