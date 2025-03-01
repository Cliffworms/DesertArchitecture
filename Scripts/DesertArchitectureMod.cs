// Project:         Fixed Desert Architecture for Daggerfall Unity (http://www.dfworkshop.net)
// Copyright:       Copyright (C) 2025 Cliffworms
// License:         MIT License (http://www.opensource.org/licenses/mit-license.php)
// Author:          Hazelnut & Cliffworms

using System;
using UnityEngine;
using DaggerfallWorkshop.Game;
using DaggerfallWorkshop.Game.Serialization;
using DaggerfallWorkshop.Game.Utility;
using DaggerfallWorkshop.Game.Utility.ModSupport;
using DaggerfallWorkshop.Utility.AssetInjection;
using DaggerfallWorkshop.Utility;

namespace DesertArchitecture
{
    public class DesertArchitectureMod : MonoBehaviour
    {
        private const string variantBubissidata = "_bubissidata";


        static Mod mod;

        [Invoke(StateManager.StateTypes.Start, 0)]
        public static void Init(InitParams initParams)
        {
            mod = initParams.Mod;
            var go = new GameObject(mod.Title);
            go.AddComponent<DesertArchitectureMod>();
        }

        void Start()
        {
            Debug.Log("Begin mod init: DesertArchitecture");

            SaveLoadManager.OnLoad += SaveLoadManager_OnLoad;
            StartGameBehaviour.OnStartGame += StartGameBehaviour_OnStartGame;

            mod.IsReady = true;
            Debug.Log("Finished mod init: DesertArchitecture");
        }


        public void StartGameBehaviour_OnStartGame(object sender, EventArgs e)
        {
            InitVariants();
        }

        void SaveLoadManager_OnLoad(SaveData_v1 saveData)
        {
            InitVariants();
        }

        void InitVariants()
        {
            // Bubissidata (2) in region 20
            if (WorldDataVariants.GetBlockVariant(20, 2, "THIEBL00.RMB") == null)
            {
                int locBubissidata = WorldDataReplacement.MakeLocationKey(20, 2);
                WorldDataVariants.SetBlockVariant("THIEBL00.RMB", variantBubissidata, locBubissidata);
            }
        }
        
    }
}