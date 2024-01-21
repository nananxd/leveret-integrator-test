using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdlePlayer : MonoBehaviour
{
    private Animator animator;

    private const string TRIGGER_FORMAT = "Fidget_{0}";
    private const string DEFAULT_IDLE_TRIGGER = "Default";

    private void Start()
    {
        this.animator = this.GetComponent<Animator>();
        TryPlayRandomIdle();
    }

    public void ReturnToDefaultIdle()
    {
        StopAllCoroutines();
        this.animator.SetTrigger(DEFAULT_IDLE_TRIGGER);
    }

    public void TryPlayRandomIdle()
    {
        StartCoroutine(WaitToPlayRandomIdle());
    }

    private IEnumerator WaitToPlayRandomIdle()
    {
        int delay = Random.Range(4, 8);
        yield return new WaitForSeconds(delay);
        PlayRandomIdle();
    }

    private void PlayRandomIdle()
    {
        int idx = Random.Range(1, 5);
        this.animator.SetTrigger(string.Format(TRIGGER_FORMAT, idx));
        StartCoroutine(WaitForAnimationToFinish());
    }

    private IEnumerator WaitForAnimationToFinish()
    {
        yield return null;

        yield return new WaitUntil(() => { return this.animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f && !this.animator.IsInTransition(0); });

        this.animator.SetTrigger(DEFAULT_IDLE_TRIGGER);
        StartCoroutine(WaitToPlayRandomIdle());
    }
}
