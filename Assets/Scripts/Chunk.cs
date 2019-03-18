using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour{

    public GameObject DirtTile;
    public GameObject StoneTile;
    public GameObject GrassTile;

    public int width;
    public float heightMult;
    public int heightAddition;

    public float smoothness;

    [HideInInspector]
    public float seed;

    void Start(){
        Generate();
    }

    public void Generate(){
        for(int i = 0; i < width; i++){
            int h = Mathf.RoundToInt(Mathf.PerlinNoise(seed, (i + transform.position.x) / smoothness) * heightMult) + heightAddition;
            for(int j = 0; j < h; j++){
                GameObject selectedTile;
                if(j < h - 4){
                    selectedTile = StoneTile;
                }else if(j < h - 1){
                    selectedTile = DirtTile;
                }else{
                    selectedTile = GrassTile;
                }
                GameObject newTile = Instantiate(selectedTile, Vector3.zero, Quaternion.identity) as GameObject;
                newTile.transform.parent = this.gameObject.transform;
                newTile.transform.localPosition = new Vector3(i, j);
            }
        }
    }
   
}
