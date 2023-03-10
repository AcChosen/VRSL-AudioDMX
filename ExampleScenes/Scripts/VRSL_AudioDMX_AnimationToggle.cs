
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

[UdonBehaviourSyncMode(BehaviourSyncMode.None)]
public class VRSL_AudioDMX_AnimationToggle : UdonSharpBehaviour
{
    public Animator targetAnimator;
    public string animationBooleanName;
    public bool currentState;
    public float animationSpeed = 1.0f;
    public string animationSpeedFloatName;
    void Start()
    {
        if(animationSpeedFloatName != "" && targetAnimator != null)
            targetAnimator.SetFloat(animationSpeedFloatName, animationSpeed);
    }
    
    public void _EnableAnimation()
    {
        if(currentState == false && animationBooleanName != "" && targetAnimator != null)
        {
            targetAnimator.SetBool(animationBooleanName, true);
            currentState = true;
        }
    }
    public void _DisableAnimation()
    {
        if(currentState == true && animationBooleanName != "" && targetAnimator != null)
        {
            targetAnimator.SetBool(animationBooleanName, false);
            currentState = false;
        }
    }
}
