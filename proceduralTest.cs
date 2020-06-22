using MSCLoader;
using System.Net.NetworkInformation;
using UnityEngine;

namespace proceduralTest
{
    public class proceduralTest : Mod
    {
        public override string ID => "proceduralTest"; //Your mod ID (unique)
        public override string Name => "proceduralTest"; //You mod name
        public override string Author => "esp"; //Your Username
        public override string Version => "1.0"; //Version

        // Set this to true if you will be load custom assets from Assets folder.
        // This will create subfolder in Assets folder for your mod.
        public override bool UseAssetsFolder => true;
        public static AssetBundle ab;
        public static GameObject player;

        public static GameObject[] straights = new GameObject[255];
        public static GameObject[] rightTurns = new GameObject[255];
        public static GameObject[] leftTurns = new GameObject[255];
        public static GameObject[] specials = new GameObject[255];

        private GameObject bruh;

        public override void OnNewGame()
        {
            // Called once, when starting a New Game, you can reset your saves here
        }

        public override void OnLoad()
        {
            AssetBundle ab = LoadAssets.LoadBundle(this, "proceduraltest.unity3d");
            straights[0] = ab.LoadAsset("testChunkStraight.prefab") as GameObject;
            rightTurns[0] = ab.LoadAsset("testChunkRight.prefab") as GameObject;
            rightTurns[1] = ab.LoadAsset("testChunkLongRight.prefab") as GameObject;
            leftTurns[0] = ab.LoadAsset("testChunkLeft.prefab") as GameObject;
            leftTurns[1] = ab.LoadAsset("testChunkLongLeft.prefab") as GameObject;

            ab.Unload(false);

            player = GameObject.Find("PLAYER");

            bruh = new GameObject("ChunkManager");
            bruh.AddComponent<ChunkManager>();
        }

        public override void ModSettings()
        {
            // All settings should be created here. 
            // DO NOT put anything else here that settings.
        }

        public override void OnSave()
        {
            // Called once, when save and quit
            // Serialize your save file here.
        }

        public override void OnGUI()
        {
            // Draw unity OnGUI() here
        }

        public override void Update()
        {
            // Update is called once per frame
        }
    }
}
