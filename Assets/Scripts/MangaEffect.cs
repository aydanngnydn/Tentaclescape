using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MangaEffect : MonoBehaviour
{
    private BulletMovement bullet;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        bullet.OnBulletStopStart += MangaEffectAnimStart;
        bullet.OnBulletStopEnd += MangaEffectAnimEnd;
    }

    private void OnDisable()
    {
        bullet.OnBulletStopStart -= MangaEffectAnimStart;
        bullet.OnBulletStopEnd -= MangaEffectAnimEnd;
    }

    private void MangaEffectAnimStart()
    {
        animator.SetBool("IsStopTime", true);
    }

    private void MangaEffectAnimEnd()
    {
        animator.SetBool("IsStopTime", false);
    }
}
