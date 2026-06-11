using System.Text.Json;
using EVEStandard.Models;
using Xunit;

namespace EVEStandard.Models.Tests
{
    /// <summary>
    /// Deserialization tests for the Cradle of War (2026-06-09) additions to GET /characters/{character_id}:
    /// the renamed corporation_title field and the new character_title_id and achievement_score fields.
    /// </summary>
    public class CharacterTitlesTests
    {
        [Fact]
        public void CharacterInfo_AtCradleOfWarCompatDate_DeserializesNewTitleAndAchievementFields()
        {
            var json = @"{
                ""name"": ""Some Capsuleer"",
                ""corporation_id"": 98000001,
                ""birthday"": ""2010-01-01T00:00:00Z"",
                ""bloodline_id"": 1,
                ""race_id"": 1,
                ""corporation_title"": ""Chief Executive Officer"",
                ""character_title_id"": ""3f2504e0-4f89-41d3-9a0c-0305e82c3301"",
                ""achievement_score"": 12345
            }";

            var info = JsonSerializer.Deserialize<CharacterInfo>(json);

            Assert.NotNull(info);
            Assert.Equal("Chief Executive Officer", info.CorporationTitle);
            Assert.Equal("3f2504e0-4f89-41d3-9a0c-0305e82c3301", info.CharacterTitleId);
            Assert.Equal(12345, info.AchievementScore);
        }

        [Fact]
        public void CharacterInfo_AtOlderCompatDate_NewFieldsAreNull()
        {
            // Prior to 2026-06-09 the response carries "title"; the new fields are absent and stay null.
            var json = @"{
                ""name"": ""Some Capsuleer"",
                ""corporation_id"": 98000001,
                ""birthday"": ""2010-01-01T00:00:00Z"",
                ""bloodline_id"": 1,
                ""race_id"": 1,
                ""title"": ""Old Style Title""
            }";

            var info = JsonSerializer.Deserialize<CharacterInfo>(json);

            Assert.NotNull(info);
#pragma warning disable CS0618 // Title is intentionally exercised here for backwards-compat coverage
            Assert.Equal("Old Style Title", info.Title);
#pragma warning restore CS0618
            Assert.Null(info.CorporationTitle);
            Assert.Null(info.CharacterTitleId);
            Assert.Null(info.AchievementScore);
        }
    }
}
