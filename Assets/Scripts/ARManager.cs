using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Vuforia;

public class ARManager : MonoBehaviour
{
    private void Awake()
    {
        //foreach (GameObject _go in GameObject.FindGameObjectsWithTag("MainCamera"))
        //{
        //    if (_go.transform.name != "ARCamera")
        //    {
        //        Destroy(_go);
        //    }
        //}
    }


    void Start()
    {
        StartCoroutine(CamCheck());
    }
    public GameObject ArCam;
    private IEnumerator CamCheck()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(0.2f);
            //foreach (GameObject _go in GameObject.FindGameObjectsWithTag("MainCamera"))
            //{
            //    if (_go.transform.name != "ARCamera")
            //    {
            //        Destroy(_go);
            //    }
            //}
            ArCam.SetActive(true);
        }
    }
}
