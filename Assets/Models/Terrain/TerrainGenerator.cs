using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TerrainGenerator : MonoBehaviour
{
    public GameObject terrainPiece;
    public Vector3 startingPoint;
    public Vector2 size;

    public float scaleFactor = 3f;
    float xWidth = 0.866f;
    float yWidth = 1.0f;
    float zWidth = 0.3f;
    public float gap = 0.0f;

    public void GenerateTerrain()
     {
          foreach (Transform child in gameObject.transform) {
            DestroyImmediate(child.gameObject);
            }

        GoGenerate();
     }

     private void GoGenerate(){

    bool spazietto = false;
    Vector3 position = startingPoint;
         for (var i=0; i<size.y; i++ ){
             position.z = startingPoint.z + i * (yWidth + gap)* scaleFactor * 3/4;
             for (var d=0; d<size.x; d++){
                position.x = startingPoint.x + d * (xWidth + gap)* scaleFactor;
                if(spazietto) position.x += (xWidth * scaleFactor) /2; 
                var newHex = Instantiate(terrainPiece, position, Quaternion.identity);
                newHex.transform.parent = gameObject.transform;
             }
             spazietto = !spazietto;
         }

     }
}
