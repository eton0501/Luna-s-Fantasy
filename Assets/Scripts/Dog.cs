using UnityEngine;

public class Dog : MonoBehaviour
{
    private Animator animator;
    public GameObject starEffect;
    public AudioClip petSound;
    void Start()
    {
        animator=GetComponent<Animator>();
    }

    public void BeHappy()
    {
        animator.CrossFade("Comforted",0);
        GameManager.Instance.hasPetTheDog=true;
        GameManager.Instance.SetContentIndex();
        Destroy(starEffect);
        GameManager.Instance.PlaySound(petSound);
        Invoke("CanControlLuna",1.75f);
    }
    private void CanControlLuna()
    {
        GameManager.Instance.canControlLuna=true;
    }
}
