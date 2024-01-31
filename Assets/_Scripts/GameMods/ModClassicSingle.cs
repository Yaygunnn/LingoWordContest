using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModClassicSingle : MonoBehaviour
{
    public static ModClassicSingle Instance { get; private set; }

    private ClassicSingleModel model = new ClassicSingleModel();

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
