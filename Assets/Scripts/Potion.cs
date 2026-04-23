using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Potion : MonoBehaviour
{
    public GameObject effectGo;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameManager.Instance.Health < GameManager.Instance.MaxHealth)
            {
                GameManager.Instance.ChangeHealth(1);
                Instantiate(effectGo,transform.position,Quaternion.identity);
                Destroy(gameObject);
            }   
    }
}
