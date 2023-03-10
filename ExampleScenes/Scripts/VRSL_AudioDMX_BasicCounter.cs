
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

namespace VRSL
{

[UdonBehaviourSyncMode(BehaviourSyncMode.None)]
public class VRSL_AudioDMX_BasicCounter : UdonSharpBehaviour
{
    public UnityEngine.UI.Text textDisplay;
    public bool[] boolArray = new bool[8];
    public int currentValue = 0;
    public bool sendCustomFunction;
    public UdonSharpBehaviour targetBehaviour;
    public string targetFunction;
    void Start()
    {
        ConvertBoolArrayToByte();
    }

    public void _Enable1sPlace()
    {
        if(boolArray[7] == false)
        {
            boolArray[7] = true; //1
            ConvertBoolArrayToByte();
        }
    }
    public void _Disable1sPlace()
    {
        if(boolArray[7] == true)
        {
            boolArray[7] = false;
            ConvertBoolArrayToByte();
        }
    }
    public void _Enable2sPlace()
    {
        if(boolArray[6] == false)
        {
            boolArray[6] = true; //2
            ConvertBoolArrayToByte();
        }
    }
    public void _Disable2sPlace()
    {
        if(boolArray[6] == true)
        {
            boolArray[6] = false;
            ConvertBoolArrayToByte();
        }
    }
    public void _Enable4sPlace()
    {
        if(boolArray[5] == false)
        {
            boolArray[5] = true; //4
            ConvertBoolArrayToByte();
        }
    }
    public void _Disable4sPlace()
    {
        if(boolArray[5] == true)
        {
            boolArray[5] = false;
            ConvertBoolArrayToByte();
        }
    }
    public void _Enable8sPlace()
    {
        if(boolArray[4] == false)
        {
            boolArray[4] = true; //8
            ConvertBoolArrayToByte();
        }
    }
    public void _Disable8sPlace()
    {
        if(boolArray[4] == true)
        {
            boolArray[4] = false;
            ConvertBoolArrayToByte();
        }
    }
    public void _Enable16sPlace()
    {
        if(boolArray[3] == false)
        {
            boolArray[3] = true; //16
            ConvertBoolArrayToByte();
        }
    }
    public void _Disable16sPlace()
    {
        if(boolArray[3] == true)
        {
            boolArray[3] = false;
            ConvertBoolArrayToByte();
        }
    }
    public void _Enable32sPlace()
    {
        if(boolArray[2] == false)
        {
            boolArray[2] = true; //32
            ConvertBoolArrayToByte();
        }
    }
    public void _Disable32sPlace()
    {
        if(boolArray[2] == true)
        {
            boolArray[2] = false;
            ConvertBoolArrayToByte();
        }
    }
    public void _Enable64sPlace()
    {
        if(boolArray[1] == false)
        {
            boolArray[1] = true; //64
            ConvertBoolArrayToByte();
        }
    }
    public void _Disable64sPlace()
    {
        if(boolArray[1] == true)
        {
            boolArray[1] = false;
            ConvertBoolArrayToByte();
        }
    }
    public void _Enable128sPlace()
    {
        if(boolArray[0] == false)
        {
            boolArray[0] = true; //128
            ConvertBoolArrayToByte();
        }
    }
    public void _Disable128sPlace()
    {
        if(boolArray[0] == true)
        {
            boolArray[0] = false;
            ConvertBoolArrayToByte();
        }
    }
    private void _SendCustomFunction()
    {
        if(sendCustomFunction && targetBehaviour != null && targetFunction != "")
        {
            targetBehaviour.SendCustomEvent(targetFunction);
        }
    }

    private void ConvertBoolArrayToByte()
    {
        byte result = 0;
        // This assumes the array never contains more than 8 elements!
        int index = 8 - boolArray.Length;

        // Loop through the array
        foreach (bool b in boolArray)
        {
            // if the element is 'true' set the bit at that position
            if (b)
                result |= (byte)(1 << (7 - index));

            index++;
        }
        string r = result.ToString();
        currentValue = int.Parse(r);
        //Debug.Log("Current Value: " + currentValue);
        textDisplay.text = currentValue.ToString();
        _SendCustomFunction();
        //return currentValue;
    }   
}
}