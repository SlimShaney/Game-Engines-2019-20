using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instantiateAudioSpectrum : MonoBehaviour
{
    public GameObject audioSamplePrefab;
    GameObject[] sampleObject = new GameObject[64];
    public float maxScale;
    public float plusMinusDirection;
    public int directionNumber;
    
    void Start()
    {
        for (int i = 0; i < sampleObject.Length; i++)
        {
            GameObject sampleObjectInstance = Instantiate(audioSamplePrefab);
            sampleObjectInstance.transform.position = transform.position;
            sampleObjectInstance.transform.parent = transform;
            sampleObjectInstance.name = "Sample Object #" + (i + 1);
            transform.eulerAngles = new Vector3(0, -0.703125f * i * plusMinusDirection, 0);
            if (directionNumber == 1)
            {
                sampleObjectInstance.transform.position = Vector3.forward * 50;
            }
            else if (directionNumber == 2)
            {
                sampleObjectInstance.transform.position = Vector3.right * 50;
            }
            else if (directionNumber == 3)
            {
                sampleObjectInstance.transform.position = Vector3.back * 50;
            }
            else if (directionNumber == 4)
            {
                sampleObjectInstance.transform.position = Vector3.left * 50;
            }

            sampleObject[i] = sampleObjectInstance;
        }
    }

    void Update()
    {
        for (int i = 0; i < sampleObject.Length; i++)
        {
            if (sampleObject != null)
            {
                sampleObject[i].transform.localScale = new Vector3(0.5f, (audioScript.samples[i] * maxScale) + 1, 0.5f);
            }
        }
    }
}
