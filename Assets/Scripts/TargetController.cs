using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class TargetController : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    public Transform imageTarget;
    private Vector3 myVector;
    public Transform ARCamera;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        /*myVector = new Vector3(ARCamera.position.x + myVector.x, myVector.y, ARCamera.position.z + myVector.z);
        StartCoroutine(positionSync());*/
    }


    // Update is called once per frame
    void Update()
    {
        
        transform.position = new Vector3(imageTarget.position.x, transform.position.y, imageTarget.position.z);
        myVector = transform.position;
    }


    public void setObjectActive(bool _isActive)
    {

        //GetComponent<SpriteRenderer>().enabled = _isActive;
        


        //update the position
        //transform.position = currentPos + vectorImageTarget;
        
        spriteRenderer.enabled = _isActive;
        GetComponent<PhotonView>().RPC("setActiveSync", RpcTarget.AllBuffered, _isActive);
    }

    [PunRPC]
    public void setActiveSync(bool _isActive)
    {

        //transform.position = new Vector3(ARCamera.position.x + myVector.x, myVector.y,  ARCamera.position.z + myVector.z);
        GetComponent<SpriteRenderer>().enabled = _isActive;
    }

    [PunRPC]
    public void setPositionSync(Vector3 newPosition)
    {
        
        transform.position = newPosition;
    }

    public IEnumerator positionSync()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(0.2f);
            GetComponent<PhotonView>().RPC("setPositionSync", RpcTarget.AllBuffered, myVector);

        }
    }
   
}
