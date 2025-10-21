using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Light))]
public class WFX_LightFlicker : MonoBehaviour
{
	public float time = 0.05f;

	private float timer;

	private void Start()
	{
		timer = time;
		StartCoroutine("Flicker");
	}

	private IEnumerator Flicker()
	{
		while (true)
		{
			base.get_light().enabled = !base.get_light().enabled;
			do
			{
				timer -= Time.deltaTime;
				yield return null;
			}
			while (timer > 0f);
			timer = time;
		}
	}
}
