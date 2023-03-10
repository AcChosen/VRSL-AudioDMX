
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

namespace VRSL
{
[UdonBehaviourSyncMode(BehaviourSyncMode.None)]
public class VRSL_AudioDMX_ParticleToggler : UdonSharpBehaviour
{
    public ParticleSystem particles;
    [SerializeField]
    bool currentstate;
    bool previousstate;


    void Start()
    {
        currentstate = false;
        previousstate = false;
        if(particles.isPlaying)
            particles.Stop();
    }
    public void _EnableParticles()
    {
        currentstate = true;
        if(currentstate != previousstate)
        {
            CheckParticles();
            previousstate = currentstate;
        }
    }
    public void _DisableParticles()
    {
        currentstate = false;
        if(currentstate != previousstate)
        {
            CheckParticles();
            previousstate = currentstate;
        }
    }

    void CheckParticles()
    {
        if(currentstate)
        {
            particles.Play();
            Debug.Log("Starting Particles");
        }
        else
        {
                particles.Stop();
                Debug.Log("Stopping Particles");
        }
        
    }

    
}
}