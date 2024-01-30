using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartFinishPad : MonoBehaviour
{
    [SerializeField] private CanvasGroup startCanvas;
    [SerializeField] private CanvasGroup finishCanvas;
   

    [SerializeField] private PadType padType = PadType.Start;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
            ShowCanvasGroup();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            HideCanvasGroup();
        }
    }
    
    private void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            RestartLevel();
        }
    }

    void ShowCanvasGroup()
    {
        switch (padType)
        {
            case PadType.Start:
                startCanvas.alpha = 1;
                break;
            case PadType.Finish:
                DisableControls();
            
                finishCanvas.alpha = 1;
                break;
        }
    }

    private void DisableControls()
    {
        var mover = FindObjectOfType<Mover>();

        if (mover != null)
        {
            mover.GetComponent<Rigidbody>().velocity = Vector3.zero;

            mover.enabled = false;
        }
    }

   
    void HideCanvasGroup()
    {
        startCanvas.alpha = 0;
        finishCanvas.alpha = 0;
    }

    public void RestartLevel()
    {
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(currentSceneIndex);
    }
    
    
}