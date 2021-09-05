using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoadGenerator : MonoBehaviour
{
    [SerializeField] private CoinPool _coinPool;
    [SerializeField] [Range(3, 7)] private int _renderDistance;
    [SerializeField] private Road[] _roads;

    private List<Road> _roadsPool;
    private Road _previousRoad;
    private Queue<Road> _roadQueue;
    private Queue<Coin> _coinQueue;

    private void Start()
    {
        _coinQueue = new Queue<Coin>();
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

    public void HideRoad()
    {
        HideCoins(_roadQueue.Peek());
        _roadQueue.Peek().gameObject.SetActive(false);
        _roadQueue.Dequeue();
        ChooseRoad();
    }

    private void HideCoins(Road road)
    {
        int Count = road.GetComponentInChildren<CoinSpawnPoint>().SpawnPoints.Length;

        for (int i = 0; i < Count; i++)
        {
            if (_coinQueue.Any())
            {
                _coinQueue.Peek().gameObject.SetActive(false);
                _coinQueue.Peek().ActiveBooster(false);
                _coinQueue.Dequeue();
            }
        }
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

        PlaceCoins(roadIndex);
    }

    private void PlaceCoins(int roadIndex)
    {
        SpawnPoint[] CoinSpawnPoints = _roadsPool[roadIndex].GetComponentInChildren<CoinSpawnPoint>().SpawnPoints;
        for (int i = 0; i < CoinSpawnPoints.Length; i++)
        {
            Coin coin = _coinPool.GetCoin();
            if (coin != null)
            {
                _coinQueue.Enqueue(coin);
                coin.transform.position = CoinSpawnPoints[i].transform.position;
                coin.gameObject.SetActive(true);
            }
        }
    }

    private void ChooseRoad()
    {
        int roadIndex = UnityEngine.Random.Range(0, _roadsPool.Count);

        if (_roadsPool[roadIndex].gameObject.activeSelf)
            ChooseRoad();
        else
            PlaceRoad(roadIndex);
    }
}