using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOManager : MonoBehaviour
{
    public GameObject UFO;
    public float initialWait;
    public float minWaitTime;
    public float maxWaitTime;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GenerateUFO());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator GenerateUFO()
    {
        yield return new WaitForSeconds(initialWait);
        while(true)
        {
            GameObject.Instantiate(UFO);
            yield return new WaitForSeconds(Random.Range(minWaitTime, maxWaitTime));
        }
    }

}
