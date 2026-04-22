using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Potion : MonoBehaviour
{
    public GameObject effectGo;
    void OnTriggerEnter2D(Collider2D collision)
    {
        LunaController lunaController=collision.GetComponent<LunaController>();
        if (lunaController != null)
        {
            if (lunaController.Health < lunaController.MaxHealth)
            {
                lunaController.ChangeHealth(1);
                Instantiate(effectGo,transform.position,Quaternion.identity);
                Destroy(gameObject);
            }
        }
        
    }
}
