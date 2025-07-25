using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class CountdownAndPlay : MonoBehaviour
{
    public TMP_Text countdownText;
    public AudioSource audioSource;

    void Start()
    {
        StartCoroutine(CountdownThenPlay());
    }


    IEnumerator CountdownThenPlay()
    {
        if (SongManager.Instance.selectedSong == null)
        {
            Debug.LogError("Se�ilen �ark� bo�! SongManager.Instance.selectedSong null.");
            yield break;
        }

        countdownText.gameObject.SetActive(true);

        int count = 3;  // Geri say�m ba�lang�c�

        while (count > 0)
        {
            countdownText.text = count.ToString();  // Ekrana yazd�r
            yield return new WaitForSeconds(1f);
            count--;
        }

        countdownText.text = "Ba�la!";
        yield return new WaitForSeconds(1f);
        countdownText.gameObject.SetActive(false);

        audioSource.clip = SongManager.Instance.selectedSong;
        audioSource.Play();
    }

}
