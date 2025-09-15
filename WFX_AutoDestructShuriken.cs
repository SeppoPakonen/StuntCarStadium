using System.Collections;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class WFX_AutoDestructShuriken : MonoBehaviour
{
	public bool OnlyDeactivate;

	private void OnEnable()
	{
		StartCoroutine("CheckIfAlive");
	}

	private IEnumerator CheckIfAlive()
	{
		do
		{
			yield return new WaitForSeconds(0.5f);
		}
		while (base.get_particleSystem().IsAlive(withChildren: true));
		if (OnlyDeactivate)
		{
			base.gameObject.SetActive(value: false);
		}
		else
		{
			Object.Destroy(base.gameObject);
		}
	}
}
