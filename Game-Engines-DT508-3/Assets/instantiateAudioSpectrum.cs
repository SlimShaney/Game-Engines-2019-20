using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instantiateAudioSpectrum : MonoBehaviour
{
    public GameObject audioSamplePrefab;
    GameObject[] sampleObject = new GameObject[512];
    public float maxScale;
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 512; i++)
        {
            GameObject sampleObjectInstance = Instantiate(audioSamplePrefab);
            sampleObjectInstance.transform.position = transform.position;
            sampleObjectInstance.transform.parent = transform;
            sampleObjectInstance.name = "Sample Object #" + i;
            transform.eulerAngles = new Vector3(0, -0.703125f * i, 0);
            sampleObjectInstance.transform.position = Vector3.forward * 100;
            sampleObject[i] = sampleObjectInstance;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 512; i++)
        {
            if (sampleObject != null)
            {
                sampleObject[i].transform.localScale = new Vector3(1, (audioScript.samples[i] * maxScale) + 2, 1);
            }
        }
    }
}
