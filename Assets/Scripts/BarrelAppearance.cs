using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class BarrelAppearance : MonoBehaviour
{
    public BarrelSkin[] barrelSkin;
    public BarrelSkin skin;

    [PunRPC]
    public void SetColor(int order)
    {
        if (skin) Destroy(skin.gameObject);

        skin = Instantiate<BarrelSkin>(barrelSkin[order]);
        skin.transform.parent = transform;
        skin.transform.localPosition = Vector3.zero;
    }
}
