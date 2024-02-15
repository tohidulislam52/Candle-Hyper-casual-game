using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    [SerializeField] private GameObject[] TilePrefads;
    [SerializeField] private Transform playerTransform;
    private List<GameObject> ActiveTile = new List<GameObject>();
    private float Zvalu;
    private float TileLength =30;
    private int NumberOfTile=4;  
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < NumberOfTile; i++)
        {
            if(i==0)
                SpawnTile(0);
            else
                SpawnTile(Random.Range(1,TilePrefads.Length));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if((playerTransform.position.z-30) >Zvalu - (NumberOfTile*TileLength))
        {
            Debug.Log("valu"+(Zvalu - (NumberOfTile*TileLength)));
            SpawnTile(Random.Range(1,TilePrefads.Length));
            DeleteTile();
        }
    }
    public void SpawnTile(int tileIndex)
    {
        GameObject NewTile = Instantiate(TilePrefads[tileIndex],transform.forward*Zvalu,Quaternion.identity,transform);
        ActiveTile.Add(NewTile);
        Zvalu +=TileLength;
    }
    private void DeleteTile()
    {
        Destroy(ActiveTile[0]);
        ActiveTile.RemoveAt(0);
    }
}
