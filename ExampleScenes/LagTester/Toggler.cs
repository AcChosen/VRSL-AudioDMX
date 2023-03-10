
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

namespace VRSL
{
[UdonBehaviourSyncMode(BehaviourSyncMode.None)]
public class Toggler : UdonSharpBehaviour
{
        public GameObject target;

        public override void Interact()
        {
            bool toggle = !target.activeSelf;
            target.SetActive(toggle);
        }
}
}