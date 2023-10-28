using Common.PlayerData;
using System;
using TTT.Common.PlayerData;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/PlayerData", order = 90)]
public class PlayerData : ScriptableObject
{
    #region FIELDS

    public Health health;
    public PlayerQuizResultsSt playerResults;

    #endregion FIELDS

    #region METHODS

    public void Reset()
    {
        ResetHealth();
        ResetResults();
    }

    #region HEALTH

    public void ResetHealth() => health.Reset();

    public void TakeDamage(int Damage) => health.TakeDamage(Damage);

    public void Heal(int Heal) => health.Heal(Heal);

    public int GetHealth() => health.GetHealth();

    public bool GetIsDead() => health.GetIsDead();

    public void SetMaxHealth(int max) => health.setMaxHealth(max);

    public void Kill() => health.kill();

    #endregion HEALTH

    #region QUIZRESULTS

    public void ResetResults() => playerResults.resetQuizResults();

    public void AnswereQuestion(QuizQuestionSO Quest, int Answer) => playerResults.AnswereQuestion(Quest, Answer);

    public int GetNumQuestionsAnswered() => playerResults.GetNumQuestionsAnswered();

    #endregion QUIZRESULTS

    #endregion METHODS
}