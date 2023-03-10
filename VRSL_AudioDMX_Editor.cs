using UnityEngine;
using UnityEditor;
using VRC.SDKBase;
using VRC.Udon;
using UdonSharp;
namespace VRSL.EditorScripts
{
//[ExecuteInEditMode]

#if !COMPILER_UDONSHARP && UNITY_EDITOR
[RequireComponent(typeof(AudioSource))]
public class VRSL_AudioDMX_Editor : MonoBehaviour
{
    [HideInInspector]
    public int editorDeviceID;
    [HideInInspector]
    public int audioChannel = 0;
    public AudioSource source;
    //[HideInInspector]
    public string[] devices;
    public float preCountWaitTime1 = 0.25f;
    public float preCountWaitTime2 = 0.25f;
    public float preCountWaitTime3 = 0.25f;
    public float preCountWaitTime4 = 0.25f;
    public float preCountWaitTime5 = 0.25f;
    public float preCountWaitTime6 = 0.25f;
    public float preCountWaitTime7 = 0.25f;
    public float preCountWaitTime8 = 0.25f;
    public float preCountWaitTime9 = 0.25f;
    public float preCountWaitTime10 = 0.25f;
    public float preCountWaitTime11 = 0.25f;
    public float preCountWaitTime12 = 0.25f;
    public float[] data;
    [Range(1.0f, 5.0f)]
    public float multiplier = 1.0f;
    // public float[] Data
    // {
    //     get {return data;}
    // }
    //int[] targetElements = {29, 32, 35, 37, 40, 43, 45, 48};
    int[] targetElements = {56, 59, 61, 64, 67, 69, 72, 75};
    //int[] twelveBitTargetElements = {16, 19, 21, 24, 27, 29, 32, 35, 37, 40, 43, 45, 48, 51, 53, 56};
    int[] twelveBitTargetElements = {45, 48, 51, 53, 56, 59, 61, 64, 67, 69, 72, 75};
    [HideInInspector]
    public bool dmx1, dmx2, dmx3, dmx4, dmx5, dmx6, dmx7, dmx8, dmx9, dmx10, dmx11, dmx12,dmx13, dmx14, dmx15, dmx16;
    float currentTime;
    float previousAudioValue1, previousAudioValue2, previousAudioValue3, previousAudioValue4, previousAudioValue5, previousAudioValue6, previousAudioValue7, previousAudioValue8, previousAudioValue9,
    previousAudioValue10, previousAudioValue11, previousAudioValue12, previousAudioValue13, previousAudioValue14, previousAudioValue15, previousAudioValue16;
    public bool twelveBitMode;
    public bool showRawData;
    [Range(0.01f, 0.1f)]
    public float updateRate = 0.05f;
    [Range(0.001f, 20.0f)]
    public float threshold = 12.0f;

   // [Header("DMX Channel 1")]
    [ReadOnlyBool("CURRENT STATE: ")]
    public bool dmxBool1;
    [ReadOnlyFloat("CURRENT VALUE: ")]
    public float audioValue1;
    public UdonSharpBehaviour entryBehaviour1;
    public string entryFunction1;
    public UdonSharpBehaviour exitBehaviour1;
    public string exitFunction1;
    public bool entryFunctionSpamming1, exitFunctionSpamming1;

    //[Header("DMX Channel 2")]
    [ReadOnlyBool("CURRENT STATE: ")]
    public bool dmxBool2;
    [ReadOnlyFloat("CURRENT VALUE: ")]
    public float audioValue2;
    public UdonSharpBehaviour entryBehaviour2;
    public string entryFunction2;
    public UdonSharpBehaviour exitBehaviour2;
    public string exitFunction2;
    public bool entryFunctionSpamming2, exitFunctionSpamming2;

   // [Header("DMX Channel 3")]
    [ReadOnlyBool("CURRENT STATE: ")]
    public bool dmxBool3;
    [ReadOnlyFloat("CURRENT VALUE: ")]
    public float audioValue3;
    public UdonSharpBehaviour entryBehaviour3;
    public string entryFunction3;
    public UdonSharpBehaviour exitBehaviour3;
    public string exitFunction3;
    public bool entryFunctionSpamming3, exitFunctionSpamming3;

   // [Header("DMX Channel 4")]
    [ReadOnlyBool("CURRENT STATE: ")]
    public bool dmxBool4;
    [ReadOnlyFloat("CURRENT VALUE: ")]
    public float audioValue4;
    public UdonSharpBehaviour entryBehaviour4;
    public string entryFunction4;
    //public bool useExitFunction4;
    public UdonSharpBehaviour exitBehaviour4;
    public string exitFunction4;
    public bool entryFunctionSpamming4, exitFunctionSpamming4;

  //  [Header("DMX Channel 5")]
    [ReadOnlyBool("CURRENT STATE: ")]
    public bool dmxBool5;
    [ReadOnlyFloat("CURRENT VALUE: ")]
    public float audioValue5;
    public UdonSharpBehaviour entryBehaviour5;
    public string entryFunction5;
    public UdonSharpBehaviour exitBehaviour5;
    public string exitFunction5;
    public bool entryFunctionSpamming5, exitFunctionSpamming5;

   // [Header("DMX Channel 6")]
    [ReadOnlyBool("CURRENT STATE: ")]
    public bool dmxBool6;
    [ReadOnlyFloat("CURRENT VALUE: ")]
    public float audioValue6;
    public UdonSharpBehaviour entryBehaviour6;
    public string entryFunction6;
    public UdonSharpBehaviour exitBehaviour6;
    public string exitFunction6;
    public bool entryFunctionSpamming6, exitFunctionSpamming6;

   // [Header("DMX Channel 7")]
    [ReadOnlyBool("CURRENT STATE: ")]
    public bool dmxBool7;
    [ReadOnlyFloat("CURRENT VALUE: ")]
    public float audioValue7;
    public UdonSharpBehaviour entryBehaviour7;
    public string entryFunction7;
    public UdonSharpBehaviour exitBehaviour7;
    public string exitFunction7;
    public bool entryFunctionSpamming7, exitFunctionSpamming7;

   // [Header("DMX Channel 8")]
    [ReadOnlyBool("CURRENT STATE: ")]
    public bool dmxBool8;
    [ReadOnlyFloat("CURRENT VALUE: ")]
    public float audioValue8;
    public UdonSharpBehaviour entryBehaviour8;
    public string entryFunction8;
    public UdonSharpBehaviour exitBehaviour8;
    public string exitFunction8;
    public bool entryFunctionSpamming8, exitFunctionSpamming8;

   // [Header("DMX Channel 9")]
    [ReadOnlyBool("CURRENT STATE: ")]
    public bool dmxBool9;
    [ReadOnlyFloat("CURRENT VALUE: ")]
    public float audioValue9;
    public UdonSharpBehaviour entryBehaviour9;
    public string entryFunction9;
    public UdonSharpBehaviour exitBehaviour9;
    public string exitFunction9;
    public bool entryFunctionSpamming9, exitFunctionSpamming9;

   // [Header("DMX Channel 10")]
    [ReadOnlyBool("CURRENT STATE: ")]
    public bool dmxBool10;
    [ReadOnlyFloat("CURRENT VALUE: ")]
    public float audioValue10;
    public UdonSharpBehaviour entryBehaviour10;
    public string entryFunction10;
    public UdonSharpBehaviour exitBehaviour10;
    public string exitFunction10;
    public bool entryFunctionSpamming10, exitFunctionSpamming10;

   // [Header("DMX Channel 11")]
    [ReadOnlyBool("CURRENT STATE: ")]
    public bool dmxBool11;
    [ReadOnlyFloat("CURRENT VALUE: ")]
    public float audioValue11;
    public UdonSharpBehaviour entryBehaviour11;
    public string entryFunction11;
    public UdonSharpBehaviour exitBehaviour11;
    public string exitFunction11;
    public bool entryFunctionSpamming11, exitFunctionSpamming11;

   // [Header("DMX Channel 12")]
    [ReadOnlyBool("CURRENT STATE: ")]
    public bool dmxBool12;
    [ReadOnlyFloat("CURRENT VALUE: ")]
    public float audioValue12;
    public UdonSharpBehaviour entryBehaviour12;
    public string entryFunction12;
    //public bool useExitFunction12;
    public UdonSharpBehaviour exitBehaviour12;
    public string exitFunction12;
    public bool entryFunctionSpamming12, exitFunctionSpamming12;

   // [Header("DMX Channel 13")]
    [ReadOnlyBool("CURRENT STATE: ")]
    public bool dmxBool13;
    [ReadOnlyFloat("CURRENT VALUE: ")]
    public float audioValue13;
    public UdonSharpBehaviour entryBehaviour13;
    public string entryFunction13;
    public UdonSharpBehaviour exitBehaviour13;
    public string exitFunction13;
    public bool entryFunctionSpamming13, exitFunctionSpamming13;

  //  [Header("DMX Channel 14")]
    [ReadOnlyBool("CURRENT STATE: ")]
    public bool dmxBool14;
    [ReadOnlyFloat("CURRENT VALUE: ")]
    public float audioValue14;
    public UdonSharpBehaviour entryBehaviour14;
    public string entryFunction14;
    public UdonSharpBehaviour exitBehaviour14;
    public string exitFunction14;
    public bool entryFunctionSpamming14, exitFunctionSpamming14;

