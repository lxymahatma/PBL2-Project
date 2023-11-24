using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

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
                var newPrefab = Instantiate(prefab, Vector3.zero, Quaternion.identity);
                newPrefab.name = prefab.name;
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
                UpdateImage(trackedImage);
            }

            foreach (var trackedImage in args.removed)
            {
                _spawnedPrefabs[trackedImage.name].SetActive(false);
            }
        }

        private void UpdateImage(ARTrackedImage trackedImage)
        {
            var imageName = trackedImage.referenceImage.name;
            var position = trackedImage.transform.position;

            var prefab = _spawnedPrefabs[imageName];
            prefab.transform.position = position;
            prefab.SetActive(true);

            foreach (var go in _spawnedPrefabs.Values.Where(go => go.name != imageName))
            {
                go.SetActive(false);
            }
        }
    }
}