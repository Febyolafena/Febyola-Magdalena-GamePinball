using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;


public class Switch : MonoBehaviour
{
    // enum untuk menatur state
    private enum SwitchState
    {
        Off,
        On,
        Blink
    }


    // Material variabel on off 
    public Collider bola;
    public Material offMaterial;
    public Material onMaterial;
    
    public AudiooManager audioManager;

    public VFXManager VFXManager;

    // menggantikan isOn
    private SwitchState state;

    // Renderer object 
    private Renderer renderer;

    public ScoreManager scoreManager;

    public float score;


    private void Start()
    {
        renderer = GetComponent<Renderer>();

        Set(false);

        StartCoroutine(BlinkTimerStart(5));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == bola)
        {
            Toggle();
            
            var playPos = other.transform.position;
            
            audioManager.PlaySFX(playPos);

            VFXManager.PlayVFX(playPos);
        }
    }

    private void Set(bool active)
    {
        if (active == true)
        {
            state = SwitchState.On;
            renderer.material = onMaterial;
            StopAllCoroutines();
        }
        else
        {
            state = SwitchState.Off;
            renderer.material = offMaterial;
            StartCoroutine(BlinkTimerStart(5));
        }
    }

    private void Toggle()
    {
        scoreManager.AddScore(10);

        if (state == SwitchState.On)
        {
            Set(false);
        }
        else
        {
            Set(true);
        }
    }

    private IEnumerator Blink(int times)
    {
        state = SwitchState.Blink;

        for (int i = 0; i < times; i++)
        {
            renderer.material = onMaterial;
            yield return new WaitForSeconds(0.5f);
            renderer.material = offMaterial;
            yield return new WaitForSeconds(0.5f);
        }
        state = SwitchState.Off;

        StartCoroutine(BlinkTimerStart(5));
    }

    private IEnumerator BlinkTimerStart(float time)
    {
        yield return new WaitForSeconds(time);
        StartCoroutine(Blink(2));
    }
}
