using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }


    public void setObjectActive(bool _isActive)
    {

        GetComponent<SpriteRenderer>().enabled = _isActive;
        GetComponent<PhotonView>().RPC("setActiveSync", RpcTarget.AllBuffered, _isActive);
    }

    [PunRPC]
    public void setActiveSync(bool _isActive)
    {
        GetComponent<SpriteRenderer>().enabled = _isActive;
    }

}
