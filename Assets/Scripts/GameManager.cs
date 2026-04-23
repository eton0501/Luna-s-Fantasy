using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private int maxHealth;
    public int MaxHealth{get{return maxHealth;}}
    private int currentHealth;
    public int Health{get{return currentHealth;}}
    private void Awake()
    {
        Instance=this;
        maxHealth=5;
        currentHealth=4;
    }
    public void ChangeHealth(int amount)
    {
        currentHealth=Mathf.Clamp(currentHealth+amount,0,maxHealth);
        Debug.Log(currentHealth+""+maxHealth);
    }
}
