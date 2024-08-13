using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace AbilityMadness.Code.Tests
{
    [Category(Constants.Root)]
    public class SceneValidationTests
    {
        [SetUp]
        public void SetUp()
        {
            TestContext.CurrentTestExecutionContext.StopOnError = false;
        }

        [TestCaseSource(nameof(AllScenesPaths))]
        public void AllGameObjectsShouldNotHaveMissingScripts(string scenePath)
        {
            UnityEngine.SceneManagement.Scene scene = EditorSceneManager.OpenScene(scenePath, OpenSceneMode.Additive);

            var gameObjectsWithMissingScripts = AllGameObjectsFrom(scene)
                .Where(HasMissingScripts)
                .GroupBy(gameObject => gameObject.name)
                .Select(grouping => $"{grouping.Key} [{grouping.Count()}]")
                .ToList();

            EditorSceneManager.CloseScene(scene, true);

            gameObjectsWithMissingScripts.Should().BeEmpty();
        }

        [TestCaseSource(nameof(AllScenesPaths))]
        public void ScenesShouldNotContainMissingPrefabs(string scenePath)
        {
            UnityEngine.SceneManagement.Scene scene = EditorSceneManager.OpenScene(scenePath, OpenSceneMode.Additive);

            var missingPrefabGameObjects = AllGameObjectsFrom(scene)
                .Where(IsMissingPrefab)
                .GroupBy(gameObject => gameObject.name)
                .Select(grouping => $"{grouping.Key} [{grouping.Count()}]")
                .ToList();

            EditorSceneManager.CloseScene(scene, true);

            missingPrefabGameObjects.Should().BeEmpty();
        }

        public static IEnumerable<string> AllScenesPaths() =>
            AssetDatabase
                .FindAssets("t:Scene", new[] { "Assets" })
                .Select(AssetDatabase.GUIDToAssetPath);

        private static IEnumerable<GameObject> AllGameObjectsFrom(UnityEngine.SceneManagement.Scene scene)
        {
            var rootGameObjects = scene.GetRootGameObjects();
            var gameObjectsQueue = new Queue<GameObject>(rootGameObjects);

            while (gameObjectsQueue.Count > 0)
            {
                GameObject gameObject = gameObjectsQueue.Dequeue();

                yield return gameObject;

                foreach (Transform transform in gameObject.transform)
                    gameObjectsQueue.Enqueue(transform.gameObject);
            }
        }

        private static bool HasMissingScripts(GameObject gameObject) =>
            GameObjectUtility.GetMonoBehavioursWithMissingScriptCount(gameObject) > 0;

        private static bool IsMissingPrefab(GameObject gameObject) =>
            PrefabUtility.GetPrefabAssetType(gameObject) == PrefabAssetType.MissingAsset;
    }
}
