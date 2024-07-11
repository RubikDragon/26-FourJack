using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace BackJackSystem.UI
{
    public class SpawnChips : MonoBehaviour
    {
        [Header("Chips to spawn")]
        [SerializeField] private GameObject[] chipPrefaps;

        [Header("Prefab Making info")]
        [SerializeField] private float timeIndBetvienSpawn;
        [SerializeField] private float chipSize;
        [SerializeField] private float spawnOffSet;
        [SerializeField] private Transform chipSpawnPositon;

        [Space(10)]
        [SerializeField] private GameHandler onRoundEnd;

        private List<GameObject> chips; 

        private void Awake()
        {
            chips = new List<GameObject>();

            // linkes to events
            ChipHandler.OnChipAdded += ChipHandler_OnChipAdded1;
            onRoundEnd.OnRoundEnd += GameHander_OnRoundEnd;
        }

        private void ChipHandler_OnChipAdded1(byte chipAmountSent)
        {
            StartCoroutine(SpawnChipsOnBord(chipAmountSent));
            
        }

        private void GameHander_OnRoundEnd()
        {
            RemoveChips();
        }

        private IEnumerator SpawnChipsOnBord(byte spawnAmount)
        {
            for (int i = 0; i < spawnAmount; i++)
            {
                GameObject newChip = Instantiate(chipPrefaps[Random.Range(0, chipPrefaps.Length)], SpawnOfSet(), Quaternion.identity, transform);
                newChip.transform.localScale = new Vector3(chipSize, chipSize, chipSize);

                chips.Add(newChip);
                yield return new WaitForSeconds(timeIndBetvienSpawn);
            }

        }

        private Vector3 SpawnOfSet()
        {
            Vector3 spawnPotion = chipSpawnPositon.position;
            spawnPotion += new Vector3(Random.Range(0, spawnOffSet), 0, Random.Range(0, spawnOffSet));

            return spawnPotion;
        }

        private void RemoveChips()
        {
            foreach (GameObject chip in chips)
                chip.SetActive(false);
        }

    }
}

