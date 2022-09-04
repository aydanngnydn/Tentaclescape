using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimeBorder : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private BulletMovement bullet;
    void Start()
    {
        bullet.OnBulletStopStart += StartAnim;
        bullet.OnBulletStopEnd += StopAnim;
    }

    void StartAnim()
    {
        anim.SetBool("Begin", true);
    }

    void StopAnim()
    {
        anim.SetBool("Begin", false);
    }

}
