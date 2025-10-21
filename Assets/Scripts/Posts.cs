using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

[Serializable]
public class Posts
{
	public string title;

	public string msg;

	public DateTime date;

	public int comments;

	public string imageUrl;

	public Texture2D image;

	public string id;

	public IEnumerator Load()
	{
		if (!string.IsNullOrEmpty(imageUrl))
		{
			UnityWebRequest w = UnityWebRequestTexture.GetTexture(imageUrl);
			yield return w.SendWebRequest();
			if (w.result != UnityWebRequest.Result.Success)
			{
				Debug.LogError(w.error);
			}
			else
			{
				image = ((DownloadHandlerTexture)w.downloadHandler).texture;
			}
		}
	}
}
