using System;
using System.Collections.Generic;
using UnityEngine;

public class PaterneSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [Space]
    [SerializeField] private List<SpawnerParameter> _parametreList = new List<SpawnerParameter>();
    private float _timer;
    private Camera mainCamera;
    private int _currentLevel = 0;

    private void Start()
    {
        mainCamera = Camera.main;
        _timer = _parametreList[_currentLevel].SpawnDelay;

        GameManager.Instance.OnLevelChanged += SetLevel;
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= _parametreList[_currentLevel].SpawnDelay)
        {
            SpawnRandomPaterne();
            _timer = 0f;
        }
    }

    private void SpawnRandomPaterne()
    {
        for (int i = 0; i < _parametreList[_currentLevel].PaternePerSpawn; i++)
        {
            Paterne selectedPaterne = Instantiate(_parametreList[_currentLevel].GetRandomPaterne(), transform);
            selectedPaterne.Init(mainCamera, _player);
        }
    }

    private void SetLevel(int level)
    {
        _currentLevel = level;
    }
}
