using Common.PlayerData;
using System;
using TTT;
using TTT.Common.PlayerData;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/PlayerData", order = 90)]
public class PlayerData : ScriptableObject
{
    #region FIELDS

    //public Health health;
    public PlayerQuizResultsSt playerResults;

    public AmmoSO PlayerAmmo;
    private int _QuestionLevel;

    #endregion FIELDS

    #region METHODS

    public void Reset()
    {
        //ResetHealth();
        ResetResults();
        ResetAmmoSO();
    }

    /*    #region HEALTH

        [Tooltip("Resets Health To 0")]
        public void ResetHealth() => health.Reset();

        [Tooltip("Takes Damage of value 'Damage'")]
        public void TakeDamage(int Damage) => health.TakeDamage(Damage);

        [Tooltip("Heals Player With Value 'heal'")]
        public void Heal(int Heal) => health.Heal(Heal);

        [Tooltip("Returns Current Health")]
        public int GetHealth() => health.GetHealth();

        [Tooltip("Returns if Player is Dead")]
        public bool GetIsDead() => health.GetIsDead();

        [Tooltip("Sets Max Health")]
        public void SetMaxHealth(int max) => health.setMaxHealth(max);

        [Tooltip("Kills Player")]
        public void Kill() => health.kill();

        #endregion METHODS
    */

    #region QUIZRESULTS

    [Tooltip("Resets Quiz Results")]
    public void ResetResults() => playerResults.resetQuizResults();

    [Tooltip("Answeres question 'Quest', with answer 'Answer'")]
    public void AnswereQuestion(QuizQuestionSO Quest, int Answer) => playerResults.AnswereQuestion(Quest, Answer);

    [Tooltip("Returns Number of Questions Answered in The Players SO")]
    public int GetNumQuestionsAnswered() => playerResults.GetNumQuestionsAnswered();

    [Tooltip("Sets the Question Level For the current Question")]
    public void SetQuestionLevel(int level) => _QuestionLevel = level;

    [Tooltip("Returns the Question Level For the current Question")]
    public int GetQuestionLevel() => _QuestionLevel;

    #endregion QUIZRESULTS

    #region AMMO

    public void ResetAmmoSO()
    {
        PlayerAmmo.resetBulletTypes();
        PlayerAmmo.resetAmmo();
    }

    #endregion AMMO

    #endregion METHODS
}