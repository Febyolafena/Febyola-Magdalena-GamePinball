using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class BumperController : MonoBehaviour
{
    public Collider bola;
    public float multiplier;
    public Color color;

    private Renderer renderer;
    private Animator animator;

    public AudiooManager audiooManager;

    public VFXManager VFXManager;

    public ScoreManager scoreManager;

    public float score;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
        renderer.material.color = color;

        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider == bola)
        {
            Rigidbody bolaRig = bola.GetComponent<Rigidbody>();
            bolaRig.velocity *= multiplier;

            animator.SetTrigger("Hit");

            audiooManager.PlaySFX(collision.transform.position);

            VFXManager.PlayVFX(collision.transform.position);

            scoreManager.AddScore(10);
        }
    }
}
