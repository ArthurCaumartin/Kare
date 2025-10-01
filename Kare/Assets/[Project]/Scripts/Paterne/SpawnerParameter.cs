using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public class SpawnerParameter
{
    [SerializeField] private float _spawnDelay = 1;
    [SerializeField] private int _paternePerSpawn = 1;
    [SerializeField] private List<Paterne> _paternePrefabList = new List<Paterne>();

    public float SpawnDelay => _spawnDelay;
    public int PaternePerSpawn => _paternePerSpawn;

    public Paterne GetRandomPaterne()
    {
        return _paternePrefabList[Random.Range(0, _paternePrefabList.Count)];
    }
}