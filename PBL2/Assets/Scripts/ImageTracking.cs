using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

namespace Scripts
{
    [RequireComponent(typeof(ARTrackedImageManager))]
    public class ImageTracking : MonoBehaviour
    {
        [SerializeField]
        private GameObject[] placeablePrefabs;

        private readonly Dictionary<string, GameObject> _spawnedPrefabs = new();

        private ARTrackedImageManager _arTrackedManager;

        private void Awake()
        {
            _arTrackedManager = FindObjectOfType<ARTrackedImageManager>();

            foreach (var prefab in placeablePrefabs)
            {
                var newPrefab = Instantiate(prefab, Vector3.zero, prefab.transform.rotation);
                newPrefab.name = prefab.name;
                newPrefab.SetActive(false);

                _spawnedPrefabs.Add(prefab.name, newPrefab);
            }
        }

        private void OnEnable()
        {
            _arTrackedManager.trackedImagesChanged += OnImageChanged;
        }

        private void OnDisable()
        {
            _arTrackedManager.trackedImagesChanged -= OnImageChanged;
        }

        private void OnImageChanged(ARTrackedImagesChangedEventArgs args)
        {
            foreach (var trackedImage in args.added)
            {
                UpdateImage(trackedImage);
            }

            foreach (var trackedImage in args.updated)
            {
                if (trackedImage.trackingState == TrackingState.Tracking)
                {
                    UpdateImage(trackedImage);
                }
                else
                {
                    _spawnedPrefabs[trackedImage.referenceImage.name].SetActive(false);
                }
            }
        }

        private void UpdateImage(ARTrackedImage trackedImage)
        {
            var imageName = trackedImage.referenceImage.name;
            var position = trackedImage.transform.position;

            var prefab = _spawnedPrefabs[imageName];
            prefab.transform.position = position;
            prefab.SetActive(true);
        }
    }
}