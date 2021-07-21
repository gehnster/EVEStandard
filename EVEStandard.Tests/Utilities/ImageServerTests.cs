using Xunit;

namespace EVEStandard.Utilities.Tests
{

    public class ImageServerTests
    {
        [Theory]
        [InlineData(434243723, ImageServer.AllianceWidth.x32, "https://images.evetech.net/alliances/434243723/logo?size=32")]
        [InlineData(434243723, ImageServer.AllianceWidth.x64, "https://images.evetech.net/alliances/434243723/logo?size=64")]
        [InlineData(434243723, ImageServer.AllianceWidth.x128, "https://images.evetech.net/alliances/434243723/logo?size=128")]
        public void AllianceImageURLTest(int id, ImageServer.AllianceWidth width, string expected)
        {
            Assert.Equal(expected, ImageServer.AllianceImageURL(id, width));
        }

        [Theory]
        [InlineData(109299958, ImageServer.CorporationWidth.x32, "https://images.evetech.net/corporations/109299958/logo?size=32")]
        [InlineData(109299958, ImageServer.CorporationWidth.x64, "https://images.evetech.net/corporations/109299958/logo?size=64")]
        [InlineData(109299958, ImageServer.CorporationWidth.x128, "https://images.evetech.net/corporations/109299958/logo?size=128")]
        [InlineData(109299958, ImageServer.CorporationWidth.x256, "https://images.evetech.net/corporations/109299958/logo?size=256")]
        public void CorporationImageURLTest(int id, ImageServer.CorporationWidth width, string expected)
        {
            Assert.Equal(expected, ImageServer.CorporationImageURL(id, width));
        }

        [Theory]
        [InlineData(1338057886, ImageServer.CharacterWidth.x32, "https://images.evetech.net/characters/1338057886/portrait?size=32")]
        [InlineData(1338057886, ImageServer.CharacterWidth.x64, "https://images.evetech.net/characters/1338057886/portrait?size=64")]
        [InlineData(1338057886, ImageServer.CharacterWidth.x128, "https://images.evetech.net/characters/1338057886/portrait?size=128")]
        [InlineData(1338057886, ImageServer.CharacterWidth.x256, "https://images.evetech.net/characters/1338057886/portrait?size=256")]
        [InlineData(1338057886, ImageServer.CharacterWidth.x512, "https://images.evetech.net/characters/1338057886/portrait?size=512")]
        [InlineData(1338057886, ImageServer.CharacterWidth.x1024, "https://images.evetech.net/characters/1338057886/portrait?size=1024")]
        public void CharacterImageURLTest(int id, ImageServer.CharacterWidth width, string expected)
        {
            Assert.Equal(expected, ImageServer.CharacterImageURL(id, width));
        }

        [Theory]
        [InlineData(434243723, ImageServer.FactionWidth.x32, "https://images.evetech.net/alliances/434243723/logo?size=32")]
        [InlineData(434243723, ImageServer.FactionWidth.x64, "https://images.evetech.net/alliances/434243723/logo?size=64")]
        [InlineData(434243723, ImageServer.FactionWidth.x128, "https://images.evetech.net/alliances/434243723/logo?size=128")]
        public void FactionImageURLTest(int id, ImageServer.FactionWidth width, string expected)
        {
            Assert.Equal(expected, ImageServer.FactionImageURL(id, width));
        }

        [Theory]
        [InlineData(587, ImageServer.InventoryTypesWidth.x32, "https://images.evetech.net/types/587/icon?size=32")]
        [InlineData(587, ImageServer.InventoryTypesWidth.x64, "https://images.evetech.net/types/587/icon?size=64")]
        public void InventoryImageURLTest(int id, ImageServer.InventoryTypesWidth width, string expected)
        {
            Assert.Equal(expected, ImageServer.InventoryImageURL(id, width));
        }

        [Theory]
        [InlineData(587, ImageServer.ShipAndDroneRendersWidth.x32, "https://images.evetech.net/types/587/render?size=32")]
        [InlineData(587, ImageServer.ShipAndDroneRendersWidth.x64, "https://images.evetech.net/types/587/render?size=64")]
        [InlineData(587, ImageServer.ShipAndDroneRendersWidth.x128, "https://images.evetech.net/types/587/render?size=128")]
        [InlineData(587, ImageServer.ShipAndDroneRendersWidth.x256, "https://images.evetech.net/types/587/render?size=256")]
        [InlineData(587, ImageServer.ShipAndDroneRendersWidth.x512, "https://images.evetech.net/types/587/render?size=512")]
        public void ShipAndDroneRenderImageURLTest(int id, ImageServer.ShipAndDroneRendersWidth width, string expected)
        {
            Assert.Equal(expected, ImageServer.ShipAndDroneRenderImageURL(id, width));
        }
    }
}