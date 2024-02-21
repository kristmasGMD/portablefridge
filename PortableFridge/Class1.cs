using System;
using UnityEngine;

namespace PortableFriidge
{
	// Token: 0x02000006 RID: 6
	public class Noises : MonoBehaviour
	{
		// Token: 0x06000015 RID: 21 RVA: 0x00002770 File Offset: 0x00000970
		private void Start()
		{
			this.master = GameObject.Find("MasterAudio");
			this.length = this.master.transform.childCount;
			this.player = GameObject.Find("PLAYER");
		}

		// Token: 0x06000016 RID: 22 RVA: 0x000027A8 File Offset: 0x000009A8
		public void PlayRandomSound()
		{
			Transform child = this.master.transform.GetChild(Random.Range(0, this.length));
			int childCount = child.transform.childCount;
			AudioClip clip = child.GetChild(Random.Range(0, childCount)).GetComponent<AudioSource>().clip;
			if (clip.length < 5f)
			{
				GameObject gameObject = GameObject.CreatePrimitive(3);
				gameObject.transform.position = new Vector3(this.player.transform.position.x + (float)Random.Range(-5, 5), this.player.transform.position.y + (float)Random.Range(-5, 5), this.player.transform.position.z + (float)Random.Range(-5, 5));
				gameObject.AddComponent<AudioSource>().clip = clip;
				gameObject.GetComponent<AudioSource>().Play();
				gameObject.GetComponent<AudioSource>().volume = 0.1f;
				Object.Destroy(gameObject.GetComponent<MeshFilter>());
				Object.Destroy(gameObject.GetComponent<BoxCollider>());
				Object.Destroy(gameObject.GetComponent<MeshRenderer>());
				gameObject.AddComponent<NoiseKiller>();
			}
		}

		// Token: 0x06000017 RID: 23 RVA: 0x000028C5 File Offset: 0x00000AC5
		private void Update()
		{
			if (this.time == 0f)
			{
				this.time = Time.time;
			}
			if (Time.time - this.time > 15f)
			{
				this.time = 0f;
				this.PlayRandomSound();
			}
		}

		// Token: 0x0400000C RID: 12
		private GameObject master;

		// Token: 0x0400000D RID: 13
		private int length;

		// Token: 0x0400000E RID: 14
		private GameObject player;

		// Token: 0x0400000F RID: 15
		private float time;
	}
}
