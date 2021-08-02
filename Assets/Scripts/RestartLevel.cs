using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevel : MonoBehaviour
{
    [SerializeField] private SceneAsset _scene;
    
    public void Restart()
    {
        SceneManager.LoadScene(_scene.name);
    }
}
