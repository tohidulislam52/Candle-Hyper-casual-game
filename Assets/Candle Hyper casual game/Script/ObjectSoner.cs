using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSoner : MonoBehaviour
{
    [SerializeField] private GameObject[] objectss;
    [SerializeField] private int count;
    [SerializeField] private float Zvalu;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < count; i++)
        {
            int j =Random.Range(0,objectss.Length);
            Vector3 objectposition = new Vector3(0,1f,Zvalu);
            Instantiate(objectss[j],objectposition,Quaternion.identity,transform);
            Zvalu +=20;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
