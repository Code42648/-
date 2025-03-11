using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "3")
            GetComponent<AudioSource>().mute = true;
        else
            GetComponent<AudioSource>().mute = false;
    }

    void Destroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}