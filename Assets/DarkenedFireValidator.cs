using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class DarkenedFireValidator : MonoBehaviour
{
    [SerializeField] private List<GameObject> dots = new List<GameObject>();
    [SerializeField] private GameObject failScreen;
    [SerializeField] private GameObject winScreen;
    [SerializeField] private Image timer;
    [SerializeField] private float selectionTime = 3f;

    public UnityEvent onFail;

    private int currIndex;
    private float currTime;
    private void Start()
    {
        Retry();
    }

    bool hasFailed;
    private void Update()
    {
        if (hasFailed) return;

        currTime -= Time.deltaTime;

        if (currTime < 0)
        {
            hasFailed = true;
            onFail?.Invoke();
            failScreen.SetActive(true);
        }

        timer.fillAmount = currTime / selectionTime;
    }

    public void Retry()
    {
        currTime = selectionTime;

        hasFailed = false;

        currIndex = Random.Range(0, dots.Count);

        dots.ForEach(x => x.SetActive(dots.IndexOf(x) == currIndex));
    }

    public void OnReceiveInput(int selectedWaymark)
    {
        int correctAnswer = currIndex + 1;

        if (correctAnswer > 4)
            correctAnswer -= 4;

        failScreen.SetActive(selectedWaymark != correctAnswer);
        winScreen.SetActive(selectedWaymark == correctAnswer);

        if(selectedWaymark == correctAnswer)
        {

        }
        else
        {
            hasFailed = true;
            onFail?.Invoke();
        }
    }

}
