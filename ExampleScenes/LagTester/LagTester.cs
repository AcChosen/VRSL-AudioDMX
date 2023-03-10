
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;


namespace VRSL
{
[UdonBehaviourSyncMode(BehaviourSyncMode.None)]

public class LagTester : UdonSharpBehaviour
{
    //literally all this does is tank your FPS
    //For testing performance of other scripts under load.
    void Update()
    {
        float[] x = new float[4096];
        for(int i = 0; i < x.Length; i++)
        {
            x[i] = Random.Range(-10000.0f, 10000.0f);
            x[i] += 45 /2 * 546 -3;
            x[i] = Random.Range(-10000.0f, 10000.0f);
            x[i] += 45 /2 * 546 -3;
            x[i] = Random.Range(-10000.0f, 10000.0f);
            x[i] += 45 /2 * 546 -3;
            x[i] = Random.Range(-10000.0f, 10000.0f);
            x[i] += 45 /2 * 546 -3;
            x[i] = Random.Range(-10000.0f, 10000.0f);
            x[i] += 45 /2 * 546 -3;
            x[i] = Random.Range(-10000.0f, 10000.0f);
            x[i] += 45 /2 * 546 -3;
            x[i] = Random.Range(-10000.0f, 10000.0f);
            x[i] += 45 /2 * 546 -3;
            x[i] = Random.Range(-10000.0f, 10000.0f);
            x[i] += 45 /2 * 546 -3;
        }
    }
}
}
