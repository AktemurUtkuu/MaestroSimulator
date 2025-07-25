using UnityEngine;
using UnityEngine.SceneManagement;

public class SongSelector : MonoBehaviour
{
    public AudioClip[] songs;

    public void SelectSongAndStart(int index)
    {
        SongManager.Instance.selectedSong = songs[index];
        SceneManager.LoadScene("AG_scence_theatre 1");

    }
    
}

