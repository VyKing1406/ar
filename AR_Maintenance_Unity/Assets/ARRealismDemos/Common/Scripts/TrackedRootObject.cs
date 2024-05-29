using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using TMPro;

public class TrackedRootObject : MonoBehaviour
{
    [SerializeField]
    ARTrackedImageManager m_TrackedImageManager;
    private int stept = 50;


    void Start() {

    }

    void OnEnable() => m_TrackedImageManager.trackedImagesChanged += OnChanged;

    void OnDisable() => m_TrackedImageManager.trackedImagesChanged -= OnChanged;

    void OnChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        // foreach (var newImage in eventArgs.added) {
        //     // Handle added event
        //     if(!DataControler.IsRootReady() && DataControler.IsRootReady() == false) {
        //         DataControler.UpdateRootTransform(newImage.transform);
        //     }
        // }


        foreach (var updatedImage in eventArgs.updated) {
            if(!DataControler.IsRootReady() && DataControler.IsRootReady() == false && stept == 0) {
                DataControler.UpdateRootTransform(updatedImage.transform);
            }
            stept--;
        }


        foreach (var removedImage in eventArgs.removed) {
            // Handle remove image
            // ClearPositionText();
        }
    }

}
