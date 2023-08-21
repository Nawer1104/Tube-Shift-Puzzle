using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holder : MonoBehaviour
{
    private Animator animator;

    [SerializeField] GameObject particleVFX;

    public bool isFilled = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Show()
    {
        isFilled = true;
        animator.SetTrigger("Show");
        GameManager.Instance.levels[GameManager.Instance.GetCurrentIndex()].holders.Remove(this.gameObject);
        GameObject explosion = Instantiate(particleVFX, transform.position, transform.rotation);
        Destroy(explosion, .75f);
    }
    

    private IEnumerator ExampleCoroutine()
    {
        animator.SetTrigger("Show");

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(1);

        GameManager.Instance.levels[GameManager.Instance.GetCurrentIndex()].holders.Remove(this.gameObject);
        GameObject explosion = Instantiate(particleVFX, transform.position, transform.rotation);
        Destroy(explosion, .75f);
    }
}