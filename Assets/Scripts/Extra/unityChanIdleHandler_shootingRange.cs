using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unityChanIdleHandler_shootingRange : MonoBehaviour
{
    [SerializeField] private Vector2Int idleRange = Vector2Int.zero;
    [SerializeField] private Vector2 changeIdleAnimationRange = Vector2.zero;
    private Animator currentAnimator = null;
    private bool mPA_isStarting = false;

    private void Start()
    {
        currentAnimator = GetComponent<Animator>();
        StartCoroutine(ChangeIdleAnimationCour());
    }

    public void Start_MPA()
    {
        mPA_isStarting = true;
        ChangeIdleAnimation(0);
    }

    public void End_MPA()
    {
        mPA_isStarting = false;
    }

    private IEnumerator ChangeIdleAnimationCour()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(changeIdleAnimationRange.x, changeIdleAnimationRange.y));
            if (!mPA_isStarting)
            {
                ChangeIdleAnimation(Random.Range(idleRange.x, idleRange.y));
            }
        }
    }

    private void ChangeIdleAnimation(int idleVariant)
    {

        currentAnimator.SetInteger("Idle", idleVariant);
        currentAnimator.SetTrigger("Change");
    }
}
