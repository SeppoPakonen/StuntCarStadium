using Photon;
using UnityEngine;
using Photon.Pun;

[RequireComponent(typeof(PhotonView))]
public class OnClickDestroy : Photon.MonoBehaviour
{
	public bool DestroyByRpc;

	private void OnClick()
	{
		if (!DestroyByRpc)
		{
			PhotonNetwork.Destroy(base.gameObject);
		}
		else
		{
			base.photonView.RPC("DestroyRpc", PhotonTargets.AllBuffered);
		}
	}

	[PunRPC]
	public void DestroyRpc()
	{
		Object.Destroy(base.gameObject);
		PhotonNetwork.UnAllocateViewID(base.photonView.viewID);
	}
}
