using HutongGames.PlayMaker.Actions;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace proceduralTest
{
    public class Chunk : MonoBehaviour
    {
        private GameObject playerb;

        public int pickObject;

        public bool currentChunk;



        // Use this for initialization
        void Start()
        {
            playerb = proceduralTest.player;

        }

        void OnCollisionEnter(Collision collision)
        {
            if (currentChunk = true | collision.gameObject.GetComponent<Chunk>()) 
            {
                GameObject.Destroy(collision.gameObject);
            }
        }



    }
}