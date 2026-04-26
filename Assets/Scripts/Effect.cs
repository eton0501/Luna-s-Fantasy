using UnityEngine;

public class Effect : MonoBehaviour
{
    public float destoryTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (destoryTime != -1)
        {
            Destroy(gameObject,destoryTime);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
