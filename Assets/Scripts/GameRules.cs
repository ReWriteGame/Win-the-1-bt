using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameRules : MonoBehaviour
{
    [SerializeField] private Timer timer;
    [SerializeField] private ScoreCounter scoreCounter;
    [SerializeField] private Text inputField;


    public void StartGame()
    {
        timer.CurrentTime = 0;
        timer.StartTimer();
        StopGame();
    }




    public void StopGame()
    {
        float randomTime = Random.Range(0, timer.MaxTime);
        StartCoroutine(StopGameCor(randomTime));
    }

    private void CompareResults()
    {
        
        float inputValue = string.IsNullOrEmpty(inputField.text) ? 0 : float.Parse(inputField.text);
        float percentageOfAccuracy = inputValue / timer.CurrentTime;


        if (percentageOfAccuracy > 1) scoreCounter.takeAway(scoreCounter.MaxScore / 3);
        else scoreCounter.add(percentageOfAccuracy * scoreCounter.Score);
    }

    private IEnumerator StopGameCor(float time)
    {
        yield return new WaitForSeconds(time);
        timer.StopTimer();
        yield break;
    }

    private void OnEnable()
    {
        timer.stopTimeEvent.AddListener(CompareResults);
    }
    private void OnDisable()
    {
        timer.stopTimeEvent.RemoveListener(CompareResults);
    }
}
