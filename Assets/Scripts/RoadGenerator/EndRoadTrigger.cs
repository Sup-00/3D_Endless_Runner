using UnityEngine;

public class EndRoadTrigger : MonoBehaviour
{
    private RoadGenerator _roadGenerator;

    private void Start()
    {
        _roadGenerator = FindObjectOfType<RoadGenerator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Moving>())
            _roadGenerator.HideRoad();
    }
}