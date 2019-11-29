using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    [SerializeField] private int minDistanceFromPlayer;
    [SerializeField] private int maxTerrainCount;
    [SerializeField] private List<TerrainData> terrainDatas = new List<TerrainData>();
    [SerializeField] private Transform terrainHolder;
    private List<GameObject> currentTerrains = new List<GameObject>();
    [HideInInspector] public Vector3 currentPosition = new Vector3(0, 0, 0);
    
    private GameObject fallingObj1;
    private GameObject fallingObj2;
    private GameObject fallingObj3;

    public static float falilingXPosition;


    private void Start () {
        currentPosition = new Vector3(0, 0, 0);
        for (int i = 0; i < maxTerrainCount; i++) {
            SpawnTerrain(true, new Vector3(0,0,0), Player.isSpeedMode);
        }    
        maxTerrainCount = currentTerrains.Count;   
    }

    public void SpawnTerrain(bool isStart, Vector3 playerPos, bool isSpeedMode) {

        if (currentPosition.x - playerPos.x < minDistanceFromPlayer || isStart) {

            int whichTerrain = Random.Range(0, terrainDatas.Count);
            int terrainInSuccession = Random.Range(1, terrainDatas[whichTerrain].maxInSuccession);
            
            for (int i = 0; i < terrainInSuccession; i++) {
                GameObject terrain = Instantiate(terrainDatas[whichTerrain].possibleTerrain[Random.Range(0,terrainDatas[whichTerrain].possibleTerrain.Count)], currentPosition, Quaternion.identity, terrainHolder);
                currentTerrains.Add(terrain);
                
                if (!isStart) {
                    if (isSpeedMode) {
                        fallingTerrain();
                    }
                    else if (currentTerrains.Count > maxTerrainCount) {
                        Destroy(currentTerrains[0]);
                        currentTerrains.RemoveAt(0);
                    }
                }
                currentPosition.x++;
            }
        }   
    }
    
    private void fallingTerrain() {
        fallingObj1  = currentTerrains[0];
        fallingObj2 = currentTerrains[1];
        fallingObj3 = currentTerrains[2];
    }

    void Update() {

        if(fallingObj1 != null && !Player.isPaused) {
            falilingXPosition = fallingObj1.transform.position.x;
                fallingObj1.transform.Translate(new Vector3(0, -1, 0) * Time.deltaTime * 1.0f);
                  if(fallingObj1.transform.position.y <= -2) {
                    Destroy(fallingObj1);
                    currentTerrains.RemoveAt(0);
                    fallingObj1 = currentTerrains[0];
                }
        }
         if(fallingObj2 != null && !Player.isPaused) {
                fallingObj2.transform.Translate(new Vector3(0, -1, 0) * Time.deltaTime * 1.0f);
                  if(fallingObj2.transform.position.y <= -2.1) {
                    Destroy(fallingObj2);
                    currentTerrains.RemoveAt(0);
                    fallingObj2 = currentTerrains[0];
                }
        }
         if(fallingObj3 != null && !Player.isPaused) {
                fallingObj3.transform.Translate(new Vector3(0, -1, 0) * Time.deltaTime * 1.0f);
                  if(fallingObj3.transform.position.y <= -2.2) {
                    Destroy(fallingObj3);
                    currentTerrains.RemoveAt(0);
                    fallingObj3 = currentTerrains[0];
                }
        }

    }
}
