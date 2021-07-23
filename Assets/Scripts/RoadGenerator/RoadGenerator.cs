using System.Collections.Generic;
using UnityEngine;

public class RoadGenerator : MonoBehaviour
{
    [SerializeField] [Range(3, 7)] private int _renderDistance;
    [SerializeField] private Road[] _roads;

    private float _spawnPosition = 0;
    private List<Road> _roadsPool;
    private Road _previousRoad;
    private Queue<Road> _roadQueue;

    private void Start()
    {
        _roadQueue = new Queue<Road>();
        _roadsPool = new List<Road>();

        foreach (var road in _roads)
        {
            _roadsPool.Add(Instantiate(road, transform));
            road.gameObject.SetActive(false);
        }

        for (int i = 0; i < _renderDistance; i++)
        {
            ChooseRoad();
        }
    }

    public void DeliteRoad()
    {
        _roadQueue.Peek().gameObject.SetActive(false);
        _roadQueue.Dequeue();
        ChooseRoad();
    }

    private void ChooseRoad()
    {
        int roadIndex = UnityEngine.Random.Range(0, _roadsPool.Count);

        if (_roadsPool[roadIndex].gameObject.activeSelf)
            ChooseRoad();
        else
            PlaceRoad(roadIndex);
    }

    private void PlaceRoad(int roadIndex)
    {
        Vector3 SpawnPosition;

        if (_previousRoad == null)
            SpawnPosition = transform.position;
        else
            SpawnPosition = _previousRoad.GetComponentInChildren<Сompound>().transform.position;

        _roadsPool[roadIndex].transform.position = SpawnPosition;
        _previousRoad = _roadsPool[roadIndex];
        _roadsPool[roadIndex].gameObject.SetActive(true);
        _roadQueue.Enqueue(_roadsPool[roadIndex]);
    }
}