   // [Header("DMX Channel 15")]
    [ReadOnlyBool("CURRENT STATE: ")]
    public bool dmxBool15;
    [ReadOnlyFloat("CURRENT VALUE: ")]
    public float audioValue15;
    public UdonSharpBehaviour entryBehaviour15;
    public string entryFunction15;
    public UdonSharpBehaviour exitBehaviour15;
    public string exitFunction15;
    public bool entryFunctionSpamming15, exitFunctionSpamming15;

   // [Header("DMX Channel 16")]
    [ReadOnlyBool("CURRENT STATE: ")]
    public bool dmxBool16;
    [ReadOnlyFloat("CURRENT VALUE: ")]
    public float audioValue16;
    public UdonSharpBehaviour entryBehaviour16;
    public string entryFunction16;
    public UdonSharpBehaviour exitBehaviour16;
    public string exitFunction16;
    public bool entryFunctionSpamming16, exitFunctionSpamming16;

    private bool preCheck1,preCheck2, preCheck3, preCheck4, preCheck5, preCheck6, preCheck7, preCheck8, preCheck9, preCheck10, preCheck11, preCheck12;
    private float preCount1, preCount2, preCount3, preCount4, preCount5, preCount6, preCount7, preCount8, preCount9, preCount10, preCount11, preCount12;


    
    // Start is called before the first frame update
    // Start recording with built-in Microphone and play the recorded audio right away
    void Start()
    {
        currentTime = 0.0f;
        previousAudioValue1 = audioValue1;
        previousAudioValue2 = audioValue2;
        previousAudioValue3 = audioValue3;
        previousAudioValue4 = audioValue4;
        previousAudioValue5 = audioValue5;
        previousAudioValue6 = audioValue6;
        previousAudioValue7 = audioValue7;
        previousAudioValue8 = audioValue8;
        previousAudioValue9 = audioValue9;
        previousAudioValue10 = audioValue10;
        previousAudioValue11 = audioValue11;
        previousAudioValue12 = audioValue12;
        // previousAudioValue13 = audioValue13;
        // previousAudioValue14 = audioValue14;
        // previousAudioValue15 = audioValue15;
        // previousAudioValue16 = audioValue16;
        if(source == null)
            source = GetComponent<AudioSource>();
        source.loop = true;
        source.spatialBlend = 0.0f;
        source.priority = 20;
         source.volume = 0.0005f;
        devices = Microphone.devices;
        Debug.Log("Current Device: " + devices[editorDeviceID]);
        source.clip = Microphone.Start(devices[editorDeviceID], true, 10, 44100);
        source.Play();
    }

    public void _PopulateDevices()
    {
        devices = Microphone.devices;
    }

 

