using HutongGames.PlayMaker.Actions;
using MSCLoader;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace proceduralTest
{
    public class ChunkManager : MonoBehaviour
    {
        private GameObject[] prefabsStraight;
        private GameObject[] prefabsRight;
        private GameObject[] prefabsLeft;
        private GameObject playerb;
        private List<GameObject> prefabs;

        //important functionality stuff
        private GameObject currentChunk;
        private GameObject nextChunk;
        private int rand;
        private int prerand;
        private int currentChunkType;
        private int previousChunkType;

        private GameObject[] chunks = new GameObject[32];
        private int spawnIndex = 0;
       


        private GameObject prefabChunk;



        // Use this for initialization
        void Start()
        {
            
            prefabsStraight = proceduralTest.straights;
            prefabsRight = proceduralTest.rightTurns;
            prefabsLeft = proceduralTest.leftTurns;
            playerb = proceduralTest.player;
            prefabs = new List<GameObject>();
            prefabs.Insert(0, prefabsRight[0].gameObject);
            prefabs.Insert(1, prefabsLeft[0].gameObject);
            prefabs.Insert(2, prefabsRight[1].gameObject);
            prefabs.Insert(3, prefabsLeft[1].gameObject);
            prefabs.Insert(4, prefabsStraight[0]);
            prefabs.Insert(5, prefabsStraight[0]); // enterprise ready code
            prefabs.Insert(6, prefabsStraight[0]);
            prefabs.Insert(7, prefabsStraight[0]);
            prefabs.Insert(8, prefabsStraight[0]);
            prefabs.Insert(9, prefabsStraight[0]);



            currentChunk = GameObject.Instantiate(prefabsStraight[0]);
            currentChunk.transform.position = new Vector3(0, 60, 0);
            currentChunkType = 2;
            previousChunkType = 1;
            StartCoroutine(ArrayStuff(currentChunk));
            StartCoroutine(RangeCheck());

        }

        #region rangecheck
        IEnumerator RangeCheck()
        {
            if (Vector3.Distance(currentChunk.transform.position, playerb.transform.position) < 100)
            {
                StartCoroutine(RandomDeterminator6900());
            }
            else
            {
                yield return new WaitForSeconds(0.5f);
                StartCoroutine(RangeCheck());
            }
        }
        #endregion
        IEnumerator RandomDeterminator6900()
        {
            prerand = UnityEngine.Random.Range(0, 9);
            StartCoroutine(RandomlyFeedItAOne());
            if (prerand > 4)
            {
                StartCoroutine(SpawnChunk(currentChunk.transform.GetChild(0).gameObject.transform, prerand));
                yield return new WaitForEndOfFrame();
            }
            else
            {
                rand = UnityEngine.Random.Range(0, 4);
                currentChunkType = rand;
                StartCoroutine(SpawnChunkTurn(currentChunk.transform.GetChild(0).gameObject.transform, rand));
                yield return new WaitForEndOfFrame();
            }
        }

        IEnumerator RandomlyFeedItAZero()
        {
            int azero = UnityEngine.Random.Range(0, 128);
            if(azero == 53 | azero == 69 | azero == 12)
            {
                previousChunkType = 0;
                yield return new WaitForEndOfFrame();
            }
            
        }

        IEnumerator RandomlyFeedItAOne()
        {
            int aone = UnityEngine.Random.Range(0, 128);
            if (aone == 32 | aone == 64 | aone == 123)
            {
                currentChunkType = 1;
                yield return new WaitForEndOfFrame();
            }

        }

        IEnumerator SpawnChunk(Transform spawnLocation, int chunkType)
        {
            prefabChunk = prefabs[chunkType];
            nextChunk = GameObject.Instantiate(prefabChunk);
            chunkType = currentChunkType;
            previousChunkType = currentChunkType;
            nextChunk.transform.position = spawnLocation.position;
            nextChunk.transform.rotation = spawnLocation.rotation;
            StartCoroutine(ArrayStuff(nextChunk));
            currentChunk = nextChunk;
            StartCoroutine(RangeCheck());
            yield return new WaitForEndOfFrame();
        }

        IEnumerator SpawnChunkTurn(Transform spawnLocation, int chunkType)
        {
            if (previousChunkType == currentChunkType)
            {
                StartCoroutine(RandomDeterminator6900());
                yield return new WaitForEndOfFrame();
            }
            else
            {
                prefabChunk = prefabs[chunkType];
                nextChunk = GameObject.Instantiate(prefabChunk);
                chunkType = currentChunkType;
                previousChunkType = currentChunkType;
                StartCoroutine(RandomlyFeedItAZero());
                nextChunk.transform.position = spawnLocation.position;
                nextChunk.transform.rotation = spawnLocation.rotation;
                StartCoroutine(ArrayStuff(nextChunk));
                currentChunk = nextChunk;
                StartCoroutine(RangeCheck());
                yield return new WaitForEndOfFrame();
            }
        }

        IEnumerator ArrayStuff(GameObject roadPrefab)
        {
            if (chunks[spawnIndex] != null)
            {
                GameObject.Destroy(chunks[spawnIndex]);
            }

            chunks[spawnIndex] = roadPrefab;
            spawnIndex = Mathf.FloorToInt(Mathf.Repeat(spawnIndex + 1, 32));
            yield return new WaitForEndOfFrame();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}