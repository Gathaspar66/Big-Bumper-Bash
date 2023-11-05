using UnityEngine;
using System.Collections;
using TMPro;

public class CountdownControllerScript : MonoBehaviour
{
    public int countdownTime;
    public TextMeshProUGUI countdownText;


    public static CountdownControllerScript CountdownController { get; private set; }


    private void Awake()
    {
        if (CountdownController != null && CountdownController != this)
        {
            Destroy(this);
        }
        else
        {
            CountdownController = this;
        }
    }

    void Start()
    {
        StartCoroutine(CountdownToStart());
    }

    public IEnumerator CountdownToStart()
    {
        while (countdownTime > 0)
        {
            countdownText.text = countdownTime.ToString();
            yield return new WaitForSeconds(1f);
            countdownTime--;
        }

        countdownText.text = "GO!!!!";


        GameManager.gameManager.OnRaceStarted();
        yield return new WaitForSeconds(1f);
        countdownText.gameObject.SetActive(false);
    }
}