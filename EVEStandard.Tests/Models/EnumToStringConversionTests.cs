using System;
using System.Text.Json;
using EVEStandard.Enumerations;
using EVEStandard.Models;
using Xunit;

namespace EVEStandard.Models.Tests
{
    public class EnumToStringConversionTests
    {
        [Fact]
        public void Asset_LocationType_DeserializesAsString()
        {
            // Arrange
            var json = @"{""location_type"":""station""}";
            
            // Act
            var asset = JsonSerializer.Deserialize<Asset>(json);
            
            // Assert
            Assert.NotNull(asset);
            Assert.Equal("station", asset.LocationType);
        }

        [Fact]
        public void Asset_LocationType_ToEnum_ConvertsCorrectly()
        {
            // Arrange
            var asset = new Asset { LocationType = "station" };
            
            // Act
            var enumValue = asset.LocationTypeToEnum;
            
            // Assert
            Assert.Equal(LocationTypeEnum.station, enumValue);
        }

        [Fact]
        public void Asset_LocationFlag_ToEnum_ConvertsCorrectly()
        {
            // Arrange
            var asset = new Asset { LocationFlag = "Hangar" };
            
            // Act
            var enumValue = asset.LocationFlagToEnum;
            
            // Assert
            Assert.Equal(Enumerations.LocationFlag.Hangar, enumValue);
        }

        [Fact]
        public void CharacterInfo_Gender_DeserializesAsString()
        {
            // Arrange
            var json = @"{""gender"":""male""}";
            
            // Act
            var characterInfo = JsonSerializer.Deserialize<CharacterInfo>(json);
            
            // Assert
            Assert.NotNull(characterInfo);
            Assert.Equal("male", characterInfo.Gender);
        }

        [Fact]
        public void CharacterInfo_Gender_ToEnum_ConvertsCorrectly()
        {
            // Arrange
            var characterInfo = new CharacterInfo { Gender = "female" };
            
            // Act
            var enumValue = characterInfo.GenderToEnum;
            
            // Assert
            Assert.Equal(GenderEnum.female, enumValue);
        }

        [Fact]
        public void Contract_Availability_ToEnum_ConvertsCorrectly()
        {
            // Arrange
            var contract = new Contract { Availability = "public" };
            
            // Act
            var enumValue = contract.AvailabilityToEnum;
            
            // Assert
            Assert.Equal(Contract.AvailabilityEnum.@public, enumValue);
        }

        [Fact]
        public void Starbase_State_Nullable_ToEnum_HandlesNull()
        {
            // Arrange
            var starbase = new Starbase { State = null };
            
            // Act
            var enumValue = starbase.StateToEnum;
            
            // Assert
            Assert.Null(enumValue);
        }

        [Fact]
        public void Starbase_State_Nullable_ToEnum_ConvertsWhenNotNull()
        {
            // Arrange
            var starbase = new Starbase { State = "online" };
            
            // Act
            var enumValue = starbase.StateToEnum;
            
            // Assert
            Assert.NotNull(enumValue);
            Assert.Equal(Starbase.StateEnum.online, enumValue.Value);
        }

        [Fact]
        public void ToEnum_ThrowsException_ForUnknownValue()
        {
            // Arrange
            var asset = new Asset { LocationType = "unknown_type" };
            
            // Act & Assert
            Assert.Throws<ArgumentException>(() => asset.LocationTypeToEnum);
        }

        [Fact]
        public void Asset_SerializesWithStringValue()
        {
            // Arrange
            var asset = new Asset { LocationType = "station" };
            
            // Act
            var json = JsonSerializer.Serialize(asset);
            
            // Assert
            Assert.Contains("\"location_type\":\"station\"", json);
            Assert.DoesNotContain("ToEnum", json); // ToEnum should not be serialized
        }
    }
}
