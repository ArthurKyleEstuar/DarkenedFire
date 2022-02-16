using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkenedFireValidator : MonoBehaviour
{
    [SerializeField] private List<GameObject> dots = new List<GameObject>();
    [SerializeField] private GameObject failScreen;
    [SerializeField] private GameObject winScreen;
    [SerializeField] private float selectionTimer = 3f;

    private int currIndex;
    private void Start()
    {
        StartCoroutine(RandomLoopCR());
    }

    private IEnumerator RandomLoopCR()
    {
        currIndex = Random.Range(0, dots.Count);

        dots.ForEach(x => x.SetActive(dots.IndexOf(x) == currIndex));

        yield return new WaitForSeconds(selectionTimer);

        failScreen.SetActive(true);
    }

    public void Retry()
    {
        StartCoroutine(RandomLoopCR());
    }

    public void OnReceiveInput(int selectedWaymark)
    {
        int correctAnswer = currIndex + 1;

        if (correctAnswer > 4)
            correctAnswer -= 4;

        failScreen.SetActive(selectedWaymark != correctAnswer);
        winScreen.SetActive(selectedWaymark == correctAnswer);
        StopAllCoroutines();
    }

}