    void CheckAudioDMX(int targetElement, ref float audioValue, float previousAudioValue, ref bool dmxBool, string entryFunction, UdonSharpBehaviour entryBehaviour, string exitFunction, UdonSharpBehaviour exitBehaviour, int index, ref bool preCheck, ref float preCount, float preCountWaitTime, ref bool entryFuncSpam, ref bool exitFuncSpam)
    {
        data[targetElement] *= 1000000.0f;
        data[targetElement] *= multiplier; 
        int uppertarget = 35;

        // if(targetElement > 25)
        //     data[targetElement] += (targetElement * 0.01f);

        if(targetElement > uppertarget)
            data[targetElement] *= 2.0f;

        if(twelveBitMode && targetElement > 68)
        {
            data[targetElement] *= 1.25f;
        }

        // if(targetElement >= 45 && twelveBitMode)
        //     data[targetElement] += (targetElement * 0.01f);

        data[targetElement] = Mathf.Round(data[targetElement] * 100f) / 100f; //round to 2 decimal places

        if(data[targetElement] > threshold == false) // default to 0 if below threshold
            data[targetElement] = 0.0f;

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // audioValue = data[targetElement];

        // if(audioValue > 1.0f)
        // {
        //     if(entryBehaviour != null && entryFunction != "")
        //         entryBehaviour.SendCustomEvent(entryFunction);

        //     dmxBool = true;
        // }
        // if(audioValue == 0.0f)
        // {
        //     if(exitBehaviour != null && exitFunction != "" )
        //         exitBehaviour.SendCustomEvent(exitFunction);

        //     dmxBool = false;
        // }
        // previousAudioValue = audioValue;

        audioValue = data[targetElement];

        if(audioValue > 1.0f)
        {
            preCheck = false;
            if(entryBehaviour != null && entryFunction != "")
            {// && dmxBool != true
                if(entryFuncSpam)
                {
                    entryBehaviour.SendCustomEvent(entryFunction);
                }
                else if(dmxBool != true)
                {
                    entryBehaviour.SendCustomEvent(entryFunction);
                }
            }

            dmxBool = true;
           // dmxBoolTexts[index-1].color = Color.green;
        }
        if(audioValue == 0.0f)
        {
            preCheck = true;
            if(preCount >= preCountWaitTime )
            {
                if(exitBehaviour != null && exitFunction != "")
                {
                    if(exitFuncSpam)
                    {
                        exitBehaviour.SendCustomEvent(exitFunction);
                    }
                    else if(dmxBool != false)
                    {
                        exitBehaviour.SendCustomEvent(exitFunction);
                    }
                }
                dmxBool = false;
                //dmxBoolTexts[index-1].color = Color.red;
            }
        }
        previousAudioValue = audioValue;
       // dmxBoolTexts[index-1].text = dmxBool.ToString().ToUpper();
       // dmxValueTexts[index-1].text = audioValue.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime >= updateRate)
        {
            data = new float[128];
            source.GetSpectrumData(data, 0, FFTWindow.Rectangular);
            // for(int i = 0; i < data.Length; i++)
            // {
            //     data[i]*= 1000000.0f; 
            //     if(i >= 35) 
            //     {
            //         data[i] *= 2.0f;
            //     } 
            //      data[i] = Mathf.Round(data[i] * 100f) / 100f;
            //     data[i] = data[i] < threshold ? 0.0f : data[i];
            // }
           //|| ArrayUtility.Contains<int>(twelveBitTargetElements, i) == false   





                //I get paid per line (jk i wish)
                //unrolling loops is faster in udon than having a regular for loop
                //yes i know its cursed
                //yes i know this created way more variables than neccessary
                //yes i hate this too
                //accept our pain and be thankful its only 12
            if(twelveBitMode)
            {
                CheckAudioDMX(twelveBitTargetElements[0], ref audioValue1, previousAudioValue1, ref dmxBool1, entryFunction1, entryBehaviour1, exitFunction1, exitBehaviour1, 1, ref preCheck1, ref preCount1, preCountWaitTime1, ref entryFunctionSpamming1, ref exitFunctionSpamming1);
                CheckAudioDMX(twelveBitTargetElements[1], ref audioValue2, previousAudioValue2, ref dmxBool2, entryFunction2, entryBehaviour2, exitFunction2, exitBehaviour2, 2, ref preCheck2, ref preCount2, preCountWaitTime2, ref entryFunctionSpamming2, ref exitFunctionSpamming2);
                CheckAudioDMX(twelveBitTargetElements[2], ref audioValue3, previousAudioValue3, ref dmxBool3, entryFunction3, entryBehaviour3, exitFunction3, exitBehaviour3, 3, ref preCheck3, ref preCount3, preCountWaitTime3, ref entryFunctionSpamming3, ref exitFunctionSpamming3);
                CheckAudioDMX(twelveBitTargetElements[3], ref audioValue4, previousAudioValue4, ref dmxBool4, entryFunction4, entryBehaviour4, exitFunction4, exitBehaviour4, 4, ref preCheck4, ref preCount4, preCountWaitTime4, ref entryFunctionSpamming4, ref exitFunctionSpamming4);
                CheckAudioDMX(twelveBitTargetElements[4], ref audioValue5, previousAudioValue5, ref dmxBool5, entryFunction5, entryBehaviour5, exitFunction5, exitBehaviour5, 5, ref preCheck5, ref preCount5, preCountWaitTime5, ref entryFunctionSpamming5, ref exitFunctionSpamming5);
                CheckAudioDMX(twelveBitTargetElements[5], ref audioValue6, previousAudioValue6, ref dmxBool6, entryFunction6, entryBehaviour6, exitFunction6, exitBehaviour6, 6, ref preCheck6, ref preCount6, preCountWaitTime6, ref entryFunctionSpamming6, ref exitFunctionSpamming6);
                CheckAudioDMX(twelveBitTargetElements[6], ref audioValue7, previousAudioValue7, ref dmxBool7, entryFunction7, entryBehaviour7, exitFunction7, exitBehaviour7, 7, ref preCheck7, ref preCount7, preCountWaitTime7, ref entryFunctionSpamming7, ref exitFunctionSpamming7);
                CheckAudioDMX(twelveBitTargetElements[7], ref audioValue8, previousAudioValue8, ref dmxBool8, entryFunction8, entryBehaviour8, exitFunction8, exitBehaviour8, 8, ref preCheck8, ref preCount8, preCountWaitTime8, ref entryFunctionSpamming8, ref exitFunctionSpamming8);
                CheckAudioDMX(twelveBitTargetElements[8], ref audioValue9, previousAudioValue9, ref dmxBool9, entryFunction9, entryBehaviour9, exitFunction9, exitBehaviour9, 9, ref preCheck9, ref preCount9, preCountWaitTime9, ref entryFunctionSpamming9, ref exitFunctionSpamming9);
                CheckAudioDMX(twelveBitTargetElements[9], ref audioValue10, previousAudioValue7, ref dmxBool10, entryFunction10, entryBehaviour10, exitFunction10, exitBehaviour10, 10, ref preCheck10, ref preCount10, preCountWaitTime10, ref entryFunctionSpamming10, ref exitFunctionSpamming10);
                CheckAudioDMX(twelveBitTargetElements[10], ref audioValue11, previousAudioValue9, ref dmxBool11, entryFunction11, entryBehaviour11, exitFunction11, exitBehaviour11, 11, ref preCheck11, ref preCount11, preCountWaitTime11, ref entryFunctionSpamming11, ref exitFunctionSpamming11);
                CheckAudioDMX(twelveBitTargetElements[11], ref audioValue12, previousAudioValue10, ref dmxBool12, entryFunction12, entryBehaviour12, exitFunction12, exitBehaviour12, 12, ref preCheck12, ref preCount12, preCountWaitTime12, ref entryFunctionSpamming12, ref exitFunctionSpamming12);
                preCount1 = preCheck1 && preCount1 < preCountWaitTime1 ?  preCount1 + Time.deltaTime : 0.0f;
                preCount2 = preCheck2 && preCount2 < preCountWaitTime2 ?  preCount2 + Time.deltaTime : 0.0f;
                preCount3 = preCheck3 && preCount3 < preCountWaitTime3 ?  preCount3 + Time.deltaTime : 0.0f;
                preCount4 = preCheck4 && preCount4 < preCountWaitTime4 ?  preCount4 + Time.deltaTime : 0.0f;
                preCount5 = preCheck5 && preCount5 < preCountWaitTime5 ?  preCount5 + Time.deltaTime : 0.0f;
                preCount6 = preCheck6 && preCount6 < preCountWaitTime6 ?  preCount6 + Time.deltaTime : 0.0f;
                preCount7 = preCheck7 && preCount7 < preCountWaitTime7 ?  preCount7 + Time.deltaTime : 0.0f;
                preCount8 = preCheck8 && preCount8 < preCountWaitTime8 ?  preCount8 + Time.deltaTime : 0.0f;
                preCount9 = preCheck9 && preCount9 < preCountWaitTime9 ?  preCount9 + Time.deltaTime : 0.0f;
                preCount10 = preCheck10 && preCount10 < preCountWaitTime10 ?  preCount10 + Time.deltaTime : 0.0f;
                preCount11 = preCheck11 && preCount11 < preCountWaitTime11 ?  preCount11 + Time.deltaTime : 0.0f;
                preCount12 = preCheck12 && preCount12 < preCountWaitTime12 ?  preCount12 + Time.deltaTime : 0.0f;       


            }
            else
            {
                CheckAudioDMX(targetElements[0], ref audioValue1, previousAudioValue1, ref dmxBool1, entryFunction1, entryBehaviour1, exitFunction1, exitBehaviour1, 1, ref preCheck1, ref preCount1, preCountWaitTime1, ref entryFunctionSpamming1, ref exitFunctionSpamming1);
                CheckAudioDMX(targetElements[1], ref audioValue2, previousAudioValue2, ref dmxBool2, entryFunction2, entryBehaviour2, exitFunction2, exitBehaviour2, 2, ref preCheck2, ref preCount2, preCountWaitTime2, ref entryFunctionSpamming2, ref exitFunctionSpamming2);
                CheckAudioDMX(targetElements[2], ref audioValue3, previousAudioValue3, ref dmxBool3, entryFunction3, entryBehaviour3, exitFunction3, exitBehaviour3, 3, ref preCheck3, ref preCount3, preCountWaitTime3, ref entryFunctionSpamming3, ref exitFunctionSpamming3);
                CheckAudioDMX(targetElements[3], ref audioValue4, previousAudioValue4, ref dmxBool4, entryFunction4, entryBehaviour4, exitFunction4, exitBehaviour4, 4, ref preCheck4, ref preCount4, preCountWaitTime4, ref entryFunctionSpamming4, ref exitFunctionSpamming4);
                CheckAudioDMX(targetElements[4], ref audioValue5, previousAudioValue5, ref dmxBool5, entryFunction5, entryBehaviour5, exitFunction5, exitBehaviour5, 5, ref preCheck5, ref preCount5, preCountWaitTime5, ref entryFunctionSpamming5, ref exitFunctionSpamming5);
                CheckAudioDMX(targetElements[5], ref audioValue6, previousAudioValue6, ref dmxBool6, entryFunction6, entryBehaviour6, exitFunction6, exitBehaviour6, 6, ref preCheck6, ref preCount6, preCountWaitTime6, ref entryFunctionSpamming6, ref exitFunctionSpamming6);
                CheckAudioDMX(targetElements[6], ref audioValue7, previousAudioValue7, ref dmxBool7, entryFunction7, entryBehaviour7, exitFunction7, exitBehaviour7, 7, ref preCheck7, ref preCount7, preCountWaitTime7, ref entryFunctionSpamming7, ref exitFunctionSpamming7);
                CheckAudioDMX(targetElements[7], ref audioValue8, previousAudioValue8, ref dmxBool8, entryFunction8, entryBehaviour8, exitFunction8, exitBehaviour8, 8, ref preCheck8, ref preCount8, preCountWaitTime8, ref entryFunctionSpamming8, ref exitFunctionSpamming8);
                preCount1 = preCheck1 && preCount1 < preCountWaitTime1 ?  preCount1 + Time.deltaTime : 0.0f;
                preCount2 = preCheck2 && preCount2 < preCountWaitTime2 ?  preCount2 + Time.deltaTime : 0.0f;
                preCount3 = preCheck3 && preCount3 < preCountWaitTime3 ?  preCount3 + Time.deltaTime : 0.0f;
                preCount4 = preCheck4 && preCount4 < preCountWaitTime4 ?  preCount4 + Time.deltaTime : 0.0f;
                preCount5 = preCheck5 && preCount5 < preCountWaitTime5 ?  preCount5 + Time.deltaTime : 0.0f;
                preCount6 = preCheck6 && preCount6 < preCountWaitTime6 ?  preCount6 + Time.deltaTime : 0.0f;
                preCount7 = preCheck7 && preCount7 < preCountWaitTime7 ?  preCount7 + Time.deltaTime : 0.0f;
                preCount8 = preCheck8 && preCount8 < preCountWaitTime8 ?  preCount8 + Time.deltaTime : 0.0f; 
            }
            currentTime = 0.0f;
            
        }
    }
}
#if UNITY_EDITOR
    public class BoolStyle
    {
        public static GUIStyle trueStyle = new GUIStyle
            {
                normal = new GUIStyleState
                {
                    textColor = Color.green
                },
                fontStyle = FontStyle.Bold
            }; 
        public static GUIStyle falseStyle = new GUIStyle
            {
                normal = new GUIStyleState
                {
                    textColor = Color.red
                },
                fontStyle = FontStyle.Bold
            };
        public static GUIStyle labelStyle = new GUIStyle(EditorStyles.foldoutHeader)
            {
                normal = new GUIStyleState
                {
                    textColor = Color.white,
                },
               // fontStyle = FontStyle.Bold,
                alignment = TextAnchor.MiddleCenter,
                fontSize = 13,
                fixedHeight = 24.0f
            };
    }

    public class ReadOnlyBool : PropertyAttribute
    {
        public string label;

