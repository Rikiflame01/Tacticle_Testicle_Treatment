using UnityEngine;
using UnityEditor;
using ScriptableObjects;

public class CreateQuestion : EditorWindow
{
    public GameDataSO gameDataSO;
    private string question;
    private string[] answers = new string[4];
    private bool[] IsCorrect = new bool[4];
    private int QuestionLevel;

    [MenuItem("Tools/Create Question %q")]
    public static void ShowWindow()
    {
        GetWindow<CreateQuestion>("Create Question");
    }

    private void OnGUI()
    {
        GUILayout.Label("Make a Question.", EditorStyles.boldLabel);
        question = EditorGUILayout.TextField("Question Text", question, GUILayout.ExpandHeight(true), GUILayout.MaxHeight(200));
        GUILayout.Label("---------------------------------------------------", EditorStyles.boldLabel);
        GUILayout.Label("Question Level: ", EditorStyles.boldLabel);
        QuestionLevel = EditorGUILayout.IntSlider(QuestionLevel, 1, 10);
        GUILayout.Label("---------------------------------------------------", EditorStyles.boldLabel);
        EditorGUILayout.BeginVertical();
        {
            EditorGUILayout.BeginVertical();
            {
                GUILayout.Label("Answer 1", EditorStyles.boldLabel);
                answers[0] = EditorGUILayout.TextField("Answer Text", answers[0], GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true), GUILayout.MaxHeight(100));
                IsCorrect[0] = EditorGUILayout.Toggle("Is Correct", IsCorrect[0]);
                GUILayout.Label("--------------------------------", EditorStyles.boldLabel);
            }
            EditorGUILayout.EndVertical();

            EditorGUILayout.BeginVertical();
            {
                GUILayout.Label("Answer 2", EditorStyles.boldLabel);
                answers[1] = EditorGUILayout.TextField("Answer Text", answers[1], GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true), GUILayout.MaxHeight(100));
                IsCorrect[1] = EditorGUILayout.Toggle("Is Correct", IsCorrect[1]);
                GUILayout.Label("--------------------------------", EditorStyles.boldLabel);
            }
            EditorGUILayout.EndVertical();

            EditorGUILayout.BeginVertical();
            {
                GUILayout.Label("Answer 3", EditorStyles.boldLabel);
                answers[2] = EditorGUILayout.TextField("Answer Text", answers[2], GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true), GUILayout.MaxHeight(100));
                IsCorrect[2] = EditorGUILayout.Toggle("Is Correct", IsCorrect[2]);
                GUILayout.Label("--------------------------------", EditorStyles.boldLabel);
            }
            EditorGUILayout.EndVertical();

            EditorGUILayout.BeginVertical();
            {
                GUILayout.Label("Answer 4", EditorStyles.boldLabel);
                answers[3] = EditorGUILayout.TextField("Answer Text", answers[3], GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true), GUILayout.MaxHeight(100));
                IsCorrect[3] = EditorGUILayout.Toggle("Is Correct", IsCorrect[3]);
                GUILayout.Label("--------------------------------", EditorStyles.boldLabel);
            }
            EditorGUILayout.EndVertical();
        }
        EditorGUILayout.EndVertical();

        if (GUILayout.Button("Create Question"))
        {
            CreateQuestionSO();
        }
        if (GUILayout.Button("Reset Questions"))
        {
            gameDataSO.ResetQuestions();
        }
    }

    private void CreateQuestionSO()
    {
        QuestionAnswerSt[] questionAnswerSts = new QuestionAnswerSt[4];
        Debug.Log("Creating answer array");
        for (int i = 0; i < 4; i++)
        {
            questionAnswerSts[i] = new QuestionAnswerSt(answers[i], IsCorrect[i]);
            Debug.Log("Answer: " + i);
        }
        var questionSO = ScriptableObject.CreateInstance<QuizQuestionSO>();
        Debug.Log("Made Temp QuestionSO");
        questionSO.SetQuestionText(question);
        Debug.Log("Set Question Text");
        questionSO.SetQuestionAnswers(questionAnswerSts);
        Debug.Log("Set Question Answers with made array");
        questionSO.SetQuestionLevel(QuestionLevel);
        Debug.Log("Set Question Level");
        questionSO.SetQuestionIndex(gameDataSO.GetQuestionIndex());
        Debug.Log("Set Question Index");
        gameDataSO.AddQusetionToArray(questionSO);
        Debug.Log("Added Question game data to Array");
        gameDataSO.IncrementQuestionIndex();
        Debug.Log("Incremented Question Index");

        AssetDatabase.CreateAsset(questionSO, AssetDatabase.GenerateUniqueAssetPath("Assets/Scriptable Objects/Questions/QuizQuestion_.asset"));
        Debug.Log("Make asset");
        AssetDatabase.SaveAssets();
        Debug.Log("Save asset");

        EditorUtility.FocusProjectWindow();
        Selection.activeObject = questionSO;
    }
}