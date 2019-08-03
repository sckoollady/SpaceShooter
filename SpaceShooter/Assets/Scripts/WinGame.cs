using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinGame : MonoBehaviour
{
    public GameObject otherGameObject;
    public GameObject StarField;
    private BGScroller bGScroller;
    private GameController gameController;
    
    // Start is called before the first frame update
    void Start()
    {
        bGScroller = GetComponent<BGScroller>();
        gameController = otherGameObject.GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameController.winGame == true)
        {
          bGScroller.scrollSpeed = bGScroller.scrollSpeed + 5;
          DestroyGameObject();
        }
    }

    void DestroyGameObject()
    {
        Destroy(StarField);
    }
}
