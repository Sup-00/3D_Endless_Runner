using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class RoadGenerator : MonoBehaviour
{
    [SerializeField] private Road[] _roads;

    private float _spawnPosition = 0;
    private List<Road> _roadsPool;
    private Road _previousRoad;

    private void Start()
    {
        _roadsPool = new List<Road>();
        foreach (var road in _roads)
        {
            _roadsPool.Add(Instantiate(road, transform));
            road.gameObject.SetActive(false);
        }

        PlaceRoad(0);
        PlaceRoad(1);
        PlaceRoad(2);
        PlaceRoad(3);
        PlaceRoad(4);
        PlaceRoad(5);
        PlaceRoad(6);
        PlaceRoad(7);
        PlaceRoad(8);
        PlaceRoad(9);
    }


    private void PlaceRoad(int roadIndex)
    {
        Vector3 spawnPosition;

        if (_previousRoad == null)
            spawnPosition = transform.position;
        else
            spawnPosition = _previousRoad.GetComponentInChildren<Сompound>().transform.position;

        _roadsPool[roadIndex].transform.position = spawnPosition;
        _previousRoad = _roadsPool[roadIndex];
        _roadsPool[roadIndex].gameObject.SetActive(true);
    }
}