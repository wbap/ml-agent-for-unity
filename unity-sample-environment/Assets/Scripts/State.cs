using UnityEngine;
using System.Collections;

namespace MLPlayer {
	public class State {
		public float reward;
		public int endEpisode;
		public byte[] image;
		public byte[] depth;
		public void Clear() {
			reward = 0;
			endEpisode = 0;
			image = null;
			depth = null;
		}
	}
}