using UnityEngine;
using System.Collections.Generic;
using System.Threading;
using MsgPack;

namespace MLPlayer {
	public class SceneController : MonoBehaviour {

		// singleton
		protected static SceneController instance;
		public static SceneController Instance {
			get {
				if(instance == null) {
					instance = (SceneController) FindObjectOfType(typeof(SceneController));
					if (instance == null) {
						Debug.LogError("An instance of " + typeof(SceneController) + 
						               " is needed in the scene, but there is none.");
					}
				}
				return instance;
			}
		}

		
		string url = "ws://localhost:8765/ws";
		float cycleTimeStepSize = 0.15f;
		float episodeTimeLength = 15.0f;

		[SerializeField] Agent agent;
		[SerializeField] Environment environment;

		WebSocketSharp.WebSocket ws;
		float lastSendTime;
		float episodeStartTime = 0f;
		bool waitingFlag = false;
		public static ManualResetEvent received = new ManualResetEvent(false);

		void OnMassage(string msg) {
			agent.action.Set (msg);
			received.Set();
		}



		void OnCycleUpdateAfterReceivedAction() {
			agent.ResetState ();
		}
		

		public void TimeOver() {
			agent.AddReward (0);
			agent.EndEpisode ();
		}

		void StartNewEpisode() {
			Debug.Log ("StartNewEpisode");
			episodeStartTime = Time.time;

			environment.OnReset ();
			agent.transform.position = new Vector3 (0,0,0);
			agent.StartEpisode ();
		}


		void Start () {
			StartNewEpisode ();
			ws = new WebSocketSharp.WebSocket (url);
			Debug.Log("connecting... " + url);
			ws.Connect ();

			ws.OnMessage += (sender, e) => OnMassage(e.Data);

			// if using binary 
			//ws.OnMessage += (sender, e) => OnMassage(e.RawData);

			lastSendTime = -cycleTimeStepSize;
		}

		void FixedUpdate () {

			if (!ws.IsConnected) {
				Debug.Log("not connected:" + url);
				return;
			}
			
			if (lastSendTime + cycleTimeStepSize <= Time.time) {
				lastSendTime = Time.time;

				if (Time.time - episodeStartTime > episodeTimeLength) {
					TimeOver();
				}
				if (agent.state.endEpisode) {
					StartNewEpisode ();
				}
				agent.UpdateState ();

				var packer = new MsgPack.CompiledPacker();
				byte[] msg = packer.Pack(agent.state);

				received.Reset();
				ws.Send(msg);
				received.WaitOne();

				OnCycleUpdateAfterReceivedAction();
			}
		}

	}
}
