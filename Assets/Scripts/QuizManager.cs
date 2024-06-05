using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class QuizManager : MonoBehaviour
{
    public TextMeshProUGUI questionText;
    public Button trueButton;
    public Button falseButton;
    public QuizData questionData;
    private List<Question> questions;
    private int currentQuestionIndex = 0;

    void Start()
    {
        trueButton.onClick.AddListener(() => CheckAnswer(true));
        falseButton.onClick.AddListener(() => CheckAnswer(false));
        LoadQuestions();
        UpdateQuestion();
    }

    void LoadQuestions()
    {
        if (questionData != null)
        {
            questions = new List<Question>(questionData.questions);
        }
        else
        {
            Debug.LogError("Tidak ada pertanyaan yang ditemukan!");
        }
    }

    void UpdateQuestion()
    {
        if (currentQuestionIndex < questions.Count)
        {
            questionText.text = questions[currentQuestionIndex].question;
        }
        else
        {
            questionText.text = "Pertanyaan Telah Selesai!";
            trueButton.interactable = false;
            falseButton.interactable = false;
        }
    }

    void CheckAnswer(bool answer)
    {
        if (questions[currentQuestionIndex].isTrue == answer)
        {
            ScoreManager.AddScore(1);
        }

        currentQuestionIndex++;
        UpdateQuestion();
    }
}