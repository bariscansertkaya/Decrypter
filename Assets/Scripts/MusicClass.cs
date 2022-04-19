using UnityEngine;

public class MusicClass : MonoBehaviour
{
    private void Awake()
    {

        int numMusicPlayers = FindObjectsOfType<MusicClass>().Length;
        if (numMusicPlayers != 1)
        {
            Destroy(this.gameObject);
        }
        // if more then one music player is in the scene
        //destroy ourselves
        else
        {
            DontDestroyOnLoad(gameObject);
        }

    }
}
