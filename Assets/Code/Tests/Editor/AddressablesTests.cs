using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using UnityEditor.AddressableAssets;
using UnityEditor.AddressableAssets.Settings.GroupSchemas;

namespace AbilityMadness.Code.Tests
{
    public class AddressablesTests
    {
        [TestCaseSource(nameof(AllBundledAssetGroupSchema))]
        public void AddressableAssetGroup_UnityWebRequestForLocalBundles_Should_Be_True(BundledAssetGroupSchema bundledAssetGroupSchema)
        {
            if (bundledAssetGroupSchema == null)
                Assert.Pass();

            bundledAssetGroupSchema.UseUnityWebRequestForLocalBundles.Should().BeTrue();
        }

        public static IEnumerable<BundledAssetGroupSchema> AllBundledAssetGroupSchema()
        {
            var settings = AddressableAssetSettingsDefaultObject.Settings;
            var groups = settings.groups;

            foreach (var group in groups)
            foreach (var schema in group.Schemas)
            {
                if (schema is BundledAssetGroupSchema bundledAssetGroupSchema)
                {
                    yield return bundledAssetGroupSchema;
                }
            }
        }
    }
}
