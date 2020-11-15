using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharedParam : MonoBehaviour
{
    private int broj;

   public int GetBroj()
    {
        return broj;

    }

    public void SetBroj(int b)
    {
        this.broj = b;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
