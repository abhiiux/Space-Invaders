using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Death : MonoBehaviour
{
    Animator animator;
    float delay;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
 public void Die(bool playerorenemy)
 {
    if(animator != null)
    {
      if(playerorenemy)
      {
      animator.Play("Death");
      delay = 0.20f;
      // Destroy(gameObject);
      }
      else
      {
         animator.Play("Player_death");
         delay = 1f;
      }
    }
    StartCoroutine(DestroyAfterDelay(delay));
 }
 private IEnumerator DestroyAfterDelay(float Delay)
 {
    yield return new WaitForSeconds(Delay);
    Destroy(gameObject);
 }
}
