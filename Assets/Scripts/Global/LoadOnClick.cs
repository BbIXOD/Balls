using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadOnClick : MonoBehaviour
{
    [SerializeField]private string scene;
    
    public void Load()
    {
        SceneManager.LoadScene(scene);
    }
}
