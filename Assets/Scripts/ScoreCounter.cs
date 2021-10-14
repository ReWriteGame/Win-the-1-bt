using UnityEngine;
using UnityEngine.Events;


public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private float score = 0;
    [SerializeField] private float maxScore;
    [SerializeField] private float minScore = 0;

    public UnityEvent changeScoreEvent;
    public UnityEvent takeAwayScoreEvent;
    public UnityEvent addScoreEvent;
    public UnityEvent isMinScoreEvent;
    public UnityEvent isMaxScoreEvent;

    public float Score { get => score; private set => score = value; }
    public float MaxScore { get => maxScore; private set => maxScore = value; }
    public float MinScore { get => minScore; private set => minScore = value; }

    public void add(float value)
    {
        if (value < 0) return;
        score = (score + value) >= maxScore ? maxScore : (score + value);

        // Events
        changeScoreEvent?.Invoke();
        addScoreEvent?.Invoke();
        checkIsMax();
        //changeHP?.Invoke(data.HP);
        //healthEvent?.Invoke(health);
    }
    public void takeAway(float value)
    {
        if (value < 0) return;
        score = (score - value) <= minScore ? minScore : (score - value);

        // Events
        changeScoreEvent?.Invoke();
        takeAwayScoreEvent?.Invoke();
        checkIsMin();
        //changeHP?.Invoke(data.HP);
        //damageEvent?.Invoke(health);
    }

    public bool checkIsMin()
    {
        if (score <= minScore) isMinScoreEvent?.Invoke();
        return score <= minScore ? true : false;
    }
    public bool checkIsMax()
    {
        if (score >= maxScore) isMaxScoreEvent?.Invoke();
        return score >= maxScore ? true : false;
    }
}
//todo events/var overhill overdamage
//todo зависимость макс хп от хп при настройке
