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
    private bool firstRotation = false;
    private bool syncAnother = false;
    public Transform currRotation;
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

    public void setObjectRotation(bool _isActive)
    {
      /*  if(firstRotation == false)
        {
            currRotation.rotation = transform.rotation;
            firstRotation = true;
        }
        else
        {
            transform.rotation = currRotation.rotation;
        }*/
        /*if (_isActive)
        {
            firstRotation.rotation = transform.rotation;
            //transform.eulerAngles = new Vector3(90f, 90f, 0f);
            //transform.SetPositionAndRotation(transform.position, Quaternion.Euler(90f, 90f, 0f));
            Debug.LogWarning("Image taget " + imageTarget.rotation.x + " " + imageTarget.rotation.y + " " + imageTarget.rotation.z);
            Debug.LogWarning("Spirte " + transform.rotation.x + " " + transform.rotation.y + " " + transform.rotation.z);

            //imageTarget.transform.SetPositionAndRotation(imageTarget.position, Quaternion.Euler(90f, 90f, 0f));
            //imageTarget.transform.RotateAround(new Vector3(0f, 0f, 0f), new Vector3(0f, 1f, 0f), 90);
            //transform.RotateAround(new Vector3(0f, 0f, 0f), new Vector3(0f, 1f, 0f), 90);

        }*/
        

    }


    public void setObjectActive(bool _isActive)
    {

        //GetComponent<SpriteRenderer>().enabled = _isActive;



        //update the position
        //transform.position = currentPos + vectorImageTarget;
        //transform.rotation = Quaternion.Euler(90f, 90f, 0f);
        spriteRenderer.enabled = _isActive;
        GetComponent<PhotonView>().RPC("setActiveSync", RpcTarget.AllBuffered, _isActive);
    }

    [PunRPC]
    public void setActiveSync(bool _isActive)
    {
        
       /* Debug.LogWarning("USAO");
        if (!firstRotation)
        {
            Debug.LogWarning("PRVA ROTACIJA");

            currRotation.rotation = transform.rotation;
            Debug.LogWarning(currRotation.rotation);
            firstRotation = true;
          
        }else
        {
            Debug.LogWarning("OSTALE ROTACIJE");
            transform.rotation = currRotation.rotation;
            Debug.LogWarning(transform.rotation);
        }*/
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
