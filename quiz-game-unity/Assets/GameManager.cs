using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour {
	public Question[] questions;
	private static List<Question> unansweredQuestions;
	private Question currentQuestion;


	[SerializeField]
	private Text factText;

	[SerializeField]
	private float timeBetweenQuestions=1f;

	[SerializeField]
	private Text trueAnswer;

	[SerializeField]
	private Text falseAnswer;

	[SerializeField]
	private Animator animator;
	void Start(){
		//this.falseAnswer.enabled = false;
		//this.trueAnswer.enabled = false;
		if (unansweredQuestions==null || unansweredQuestions.Count==0) {
			unansweredQuestions = questions.ToList<Question> ();
		}
		GetRandomQuestion ();
	}

	void GetRandomQuestion(){
		int randomQuestionsIndex = Random.Range (0, unansweredQuestions.Count);
		currentQuestion = unansweredQuestions [randomQuestionsIndex];
		factText.text = currentQuestion.fact;

		if (currentQuestion.isTrue) {
			this.trueAnswer.text = "Correct";
			this.falseAnswer.text = "Wrong";
		} else {
			this.trueAnswer.text = "Wrong";
			this.falseAnswer.text = "Correct";
		}

	}
	IEnumerator TransitionToNextQuestion(){
		unansweredQuestions.Remove (currentQuestion);
		yield return new WaitForSeconds (timeBetweenQuestions);
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}
	public void UserSelectIsTrue(){
		animator.SetTrigger ("False");
		//this.trueAnswer.enabled = true;
		if (currentQuestion.isTrue) {
			
		} else {
		}
		StartCoroutine (TransitionToNextQuestion());
	
	}
	public void UserSelectIsFalse(){
		animator.SetTrigger ("True");
		//this.falseAnswer.enabled = true;

		if (!currentQuestion.isTrue) {

		} else {
		}
		StartCoroutine (TransitionToNextQuestion());

	}
}
