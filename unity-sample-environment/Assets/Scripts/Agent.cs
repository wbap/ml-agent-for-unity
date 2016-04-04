using UnityEngine;
using System.Collections;
using System.IO;
using WebSocketSharp;
using System.Threading;

namespace MLPlayer {
	public class Agent : MonoBehaviour {
		[SerializeField] Camera camera;
		public Action action { set; get; }
		public State state { set; get; }

		public void AddReward (float reward)
		{
			if (state.endEpisode != 0) {
				state.reward += reward;
			}
		}

		public void UpdateState ()
		{
			state.image = GetCameraImage ();
		}
		
		public void ResetState ()
		{
			state.Clear ();
		}

		public void StartEpisode ()
		{
			
		}

		public void EndEpisode ()
		{
			
		}

		public void Start() {
			action = new Action ();
			state = new State ();
		}

		public byte[] GetCameraImage() {
			RenderTexture currentRT = RenderTexture.active;
			RenderTexture.active = camera.targetTexture;
			camera.Render();
			Texture2D image = new Texture2D(camera.targetTexture.width, camera.targetTexture.height,
			                                TextureFormat.RGB24, false);
			image.ReadPixels(new Rect(0, 0, camera.targetTexture.width, camera.targetTexture.height), 0, 0);
			image.Apply();
			RenderTexture.active = currentRT;
			byte[] bytes = image.EncodeToPNG ();
			Destroy (image);

			return bytes;
		}
	}
}