        public ReadOnlyBool(string label)
        {
            this.label = label;
        }
    }
    [CustomPropertyDrawer(typeof(ReadOnlyBool))]
    public class ReadOnlyBoolDrawer : PropertyDrawer
    {


        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            ReadOnlyBool readOnlyBoolAttribute = (ReadOnlyBool)attribute;
            GUIStyle style = property.boolValue ? BoolStyle.trueStyle : BoolStyle.falseStyle;
            EditorGUI.LabelField(position, readOnlyBoolAttribute.label, property.boolValue.ToString().ToUpper(), style);
        }
    }

    public class ReadOnlyFloat : PropertyAttribute
    {
        public string label;

        public ReadOnlyFloat(string label)
        {
            this.label = label;
        }
    }
    [CustomPropertyDrawer(typeof(ReadOnlyFloat))]
    public class ReadOnlyFloatDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            ReadOnlyFloat readOnlyBoolAttribute = (ReadOnlyFloat)attribute;
            EditorGUI.LabelField(position, readOnlyBoolAttribute.label, property.floatValue.ToString());
        }
    }
    [CustomEditor(typeof(VRSL_AudioDMX_Editor))]
    public class VRSL_AudioDMX_Inspector : Editor
    {

    #if !COMPILER_UDONSHARP && UNITY_EDITOR
    public void _CopyEditorReferences()
    {
        VRSL.VRSL_AudioDMX e = Resources.FindObjectsOfTypeAll<VRSL.VRSL_AudioDMX>()[0];
        m_entryBehaviour1.objectReferenceValue = e.entryBehaviour1;
        m_entryFunction1.stringValue = e.entryFunction1;
        m_exitBehaviour1.objectReferenceValue = e.exitBehaviour1;
        m_exitFunction1.stringValue = e.exitFunction1;
        m_entryFunctionSpamming1.boolValue = e.entryFunctionSpamming1;
        m_exitFunctionSpamming1.boolValue = e.exitFunctionSpamming1;
        m_preCountWaitTime1.floatValue = e.preCountWaitTime1;


        m_entryBehaviour2.objectReferenceValue = e.entryBehaviour2;
        m_entryFunction2.stringValue = e.entryFunction2;
        m_exitBehaviour2.objectReferenceValue = e.exitBehaviour2;
        m_exitFunction2.stringValue = e.exitFunction2;
        m_entryFunctionSpamming2.boolValue = e.entryFunctionSpamming2;
        m_exitFunctionSpamming2.boolValue = e.exitFunctionSpamming2;
        m_preCountWaitTime2.floatValue = e.preCountWaitTime2;

        m_entryBehaviour3.objectReferenceValue = e.entryBehaviour3;
        m_entryFunction3.stringValue = e.entryFunction3;
        m_exitBehaviour3.objectReferenceValue = e.exitBehaviour3;
        m_exitFunction3.stringValue = e.exitFunction3;
        m_entryFunctionSpamming3.boolValue = e.entryFunctionSpamming3;
        m_exitFunctionSpamming3.boolValue = e.exitFunctionSpamming3;
        m_preCountWaitTime3.floatValue = e.preCountWaitTime3;

        m_entryBehaviour4.objectReferenceValue = e.entryBehaviour4;
        m_entryFunction4.stringValue = e.entryFunction4;
        m_exitBehaviour4.objectReferenceValue = e.exitBehaviour4;
        m_exitFunction4.stringValue = e.exitFunction4;
        m_entryFunctionSpamming4.boolValue = e.entryFunctionSpamming4;
        m_exitFunctionSpamming4.boolValue = e.exitFunctionSpamming4;
        m_preCountWaitTime4.floatValue = e.preCountWaitTime4;

        m_entryBehaviour5.objectReferenceValue = e.entryBehaviour5;
        m_entryFunction5.stringValue = e.entryFunction5;
        m_exitBehaviour5.objectReferenceValue = e.exitBehaviour5;
        m_exitFunction5.stringValue = e.exitFunction5;
        m_entryFunctionSpamming5.boolValue = e.entryFunctionSpamming5;
        m_exitFunctionSpamming5.boolValue = e.exitFunctionSpamming5;
        m_preCountWaitTime5.floatValue = e.preCountWaitTime5;

        m_entryBehaviour6.objectReferenceValue = e.entryBehaviour6;
        m_entryFunction6.stringValue = e.entryFunction6;
        m_exitBehaviour6.objectReferenceValue = e.exitBehaviour6;
        m_exitFunction6.stringValue = e.exitFunction6;
        m_entryFunctionSpamming6.boolValue = e.entryFunctionSpamming6;
        m_exitFunctionSpamming6.boolValue = e.exitFunctionSpamming6;
        m_preCountWaitTime6.floatValue = e.preCountWaitTime6;

        m_entryBehaviour7.objectReferenceValue = e.entryBehaviour7;
        m_entryFunction7.stringValue = e.entryFunction7;
        m_exitBehaviour7.objectReferenceValue = e.exitBehaviour7;
        m_exitFunction7.stringValue = e.exitFunction7;
        m_entryFunctionSpamming7.boolValue = e.entryFunctionSpamming7;
        m_exitFunctionSpamming7.boolValue = e.exitFunctionSpamming7;
        m_preCountWaitTime7.floatValue = e.preCountWaitTime7;

        m_entryBehaviour8.objectReferenceValue = e.entryBehaviour8;
        m_entryFunction8.stringValue = e.entryFunction8;
        m_exitBehaviour8.objectReferenceValue = e.exitBehaviour8;
        m_exitFunction8.stringValue = e.exitFunction8;
        m_entryFunctionSpamming8.boolValue = e.entryFunctionSpamming8;
        m_exitFunctionSpamming8.boolValue = e.exitFunctionSpamming8; 
        m_preCountWaitTime8.floatValue = e.preCountWaitTime8;

        m_entryBehaviour9.objectReferenceValue = e.entryBehaviour9;
        m_entryFunction9.stringValue = e.entryFunction9;
        m_exitBehaviour9.objectReferenceValue = e.exitBehaviour9;
        m_exitFunction9.stringValue = e.exitFunction9;
        m_entryFunctionSpamming9.boolValue = e.entryFunctionSpamming9;
        m_exitFunctionSpamming9.boolValue = e.exitFunctionSpamming9; 
        m_preCountWaitTime9.floatValue = e.preCountWaitTime9;

        m_entryBehaviour10.objectReferenceValue = e.entryBehaviour10;
        m_entryFunction10.stringValue = e.entryFunction10;
        m_exitBehaviour10.objectReferenceValue = e.exitBehaviour10;
        m_exitFunction10.stringValue = e.exitFunction10;
        m_entryFunctionSpamming10.boolValue = e.entryFunctionSpamming10;
        m_exitFunctionSpamming10.boolValue = e.exitFunctionSpamming10; 
        m_preCountWaitTime10.floatValue = e.preCountWaitTime10;
        

        m_entryBehaviour11.objectReferenceValue = e.entryBehaviour11;
        m_entryFunction11.stringValue = e.entryFunction11;
        m_exitBehaviour11.objectReferenceValue = e.exitBehaviour11;
        m_exitFunction11.stringValue = e.exitFunction11;
        m_entryFunctionSpamming11.boolValue = e.entryFunctionSpamming11;
        m_exitFunctionSpamming11.boolValue = e.exitFunctionSpamming11; 
        m_preCountWaitTime11.floatValue = e.preCountWaitTime11;


        m_entryBehaviour12.objectReferenceValue = e.entryBehaviour12;
        m_entryFunction12.stringValue = e.entryFunction12;
        m_exitBehaviour12.objectReferenceValue = e.exitBehaviour12;
        m_exitFunction12.stringValue = e.exitFunction12;
        m_entryFunctionSpamming12.boolValue = e.entryFunctionSpamming12;
        m_exitFunctionSpamming12.boolValue = e.exitFunctionSpamming12; 
        m_preCountWaitTime12.floatValue = e.preCountWaitTime12;
        serializedObject.ApplyModifiedProperties();
    }
    #endif
        public static Texture logo;
        private static void LoadLogo()
        {
            logo = Resources.Load("VRStageLighting-Logo") as Texture;
        }
        SerializedProperty m_source, m_twelveBitMode, m_updateRate, m_threshold, m_showRawData, m_data, m_preCountWaitTime, m_editorDeviceID, m_devices, m_multiplier;
        SerializedProperty m_dmxBool1, m_audioValue1, m_entryBehaviour1, m_entryFunction1, m_exitBehaviour1, m_exitFunction1;
        SerializedProperty m_dmxBool2, m_audioValue2, m_entryBehaviour2, m_entryFunction2, m_exitBehaviour2, m_exitFunction2;
        SerializedProperty m_dmxBool3, m_audioValue3, m_entryBehaviour3, m_entryFunction3, m_exitBehaviour3, m_exitFunction3;
        SerializedProperty m_dmxBool4, m_audioValue4, m_entryBehaviour4, m_entryFunction4, m_exitBehaviour4, m_exitFunction4;
        SerializedProperty m_dmxBool5, m_audioValue5, m_entryBehaviour5, m_entryFunction5, m_exitBehaviour5, m_exitFunction5;
        SerializedProperty m_dmxBool6, m_audioValue6, m_entryBehaviour6, m_entryFunction6, m_exitBehaviour6, m_exitFunction6;
        SerializedProperty m_dmxBool7, m_audioValue7, m_entryBehaviour7, m_entryFunction7, m_exitBehaviour7, m_exitFunction7;
        SerializedProperty m_dmxBool8, m_audioValue8, m_entryBehaviour8, m_entryFunction8, m_exitBehaviour8, m_exitFunction8;
        SerializedProperty m_dmxBool9, m_audioValue9, m_entryBehaviour9, m_entryFunction9, m_exitBehaviour9, m_exitFunction9;
        SerializedProperty m_dmxBool10, m_audioValue10, m_entryBehaviour10, m_entryFunction10, m_exitBehaviour10, m_exitFunction10;
        SerializedProperty m_dmxBool11, m_audioValue11, m_entryBehaviour11, m_entryFunction11, m_exitBehaviour11, m_exitFunction11;
        SerializedProperty m_dmxBool12, m_audioValue12, m_entryBehaviour12, m_entryFunction12, m_exitBehaviour12, m_exitFunction12;
        SerializedProperty m_preCountWaitTime1, m_preCountWaitTime2, m_preCountWaitTime3,m_preCountWaitTime4, m_preCountWaitTime5, m_preCountWaitTime6, m_preCountWaitTime7, m_preCountWaitTime8, m_preCountWaitTime9, m_preCountWaitTime10, m_preCountWaitTime11, m_preCountWaitTime12;
        SerializedProperty m_exitFunctionSpamming1,m_exitFunctionSpamming2, m_exitFunctionSpamming3, m_exitFunctionSpamming4, m_exitFunctionSpamming5, m_exitFunctionSpamming6, m_exitFunctionSpamming7, m_exitFunctionSpamming8, m_exitFunctionSpamming9, m_exitFunctionSpamming10, m_exitFunctionSpamming11, m_exitFunctionSpamming12;
        SerializedProperty m_entryFunctionSpamming1, m_entryFunctionSpamming2, m_entryFunctionSpamming3, m_entryFunctionSpamming4, m_entryFunctionSpamming5, m_entryFunctionSpamming6, m_entryFunctionSpamming7, m_entryFunctionSpamming8, m_entryFunctionSpamming9, m_entryFunctionSpamming10, m_entryFunctionSpamming11, m_entryFunctionSpamming12;
        // SerializedProperty m_dmxBool13, m_audioValue13, m_entryBehaviour13, m_entryFunction13, m_exitBehaviour13, m_exitFunction13;
        // SerializedProperty m_dmxBool14, m_audioValue14, m_entryBehaviour14, m_entryFunction14, m_exitBehaviour14, m_exitFunction14;
        // SerializedProperty m_dmxBool15, m_audioValue15, m_entryBehaviour15, m_entryFunction15, m_exitBehaviour15, m_exitFunction15;
        // SerializedProperty m_dmxBool16, m_audioValue16, m_entryBehaviour16, m_entryFunction16, m_exitBehaviour16, m_exitFunction16;

        GUIContent PropertyLabel(string txt)
        {
            GUIContent x = new GUIContent();
            x.text = txt;
            return x;
        }

        
        Color bg = new Color(0.90f, 0.90f, 0.90f);
        VRSL_AudioDMX_Editor audioDmx;
        void OnEnable()
        {
            LoadLogo();
            m_source = serializedObject.FindProperty("source");
            m_twelveBitMode = serializedObject.FindProperty("twelveBitMode");
            m_updateRate = serializedObject.FindProperty("updateRate");
            m_threshold = serializedObject.FindProperty("threshold");
            m_showRawData = serializedObject.FindProperty("showRawData");
            m_data = serializedObject.FindProperty("data");
            m_preCountWaitTime = serializedObject.FindProperty("preCountWaitTime");
            m_editorDeviceID = serializedObject.FindProperty("editorDeviceID");
            m_devices = serializedObject.FindProperty("devices");
            m_multiplier = serializedObject.FindProperty("multiplier");

            m_dmxBool1 = serializedObject.FindProperty("dmxBool1");
            m_audioValue1 = serializedObject.FindProperty("audioValue1");
            m_entryBehaviour1 = serializedObject.FindProperty("entryBehaviour1");
            m_entryFunction1 = serializedObject.FindProperty("entryFunction1");
            m_exitBehaviour1 = serializedObject.FindProperty("exitBehaviour1");
            m_exitFunction1 = serializedObject.FindProperty("exitFunction1");


            m_dmxBool2 = serializedObject.FindProperty("dmxBool2");
            m_audioValue2 = serializedObject.FindProperty("audioValue2");
            m_entryBehaviour2 = serializedObject.FindProperty("entryBehaviour2");
            m_entryFunction2 = serializedObject.FindProperty("entryFunction2");
            m_exitBehaviour2 = serializedObject.FindProperty("exitBehaviour2");
            m_exitFunction2 = serializedObject.FindProperty("exitFunction2");

            m_dmxBool3 = serializedObject.FindProperty("dmxBool3");
            m_audioValue3 = serializedObject.FindProperty("audioValue3");
            m_entryBehaviour3 = serializedObject.FindProperty("entryBehaviour3");
            m_entryFunction3 = serializedObject.FindProperty("entryFunction3");
            m_exitBehaviour3 = serializedObject.FindProperty("exitBehaviour3");
            m_exitFunction3 = serializedObject.FindProperty("exitFunction3");

            m_dmxBool4 = serializedObject.FindProperty("dmxBool4");
            m_audioValue4 = serializedObject.FindProperty("audioValue4");
            m_entryBehaviour4 = serializedObject.FindProperty("entryBehaviour4");
            m_entryFunction4 = serializedObject.FindProperty("entryFunction4");
            m_exitBehaviour4 = serializedObject.FindProperty("exitBehaviour4");
            m_exitFunction4 = serializedObject.FindProperty("exitFunction4");

            m_dmxBool5 = serializedObject.FindProperty("dmxBool5");
            m_audioValue5 = serializedObject.FindProperty("audioValue5");
            m_entryBehaviour5 = serializedObject.FindProperty("entryBehaviour5");
            m_entryFunction5 = serializedObject.FindProperty("entryFunction5");
            m_exitBehaviour5 = serializedObject.FindProperty("exitBehaviour5");
            m_exitFunction5 = serializedObject.FindProperty("exitFunction5");

            m_dmxBool6 = serializedObject.FindProperty("dmxBool6");
            m_audioValue6 = serializedObject.FindProperty("audioValue6");
            m_entryBehaviour6 = serializedObject.FindProperty("entryBehaviour6");
            m_entryFunction6 = serializedObject.FindProperty("entryFunction6");
            m_exitBehaviour6 = serializedObject.FindProperty("exitBehaviour6");
            m_exitFunction6 = serializedObject.FindProperty("exitFunction6");

            m_dmxBool7 = serializedObject.FindProperty("dmxBool7");
            m_audioValue7 = serializedObject.FindProperty("audioValue7");
            m_entryBehaviour7 = serializedObject.FindProperty("entryBehaviour7");
            m_entryFunction7 = serializedObject.FindProperty("entryFunction7");
            m_exitBehaviour7 = serializedObject.FindProperty("exitBehaviour7");
            m_exitFunction7 = serializedObject.FindProperty("exitFunction7");

            m_dmxBool8 = serializedObject.FindProperty("dmxBool8");
            m_audioValue8 = serializedObject.FindProperty("audioValue8");
            m_entryBehaviour8 = serializedObject.FindProperty("entryBehaviour8");
            m_entryFunction8 = serializedObject.FindProperty("entryFunction8");
            m_exitBehaviour8 = serializedObject.FindProperty("exitBehaviour8");
            m_exitFunction8 = serializedObject.FindProperty("exitFunction8");

            m_dmxBool9 = serializedObject.FindProperty("dmxBool9");
            m_audioValue9 = serializedObject.FindProperty("audioValue9");
            m_entryBehaviour9 = serializedObject.FindProperty("entryBehaviour9");
            m_entryFunction9 = serializedObject.FindProperty("entryFunction9");
            m_exitBehaviour9 = serializedObject.FindProperty("exitBehaviour9");
            m_exitFunction9 = serializedObject.FindProperty("exitFunction9");

            m_dmxBool10 = serializedObject.FindProperty("dmxBool10");
            m_audioValue10 = serializedObject.FindProperty("audioValue10");
            m_entryBehaviour10 = serializedObject.FindProperty("entryBehaviour10");
            m_entryFunction10 = serializedObject.FindProperty("entryFunction10");
            m_exitBehaviour10 = serializedObject.FindProperty("exitBehaviour10");
            m_exitFunction10 = serializedObject.FindProperty("exitFunction10");

            m_dmxBool11 = serializedObject.FindProperty("dmxBool11");
            m_audioValue11 = serializedObject.FindProperty("audioValue11");
            m_entryBehaviour11 = serializedObject.FindProperty("entryBehaviour11");
            m_entryFunction11 = serializedObject.FindProperty("entryFunction11");
            m_exitBehaviour11 = serializedObject.FindProperty("exitBehaviour11");
            m_exitFunction11 = serializedObject.FindProperty("exitFunction11");

            m_dmxBool12 = serializedObject.FindProperty("dmxBool12");
            m_audioValue12 = serializedObject.FindProperty("audioValue12");
            m_entryBehaviour12 = serializedObject.FindProperty("entryBehaviour12");
            m_entryFunction12 = serializedObject.FindProperty("entryFunction12");
            m_exitBehaviour12 = serializedObject.FindProperty("exitBehaviour12");
            m_exitFunction12 = serializedObject.FindProperty("exitFunction12");

            m_preCountWaitTime1 = serializedObject.FindProperty("preCountWaitTime1");
            m_preCountWaitTime2 = serializedObject.FindProperty("preCountWaitTime2");
            m_preCountWaitTime3 = serializedObject.FindProperty("preCountWaitTime3");
            m_preCountWaitTime4 = serializedObject.FindProperty("preCountWaitTime4");
            m_preCountWaitTime5 = serializedObject.FindProperty("preCountWaitTime5");
            m_preCountWaitTime6 = serializedObject.FindProperty("preCountWaitTime6");
            m_preCountWaitTime7 = serializedObject.FindProperty("preCountWaitTime7");
            m_preCountWaitTime8 = serializedObject.FindProperty("preCountWaitTime8");
            m_preCountWaitTime9 = serializedObject.FindProperty("preCountWaitTime9");
            m_preCountWaitTime10 = serializedObject.FindProperty("preCountWaitTime10");
            m_preCountWaitTime11 = serializedObject.FindProperty("preCountWaitTime11");
            m_preCountWaitTime12 = serializedObject.FindProperty("preCountWaitTime12");

            m_exitFunctionSpamming1 = serializedObject.FindProperty("exitFunctionSpamming1");
            m_entryFunctionSpamming1 = serializedObject.FindProperty("entryFunctionSpamming1");
            m_exitFunctionSpamming2 = serializedObject.FindProperty("exitFunctionSpamming2");
            m_entryFunctionSpamming2 = serializedObject.FindProperty("entryFunctionSpamming2");
            m_exitFunctionSpamming3 = serializedObject.FindProperty("exitFunctionSpamming3");
            m_entryFunctionSpamming3 = serializedObject.FindProperty("entryFunctionSpamming3");
            m_exitFunctionSpamming4 = serializedObject.FindProperty("exitFunctionSpamming4");
            m_entryFunctionSpamming4 = serializedObject.FindProperty("entryFunctionSpamming4");
            m_exitFunctionSpamming5 = serializedObject.FindProperty("exitFunctionSpamming5");
            m_entryFunctionSpamming5 = serializedObject.FindProperty("entryFunctionSpamming5");
            m_exitFunctionSpamming6 = serializedObject.FindProperty("exitFunctionSpamming6");
            m_entryFunctionSpamming6 = serializedObject.FindProperty("entryFunctionSpamming6");
            m_exitFunctionSpamming7 = serializedObject.FindProperty("exitFunctionSpamming7");
            m_entryFunctionSpamming7 = serializedObject.FindProperty("entryFunctionSpamming7");  
            m_exitFunctionSpamming8 = serializedObject.FindProperty("exitFunctionSpamming8");
            m_entryFunctionSpamming8 = serializedObject.FindProperty("entryFunctionSpamming8");   
            m_exitFunctionSpamming9 = serializedObject.FindProperty("exitFunctionSpamming9");
            m_entryFunctionSpamming9 = serializedObject.FindProperty("entryFunctionSpamming9");  
            m_exitFunctionSpamming10 = serializedObject.FindProperty("exitFunctionSpamming10");
            m_entryFunctionSpamming10 = serializedObject.FindProperty("entryFunctionSpamming10");  
            m_exitFunctionSpamming11 = serializedObject.FindProperty("exitFunctionSpamming11");
            m_entryFunctionSpamming11 = serializedObject.FindProperty("entryFunctionSpamming11"); 
            m_exitFunctionSpamming12 = serializedObject.FindProperty("exitFunctionSpamming12");
            m_entryFunctionSpamming12 = serializedObject.FindProperty("entryFunctionSpamming12");                                                                          
            // m_dmxBool13 = serializedObject.FindProperty("dmxBool13");
            // m_audioValue13 = serializedObject.FindProperty("audioValue13");
            // m_entryBehaviour13 = serializedObject.FindProperty("entryBehaviour13");
            // m_entryFunction13 = serializedObject.FindProperty("entryFunction13");
            // m_exitBehaviour13 = serializedObject.FindProperty("exitBehaviour13");
            // m_exitFunction13 = serializedObject.FindProperty("exitFunction13");

            // m_dmxBool14 = serializedObject.FindProperty("dmxBool14");
            // m_audioValue14 = serializedObject.FindProperty("audioValue14");
            // m_entryBehaviour14 = serializedObject.FindProperty("entryBehaviour14");
            // m_entryFunction14 = serializedObject.FindProperty("entryFunction14");
            // m_exitBehaviour14 = serializedObject.FindProperty("exitBehaviour14");
            // m_exitFunction14 = serializedObject.FindProperty("exitFunction14");

            // m_dmxBool15 = serializedObject.FindProperty("dmxBool15");
            // m_audioValue15 = serializedObject.FindProperty("audioValue15");
            // m_entryBehaviour15 = serializedObject.FindProperty("entryBehaviour15");
            // m_entryFunction15 = serializedObject.FindProperty("entryFunction15");
            // m_exitBehaviour15 = serializedObject.FindProperty("exitBehaviour15");
            // m_exitFunction15 = serializedObject.FindProperty("exitFunction15");

            // m_dmxBool16 = serializedObject.FindProperty("dmxBool16");
            // m_audioValue16 = serializedObject.FindProperty("audioValue16");
            // m_entryBehaviour16 = serializedObject.FindProperty("entryBehaviour16");
            // m_entryFunction16 = serializedObject.FindProperty("entryFunction16");
            // m_exitBehaviour16 = serializedObject.FindProperty("exitBehaviour16");
            // m_exitFunction16 = serializedObject.FindProperty("exitFunction16");
        }
        public override void OnInspectorGUI()
        {
            Vector2 contentOffset = new Vector2(250f, -2f);
            GUIStyle style = new GUIStyle();
            style.fixedHeight = 100;

            style.contentOffset = contentOffset;
            //style.alignment = TextAnchor.MiddleCenter;

            var rect = GUILayoutUtility.GetRect(200f, 90f, style);
            
            GUI.Box(rect, logo,style);
            audioDmx = target as VRSL_AudioDMX_Editor;
            //audioDmx.editorDeviceID = EditorGUILayout.Popup("Target Audio Device",audioDmx.editorDeviceID, audioDmx.devices);
            //base.OnInspectorGUI();
            EditorGUILayout.PropertyField(m_source);
            EditorGUILayout.PropertyField(m_twelveBitMode);
            EditorGUILayout.PropertyField(m_updateRate);
            EditorGUILayout.PropertyField(m_threshold);

            EditorGUILayout.PropertyField(m_multiplier);
            EditorGUILayout.PropertyField(m_editorDeviceID);
            if(GUILayout.Button("Populate Device List"))
            {
                audioDmx._PopulateDevices();
            }
            EditorGUILayout.PropertyField(m_devices);
            EditorGUILayout.Space(4);
            if(GUILayout.Button("Copy Channel Settings From Game Mode Version"))
            {
                #if !COMPILER_UDONSHARP && UNITY_EDITOR
                    _CopyEditorReferences();
                #endif
            }
            //EditorGUILayout.PropertyField(m_preCountWaitTime);
            EditorGUILayout.Space(4);
            Color oldColor = GUI.backgroundColor;
            GUI.backgroundColor = bg;
            audioDmx.dmx1 = EditorGUILayout.BeginFoldoutHeaderGroup(audioDmx.dmx1, "DMX Channel 1", BoolStyle.labelStyle);
            GUI.backgroundColor  = oldColor;
            if(audioDmx.dmx1)
            {
                EditorGUILayout.BeginVertical("box");
                EditorGUI.indentLevel++;
                EditorGUILayout.PropertyField(m_dmxBool1);
                EditorGUILayout.PropertyField(m_audioValue1);
                EditorGUILayout.PropertyField(m_entryBehaviour1, PropertyLabel("Entry Behaviour"));
                EditorGUILayout.PropertyField(m_entryFunction1, PropertyLabel("Entry Function"));
                EditorGUILayout.PropertyField(m_entryFunctionSpamming1, PropertyLabel("Spam Entry Function?"));
                EditorGUILayout.PropertyField(m_exitBehaviour1, PropertyLabel("Exit Behaviour"));
                EditorGUILayout.PropertyField(m_exitFunction1, PropertyLabel("Exit Function"));
                EditorGUILayout.PropertyField(m_preCountWaitTime1, PropertyLabel("Exit Delay"));
                EditorGUILayout.PropertyField(m_exitFunctionSpamming1, PropertyLabel("Spam Exit Function?"));
                EditorGUI.indentLevel--;
                EditorGUILayout.EndVertical();
            }
            EditorGUILayout.EndFoldoutHeaderGroup();
            EditorGUILayout.Space(4);

            GUI.backgroundColor = bg;
            audioDmx.dmx2 = EditorGUILayout.BeginFoldoutHeaderGroup(audioDmx.dmx2, "DMX Channel 2", BoolStyle.labelStyle);
            GUI.backgroundColor  = oldColor;
            if(audioDmx.dmx2)
            {
                EditorGUILayout.BeginVertical("box");
                EditorGUI.indentLevel++;
                EditorGUILayout.PropertyField(m_dmxBool2);
                EditorGUILayout.PropertyField(m_audioValue2);
                EditorGUILayout.PropertyField(m_entryBehaviour2, PropertyLabel("Entry Behaviour"));
                EditorGUILayout.PropertyField(m_entryFunction2, PropertyLabel("Entry Function"));
                EditorGUILayout.PropertyField(m_entryFunctionSpamming2, PropertyLabel("Spam Entry Function?"));
                EditorGUILayout.PropertyField(m_exitBehaviour2, PropertyLabel("Exit Behaviour"));
                EditorGUILayout.PropertyField(m_exitFunction2, PropertyLabel("Exit Function"));
                EditorGUILayout.PropertyField(m_preCountWaitTime2, PropertyLabel("Exit Delay"));
                EditorGUILayout.PropertyField(m_exitFunctionSpamming2, PropertyLabel("Spam Exit Function?"));
                EditorGUI.indentLevel--;
                EditorGUILayout.EndVertical();
            }
            EditorGUILayout.EndFoldoutHeaderGroup();
            EditorGUILayout.Space(4);

            GUI.backgroundColor = bg;
            audioDmx.dmx3 = EditorGUILayout.BeginFoldoutHeaderGroup(audioDmx.dmx3, "DMX Channel 3", BoolStyle.labelStyle);
            GUI.backgroundColor  = oldColor;
            if(audioDmx.dmx3)
            {
                EditorGUILayout.BeginVertical("box");
                EditorGUI.indentLevel++;
                EditorGUILayout.PropertyField(m_dmxBool3);
                EditorGUILayout.PropertyField(m_audioValue3);
                EditorGUILayout.PropertyField(m_entryBehaviour3, PropertyLabel("Entry Behaviour"));
                EditorGUILayout.PropertyField(m_entryFunction3, PropertyLabel("Entry Function"));
                EditorGUILayout.PropertyField(m_entryFunctionSpamming3, PropertyLabel("Spam Entry Function?"));
                EditorGUILayout.PropertyField(m_exitBehaviour3, PropertyLabel("Exit Behaviour"));
                EditorGUILayout.PropertyField(m_exitFunction3, PropertyLabel("Exit Function"));
                EditorGUILayout.PropertyField(m_preCountWaitTime3, PropertyLabel("Exit Delay"));
                EditorGUILayout.PropertyField(m_exitFunctionSpamming3, PropertyLabel("Spam Exit Function?"));
                EditorGUI.indentLevel--;
                EditorGUILayout.EndVertical();
            }
            EditorGUILayout.EndFoldoutHeaderGroup();
            EditorGUILayout.Space(4);
            
            GUI.backgroundColor = bg;
            audioDmx.dmx4 = EditorGUILayout.BeginFoldoutHeaderGroup(audioDmx.dmx4, "DMX Channel 4", BoolStyle.labelStyle);
            GUI.backgroundColor  = oldColor;
            if(audioDmx.dmx4)
            {
                EditorGUILayout.BeginVertical("box");
                EditorGUI.indentLevel++;
                EditorGUILayout.PropertyField(m_dmxBool4);
                EditorGUILayout.PropertyField(m_audioValue4);
                EditorGUILayout.PropertyField(m_entryBehaviour4, PropertyLabel("Entry Behaviour"));
                EditorGUILayout.PropertyField(m_entryFunction4, PropertyLabel("Entry Function"));
                EditorGUILayout.PropertyField(m_entryFunctionSpamming4, PropertyLabel("Spam Entry Function?"));
                EditorGUILayout.PropertyField(m_exitBehaviour4, PropertyLabel("Exit Behaviour"));
                EditorGUILayout.PropertyField(m_exitFunction4, PropertyLabel("Exit Function"));
                EditorGUILayout.PropertyField(m_preCountWaitTime4, PropertyLabel("Exit Delay"));
                EditorGUILayout.PropertyField(m_exitFunctionSpamming4, PropertyLabel("Spam Exit Function?"));
                EditorGUI.indentLevel--;
                EditorGUILayout.EndVertical();
            }
            EditorGUILayout.EndFoldoutHeaderGroup();
            EditorGUILayout.Space(4);
            
            GUI.backgroundColor = bg;
            audioDmx.dmx5 = EditorGUILayout.BeginFoldoutHeaderGroup(audioDmx.dmx5, "DMX Channel 5", BoolStyle.labelStyle);
            GUI.backgroundColor  = oldColor;
            if(audioDmx.dmx5)
            {
                EditorGUILayout.BeginVertical("box");
                EditorGUI.indentLevel++;
                EditorGUILayout.PropertyField(m_dmxBool5);
                EditorGUILayout.PropertyField(m_audioValue5);
                EditorGUILayout.PropertyField(m_entryBehaviour5, PropertyLabel("Entry Behaviour"));
                EditorGUILayout.PropertyField(m_entryFunction5, PropertyLabel("Entry Function"));
                EditorGUILayout.PropertyField(m_entryFunctionSpamming5, PropertyLabel("Spam Entry Function?"));
                EditorGUILayout.PropertyField(m_exitBehaviour5, PropertyLabel("Exit Behaviour"));
                EditorGUILayout.PropertyField(m_exitFunction5, PropertyLabel("Exit Function"));
                EditorGUILayout.PropertyField(m_preCountWaitTime5, PropertyLabel("Exit Delay"));
                EditorGUILayout.PropertyField(m_exitFunctionSpamming5, PropertyLabel("Spam Exit Function?"));
                EditorGUI.indentLevel--;
                EditorGUILayout.EndVertical();
            }
            EditorGUILayout.EndFoldoutHeaderGroup();
            EditorGUILayout.Space(4);
            
            GUI.backgroundColor = bg;
            audioDmx.dmx6 = EditorGUILayout.BeginFoldoutHeaderGroup(audioDmx.dmx6, "DMX Channel 6", BoolStyle.labelStyle);
            GUI.backgroundColor  = oldColor;
            if(audioDmx.dmx6)
            {
                EditorGUILayout.BeginVertical("box");
                EditorGUI.indentLevel++;
                EditorGUILayout.PropertyField(m_dmxBool6);
                EditorGUILayout.PropertyField(m_audioValue6);
                EditorGUILayout.PropertyField(m_entryBehaviour6, PropertyLabel("Entry Behaviour"));
                EditorGUILayout.PropertyField(m_entryFunction6, PropertyLabel("Entry Function"));
                EditorGUILayout.PropertyField(m_entryFunctionSpamming6, PropertyLabel("Spam Entry Function?"));
                EditorGUILayout.PropertyField(m_exitBehaviour6, PropertyLabel("Exit Behaviour"));
                EditorGUILayout.PropertyField(m_exitFunction6, PropertyLabel("Exit Function"));
                EditorGUILayout.PropertyField(m_preCountWaitTime6, PropertyLabel("Exit Delay"));
                EditorGUILayout.PropertyField(m_exitFunctionSpamming6, PropertyLabel("Spam Exit Function?"));
                EditorGUI.indentLevel--;
                EditorGUILayout.EndVertical();
            }
            EditorGUILayout.EndFoldoutHeaderGroup();
            EditorGUILayout.Space(4);
            
            GUI.backgroundColor = bg;
            audioDmx.dmx7 = EditorGUILayout.BeginFoldoutHeaderGroup(audioDmx.dmx7, "DMX Channel 7", BoolStyle.labelStyle);
            GUI.backgroundColor  = oldColor;
            if(audioDmx.dmx7)
            {
                EditorGUILayout.BeginVertical("box");
                EditorGUI.indentLevel++;
                EditorGUILayout.PropertyField(m_dmxBool7);
                EditorGUILayout.PropertyField(m_audioValue7);
                EditorGUILayout.PropertyField(m_entryBehaviour7, PropertyLabel("Entry Behaviour"));
                EditorGUILayout.PropertyField(m_entryFunction7, PropertyLabel("Entry Function"));
                EditorGUILayout.PropertyField(m_entryFunctionSpamming7, PropertyLabel("Spam Entry Function?"));
                EditorGUILayout.PropertyField(m_exitBehaviour7, PropertyLabel("Exit Behaviour"));
                EditorGUILayout.PropertyField(m_exitFunction7, PropertyLabel("Exit Function"));
                EditorGUILayout.PropertyField(m_preCountWaitTime7, PropertyLabel("Exit Delay"));
                EditorGUILayout.PropertyField(m_exitFunctionSpamming7, PropertyLabel("Spam Exit Function?"));
                EditorGUI.indentLevel--;
                EditorGUILayout.EndVertical();
            }
            EditorGUILayout.EndFoldoutHeaderGroup();
            EditorGUILayout.Space(4);
            
            GUI.backgroundColor = bg;
            audioDmx.dmx8 = EditorGUILayout.BeginFoldoutHeaderGroup(audioDmx.dmx8, "DMX Channel 8", BoolStyle.labelStyle);
            GUI.backgroundColor  = oldColor;
            if(audioDmx.dmx8)
            {
                EditorGUILayout.BeginVertical("box");
                EditorGUI.indentLevel++;
                EditorGUILayout.PropertyField(m_dmxBool8);
                EditorGUILayout.PropertyField(m_audioValue8);
                EditorGUILayout.PropertyField(m_entryBehaviour8, PropertyLabel("Entry Behaviour"));
                EditorGUILayout.PropertyField(m_entryFunction8, PropertyLabel("Entry Function"));
                EditorGUILayout.PropertyField(m_entryFunctionSpamming8, PropertyLabel("Spam Entry Function?"));
                EditorGUILayout.PropertyField(m_exitBehaviour8, PropertyLabel("Exit Behaviour"));
                EditorGUILayout.PropertyField(m_exitFunction8, PropertyLabel("Exit Function"));
                EditorGUILayout.PropertyField(m_preCountWaitTime8, PropertyLabel("Exit Delay"));
                EditorGUILayout.PropertyField(m_exitFunctionSpamming8, PropertyLabel("Spam Exit Function?"));
                EditorGUI.indentLevel--;
                EditorGUILayout.EndVertical();
            }
            EditorGUILayout.EndFoldoutHeaderGroup();
            EditorGUILayout.Space(4);

            if(audioDmx.twelveBitMode)
            {
                
            
                GUI.backgroundColor = bg;
                audioDmx.dmx9 = EditorGUILayout.BeginFoldoutHeaderGroup(audioDmx.dmx9, "DMX Channel 9", BoolStyle.labelStyle);
                GUI.backgroundColor  = oldColor;
                if(audioDmx.dmx9)
                {
                    EditorGUILayout.BeginVertical("box");
                    EditorGUI.indentLevel++;
                    EditorGUILayout.PropertyField(m_dmxBool9);
                    EditorGUILayout.PropertyField(m_audioValue9);
                    EditorGUILayout.PropertyField(m_entryBehaviour9, PropertyLabel("Entry Behaviour"));
                    EditorGUILayout.PropertyField(m_entryFunction9, PropertyLabel("Entry Function"));
                    EditorGUILayout.PropertyField(m_entryFunctionSpamming9, PropertyLabel("Spam Entry Function?"));
                    EditorGUILayout.PropertyField(m_exitBehaviour9, PropertyLabel("Exit Behaviour"));
                    EditorGUILayout.PropertyField(m_exitFunction9, PropertyLabel("Exit Function"));
                    EditorGUILayout.PropertyField(m_preCountWaitTime9, PropertyLabel("Exit Delay"));
                    EditorGUILayout.PropertyField(m_exitFunctionSpamming9, PropertyLabel("Spam Exit Function?"));
                    EditorGUI.indentLevel--;
                    EditorGUILayout.EndVertical();
                }
                EditorGUILayout.EndFoldoutHeaderGroup();
                EditorGUILayout.Space(4);

                GUI.backgroundColor = bg;
                audioDmx.dmx10 = EditorGUILayout.BeginFoldoutHeaderGroup(audioDmx.dmx10, "DMX Channel 10", BoolStyle.labelStyle);
                GUI.backgroundColor  = oldColor;
                if(audioDmx.dmx10)
                {
                    EditorGUILayout.BeginVertical("box");
                    EditorGUI.indentLevel++;
                    EditorGUILayout.PropertyField(m_dmxBool10);
                    EditorGUILayout.PropertyField(m_audioValue10);
                    EditorGUILayout.PropertyField(m_entryBehaviour10, PropertyLabel("Entry Behaviour"));
                    EditorGUILayout.PropertyField(m_entryFunction10, PropertyLabel("Entry Function"));
                    EditorGUILayout.PropertyField(m_entryFunctionSpamming10, PropertyLabel("Spam Entry Function?"));
                    EditorGUILayout.PropertyField(m_exitBehaviour10, PropertyLabel("Exit Behaviour"));
                    EditorGUILayout.PropertyField(m_exitFunction10, PropertyLabel("Exit Function"));
                    EditorGUILayout.PropertyField(m_preCountWaitTime10, PropertyLabel("Exit Delay"));
                    EditorGUILayout.PropertyField(m_exitFunctionSpamming10, PropertyLabel("Spam Exit Function?"));
                    EditorGUI.indentLevel--;
                    EditorGUILayout.EndVertical();
                }
                EditorGUILayout.EndFoldoutHeaderGroup();
                EditorGUILayout.Space(4);

                GUI.backgroundColor = bg;
                audioDmx.dmx11 = EditorGUILayout.BeginFoldoutHeaderGroup(audioDmx.dmx11, "DMX Channel 11", BoolStyle.labelStyle);
                GUI.backgroundColor  = oldColor;
                if(audioDmx.dmx11)
                {
                    EditorGUILayout.BeginVertical("box");
                    EditorGUI.indentLevel++;
                    EditorGUILayout.PropertyField(m_dmxBool11);
                    EditorGUILayout.PropertyField(m_audioValue11);
                    EditorGUILayout.PropertyField(m_entryBehaviour11, PropertyLabel("Entry Behaviour"));
                    EditorGUILayout.PropertyField(m_entryFunction11, PropertyLabel("Entry Function"));
                    EditorGUILayout.PropertyField(m_entryFunctionSpamming11, PropertyLabel("Spam Entry Function?"));
                    EditorGUILayout.PropertyField(m_exitBehaviour11, PropertyLabel("Exit Behaviour"));
                    EditorGUILayout.PropertyField(m_exitFunction11, PropertyLabel("Exit Function"));
                    EditorGUILayout.PropertyField(m_preCountWaitTime11, PropertyLabel("Exit Delay"));
                    EditorGUILayout.PropertyField(m_exitFunctionSpamming11, PropertyLabel("Spam Exit Function?"));

                    EditorGUI.indentLevel--;
                    EditorGUILayout.EndVertical();
                }
                EditorGUILayout.EndFoldoutHeaderGroup();
                EditorGUILayout.Space(4);

                GUI.backgroundColor = bg;
                audioDmx.dmx12 = EditorGUILayout.BeginFoldoutHeaderGroup(audioDmx.dmx12, "DMX Channel 12", BoolStyle.labelStyle);
                GUI.backgroundColor  = oldColor;
                if(audioDmx.dmx12)
                {
                    EditorGUILayout.BeginVertical("box");
                    EditorGUI.indentLevel++;
                    EditorGUILayout.PropertyField(m_dmxBool12);
                    EditorGUILayout.PropertyField(m_audioValue12);
                    EditorGUILayout.PropertyField(m_entryBehaviour12, PropertyLabel("Entry Behaviour"));
                    EditorGUILayout.PropertyField(m_entryFunction12, PropertyLabel("Entry Function"));
                    EditorGUILayout.PropertyField(m_entryFunctionSpamming12, PropertyLabel("Spam Entry Function?"));
                    EditorGUILayout.PropertyField(m_exitBehaviour12, PropertyLabel("Exit Behaviour"));
                    EditorGUILayout.PropertyField(m_exitFunction12, PropertyLabel("Exit Function"));
                    EditorGUILayout.PropertyField(m_preCountWaitTime12, PropertyLabel("Exit Delay"));
                    EditorGUILayout.PropertyField(m_exitFunctionSpamming12, PropertyLabel("Spam Exit Function?"));
                    EditorGUI.indentLevel--;
                    EditorGUILayout.EndVertical();
                }
                EditorGUILayout.EndFoldoutHeaderGroup();
                EditorGUILayout.Space(4);

                // GUI.backgroundColor = bg;
                // audioDmx.dmx13 = EditorGUILayout.BeginFoldoutHeaderGroup(audioDmx.dmx13, "DMX Channel 13", BoolStyle.labelStyle);
                // GUI.backgroundColor  = oldColor;
                // if(audioDmx.dmx13)
                // {
                //     EditorGUILayout.BeginVertical("box");
                //     EditorGUI.indentLevel++;
                //     EditorGUILayout.PropertyField(m_dmxBool13);
                //     EditorGUILayout.PropertyField(m_audioValue13);
                //     EditorGUILayout.PropertyField(m_entryBehaviour13);
                //     EditorGUILayout.PropertyField(m_entryFunction13);
                //     EditorGUILayout.PropertyField(m_exitBehaviour13);
                //     EditorGUILayout.PropertyField(m_exitFunction13);
                //     EditorGUI.indentLevel--;
                //     EditorGUILayout.EndVertical();
                // }
                // EditorGUILayout.EndFoldoutHeaderGroup();
                // EditorGUILayout.Space(4);

                // GUI.backgroundColor = bg;
                // audioDmx.dmx14 = EditorGUILayout.BeginFoldoutHeaderGroup(audioDmx.dmx14, "DMX Channel 14", BoolStyle.labelStyle);
                // GUI.backgroundColor  = oldColor;
                // if(audioDmx.dmx14)
                // {
                //     EditorGUILayout.BeginVertical("box");
                //     EditorGUI.indentLevel++;
                //     EditorGUILayout.PropertyField(m_dmxBool14);
                //     EditorGUILayout.PropertyField(m_audioValue14);
                //     EditorGUILayout.PropertyField(m_entryBehaviour14);
                //     EditorGUILayout.PropertyField(m_entryFunction14);
                //     EditorGUILayout.PropertyField(m_exitBehaviour14);
                //     EditorGUILayout.PropertyField(m_exitFunction14);
                //     EditorGUI.indentLevel--;
                //     EditorGUILayout.EndVertical();
                // }
                // EditorGUILayout.EndFoldoutHeaderGroup();
                // EditorGUILayout.Space(4);

                // GUI.backgroundColor = bg;
                // audioDmx.dmx15 = EditorGUILayout.BeginFoldoutHeaderGroup(audioDmx.dmx15, "DMX Channel 15", BoolStyle.labelStyle);
                // GUI.backgroundColor  = oldColor;
                // if(audioDmx.dmx15)
                // {
                //     EditorGUILayout.BeginVertical("box");
                //     EditorGUI.indentLevel++;
                //     EditorGUILayout.PropertyField(m_dmxBool15);
                //     EditorGUILayout.PropertyField(m_audioValue15);
                //     EditorGUILayout.PropertyField(m_entryBehaviour15);
                //     EditorGUILayout.PropertyField(m_entryFunction15);
                //     EditorGUILayout.PropertyField(m_exitBehaviour15);
                //     EditorGUILayout.PropertyField(m_exitFunction15);
                //     EditorGUI.indentLevel--;
                //     EditorGUILayout.EndVertical();
                // }
                // EditorGUILayout.EndFoldoutHeaderGroup();
                // EditorGUILayout.Space(4);

                // GUI.backgroundColor = bg;
                // audioDmx.dmx16 = EditorGUILayout.BeginFoldoutHeaderGroup(audioDmx.dmx16, "DMX Channel 16", BoolStyle.labelStyle);
                // GUI.backgroundColor  = oldColor;
                // if(audioDmx.dmx16)
                // {
                //     EditorGUILayout.BeginVertical("box");
                //     EditorGUI.indentLevel++;
                //     EditorGUILayout.PropertyField(m_dmxBool16);
                //     EditorGUILayout.PropertyField(m_audioValue16);
                //     EditorGUILayout.PropertyField(m_entryBehaviour16);
                //     EditorGUILayout.PropertyField(m_entryFunction16);
                //     EditorGUILayout.PropertyField(m_exitBehaviour16);
                //     EditorGUILayout.PropertyField(m_exitFunction16);
                //     EditorGUI.indentLevel--;
                //     EditorGUILayout.EndVertical();
                // }
                // EditorGUILayout.EndFoldoutHeaderGroup();
                // EditorGUILayout.Space(4);
            }

            EditorGUILayout.PropertyField(m_showRawData);
            if(audioDmx.showRawData)
            {
                EditorGUILayout.PropertyField(m_data);
            }

            serializedObject.ApplyModifiedProperties();
        }

    }
#endif
#endif
}
