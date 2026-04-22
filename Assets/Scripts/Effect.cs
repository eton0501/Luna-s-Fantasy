using UnityEngine;

public class Effect : MonoBehaviour
{
    public float destoryTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject,destoryTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
