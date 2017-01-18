using UnityEngine;
using System.Collections; 
using UnityEngine.UI;

public class PlayControl : SingletonMonoBehaviour<PlayControl>
{

		public Button play;
		public Button pause;
		public Button step;
		public Button finish;
		public Canvas canvas;

		public void PlayClicked ()
		{
				AgentWorldRun.Instance.Play ();
		}

		public void PauseClicked ()
		{
				AgentWorldRun.Instance.Pause ();
		}

		public void StepClicked ()
		{
				AgentWorldRun.Instance.Step ();
		}

		public void StopClicked ()
		{
				AgentWorldRun.Instance.Stop ();
		}

		void Update ()
		{
				ManageButtons ();
		}

		public void OnShowUI ()
		{
				canvas.enabled = true;
		}

		public void OnHideUI ()
		{
				canvas.enabled = false;
		}

		void ManageButtons ()
		{
				if (!AgentWorldRun.Instance.runner.Running && !AgentWorldRun.Instance.runner.Finished) {
						play.interactable = true;
				} else {
						play.interactable = false;
				}

				if (AgentWorldRun.Instance.runner.Running) {
						pause.interactable = true;
						if (AgentWorldRun.Instance.runner.Paused) {
								pause.GetComponentInChildren<Text> ().text = "Un Pause";
						} else {
								pause.GetComponentInChildren<Text> ().text = "Pause";
						}
				} else {
						pause.interactable = false;
				}

				if (!AgentWorldRun.Instance.runner.Finished) {
						step.interactable = true;
				} else {
						step.interactable = false;
				}

				if (AgentWorldRun.Instance.runner.Running || AgentWorldRun.Instance.runner.Finished || !AgentWorldRun.Instance.runner.Started) {
						finish.interactable = true;
						if (AgentWorldRun.Instance.runner.Finished || !AgentWorldRun.Instance.runner.Started) {
								finish.GetComponentInChildren<Text> ().text = "Rebuild";
						} else {
								finish.GetComponentInChildren<Text> ().text = "Finish";
						}
				} else {
						finish.interactable = false;
				}


		}
	
}
