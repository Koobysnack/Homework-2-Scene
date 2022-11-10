using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class EmitForTime : MonoBehaviour
{
    [SerializeField] private float time;
    private ParticleSystem system;
    private bool inCycle;

    private void Awake() {
        system = GetComponent<ParticleSystem>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update() {
        if(!inCycle)
            StartCoroutine("spawnForTime");
    }

    private IEnumerator spawnForTime() {
        system.Play();
        inCycle = true;
        yield return new WaitForSeconds(time);
        system.Stop();
        yield return new WaitForSeconds(time);
        inCycle = false;
    }
}
