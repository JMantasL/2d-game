using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateChunks : MonoBehaviour{

    public GameObject chunk;
    int chunkWidth;
    public int chunkNum;
    float seed;

    void Start(){
        chunkWidth = chunk.GetComponent<Chunk>().width;
        seed = Random.Range(-100000f, 100000f);
        Generate();
    }

    public void Generate(){
        int lastX = -chunkWidth;
        for(int i = 0; i < chunkNum; i++){
            GameObject newChunk = Instantiate(chunk, new Vector3(lastX + chunkWidth, 0f), Quaternion.identity) as GameObject;
            newChunk.GetComponent<Chunk>().seed = seed;
            lastX += chunkWidth;
        }
    }
}
