using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MiObjeto : MonoBehaviour
{
	public string txtimagen;

	public string txtnombre;

	public string txtgenero;

	public GameObject objfoto;

	public TextMesh objnombre;

	public GameObject objgenero;

	public List<Texture2D> genero;

	private void Start()
	{
		StartCoroutine(getImage(txtimagen));
		objnombre.text = txtnombre;
		objgenero.get_renderer().material.mainTexture = genero[2];
		if (txtgenero == "m")
		{
			objgenero.get_renderer().material.mainTexture = genero[0];
		}
		if (txtgenero == "f")
		{
			objgenero.get_renderer().material.mainTexture = genero[1];
		}
	}

	public IEnumerator getImage(string imageURL)
	{
		UnityWebRequest www = UnityWebRequestTexture.GetTexture(imageURL);
		yield return www.SendWebRequest();
		if (www.result != UnityWebRequest.Result.Success)
		{
			Debug.LogError(www.error);
		}
		else
		{
			Texture2D foto = ((DownloadHandlerTexture)www.downloadHandler).texture;
			objfoto.get_renderer().material.mainTexture = foto;
		}
	}
}
