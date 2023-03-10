using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
//using UnityEngine.UIElements;

public class CanvasController : MonoBehaviour
{
	[SerializeField] private GameObject fadePanel;
	[SerializeField] private GameObject pausePanel;
	[SerializeField] private Color32 defaultTextColor = new Color32(0, 138, 255, 255);
	[SerializeField] private Color32 activeTextColor = new Color32(255, 0, 0, 255);
	[SerializeField] private Slider playerHealthBar;
	[SerializeField] private PlayerHealth playerHealth;
	[SerializeField] private TextMeshProUGUI ScoreText;

	[SerializeField] private TextMeshProUGUI[] skillTexts;
	[SerializeField] private Slider[] skillCoolDowns;
	[SerializeField] private Image[] skillCooldownFill;

	private Button button;
	private TextMeshProUGUI buttonText;
	private Animator animator;

	

	private void Start()
	{
		playerHealthBar.maxValue = playerHealth.Health;
		playerHealthBar.value = playerHealth.Health;
		ScoreText.color = defaultTextColor;
		UpdateTextColor();
		//animator = fadePanel.GetComponent<Animator>();
	}

	private void Update()
	{
		ScoreText.text = GameController.instance.Score.ToString();
		if (GameController.instance.isPaused) {
			pausePanel.SetActive(true);
		}
		else {
			pausePanel.SetActive(false);
		}
	}

	public void UpdateTextColor()
	{		
		for (int i = 0; i < skillTexts.Length; i++) {
			if (i == GameController.instance.ActiveSkillIndex) {
				skillTexts[i].color = activeTextColor;
				skillCooldownFill[i].color = activeTextColor;
			}
			else {
				skillTexts[i].color = defaultTextColor;
				skillCooldownFill[i].color = Color.white;
			}
		}
	}

	public void SetSkillImages(int index, Sprite sprite) {
		skillTexts[index].GetComponentInParent<Image>().sprite = sprite;
	}

	public void SetCoolDownTime(int index, float coolDownTime) {
		skillCoolDowns[index].maxValue = coolDownTime;
		skillCoolDowns[index].value = coolDownTime;
	}

	public void CoolDownTimer(float timeRemaining, float skillCoolDown, int index) {
		if (timeRemaining < skillCoolDown) {
			skillCoolDowns[index].value = timeRemaining;
		}
	}

	public void UpdateHealthBar() {
		playerHealthBar.value = playerHealth.Health;
	}

	public void MainMenu()
	{
		//animator.SetBool("FadeOut", true);
		LevelManager.instance.LoadLevel(0, 0);
	}

	//public void StartNewGame() {
	//	animator.SetBool("FadeOut", true);
	//	LevelManager.instance.StartNewGame();
	//}

	//public void ContinueGame() {
	//	animator.SetBool("FadeOut", true);
	//	LevelManager.instance.Continue();
	//}

	public void Options()
	{
		animator.SetBool("FadeOut", true);
		LevelManager.instance.LoadLevel(1, .9f);
	}

	public void QuitGame()
	{
		LevelManager.instance.QuitRequest();
	}
}
