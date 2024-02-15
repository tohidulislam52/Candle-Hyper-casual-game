using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallCandleSponer : MonoBehaviour
{
    [SerializeField] private GameObject smallcandle;
    [SerializeField] private int candlecount;
    [SerializeField] private Vector2 MniMasNumber;
    private int Zvalu = 30;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < candlecount; i++)
        {
            Vector3 candlePosition = new Vector3(Random.Range(MniMasNumber.x,MniMasNumber.y),0.80f,Zvalu);
            Instantiate(smallcandle.transform,candlePosition,Quaternion.identity,transform);
            Zvalu = Zvalu+20;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
