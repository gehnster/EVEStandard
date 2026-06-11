using System.Text.Json;
using EVEStandard.Models;
using Xunit;

namespace EVEStandard.Models.Tests
{
    /// <summary>
    /// Deserialization tests for the Equinox (2026-05-19) sovereignty/structures/access-list models,
    /// with particular focus on the oneOf "tagged union" fields (system claim, workforce transport)
    /// which are flattened to nullable variant properties.
    /// </summary>
    public class EquinoxModelsTests
    {
        [Fact]
        public void SovereigntySystems_WithAllianceAndUnclaimed_DeserializesClaimUnion()
        {
            var json = @"{
                ""solar_systems"": [
                    {
                        ""solar_system_id"": 30000142,
                        ""claim"": {
                            ""alliance"": {
                                ""alliance_id"": 99005338,
                                ""claimed_since"": ""2026-05-19T00:00:00Z"",
                                ""corporation_id"": 98000001,
                                ""is_capital_system"": true,
                                ""development"": {
                                    ""activity_defense_multiplier"": 2.5,
                                    ""industrial_level"": 3,
                                    ""military_level"": 4,
                                    ""strategic_level"": 5
                                },
                                ""sovereignty_hub"": {
                                    ""id"": 1021000000001,
                                    ""vulnerability_window"": { ""start"": ""2026-06-10T18:00:00Z"", ""end"": ""2026-06-10T20:00:00Z"" }
                                }
                            }
                        }
                    },
                    {
                        ""solar_system_id"": 30000143,
                        ""claim"": { ""unclaimed"": true }
                    }
                ]
            }";

            var result = JsonSerializer.Deserialize<SovereigntySystems>(json);

            Assert.NotNull(result);
            Assert.Equal(2, result.SolarSystems.Count);

            var claimed = result.SolarSystems[0];
            Assert.Equal(30000142, claimed.SolarSystemId);
            Assert.NotNull(claimed.Claim.Alliance);
            Assert.Null(claimed.Claim.Faction);
            Assert.Null(claimed.Claim.Unclaimed);
            Assert.Equal(99005338, claimed.Claim.Alliance.AllianceId);
            Assert.True(claimed.Claim.Alliance.IsCapitalSystem);
            Assert.Equal(2.5, claimed.Claim.Alliance.Development.ActivityDefenseMultiplier);
            Assert.Equal(4, claimed.Claim.Alliance.Development.MilitaryLevel);

            var unclaimed = result.SolarSystems[1];
            Assert.Null(unclaimed.Claim.Alliance);
            Assert.Null(unclaimed.Claim.Faction);
            Assert.True(unclaimed.Claim.Unclaimed);
        }

        [Fact]
        public void SovereigntyHubDetail_WorkforceTransport_DeserializesImportExportUnions()
        {
            var json = @"{
                ""id"": 1021000000001,
                ""solar_system_id"": 30000142,
                ""reagent_bay"": {
                    ""last_updated"": ""2026-06-10T00:00:00Z"",
                    ""reagents"": [ { ""amount"": 10, ""burning_per_hour"": 2, ""type_id"": 81143 } ]
                },
                ""resources"": {
                    ""power"": { ""allocated"": 5, ""available"": 10 },
                    ""workforce"": { ""allocated"": 3, ""available"": 8 }
                },
                ""upgrades"": [ { ""power_state"": ""Online"", ""type_id"": 81144 } ],
                ""workforce_transport"": {
                    ""configuration"": { ""import"": { ""sources"": [ { ""solar_system_id"": 30000143 } ] } },
                    ""state"": { ""export"": { ""amount"": 5, ""solar_system_id"": 30000144 } }
                }
            }";

            var hub = JsonSerializer.Deserialize<SovereigntyHubDetail>(json);

            Assert.NotNull(hub);
            Assert.Equal(1021000000001, hub.Id);
            Assert.Single(hub.ReagentBay.Reagents);
            Assert.Equal(81143, hub.ReagentBay.Reagents[0].TypeId);
            Assert.Equal(10, hub.Resources.Power.Available);

            // configuration is the "import" variant
            Assert.NotNull(hub.WorkforceTransport.Configuration.Import);
            Assert.Null(hub.WorkforceTransport.Configuration.Export);
            Assert.Null(hub.WorkforceTransport.Configuration.Transit);
            Assert.Single(hub.WorkforceTransport.Configuration.Import.Sources);
            Assert.Equal(30000143, hub.WorkforceTransport.Configuration.Import.Sources[0].SolarSystemId);

            // state is the "export" variant
            Assert.NotNull(hub.WorkforceTransport.State.Export);
            Assert.Null(hub.WorkforceTransport.State.Import);
            Assert.Equal(5, hub.WorkforceTransport.State.Export.Amount);
        }

        [Fact]
        public void AccessListDetail_DeserializesMembershipEntriesAndAccessEnum()
        {
            var json = @"{
                ""id"": 1,
                ""name"": ""Fuel Managers"",
                ""description"": ""Who can fuel the hub"",
                ""membership"": {
                    ""allow_everyone"": false,
                    ""alliances"": [ { ""alliance_id"": 99005338, ""access"": ""Allowed"" } ],
                    ""corporations"": [ { ""corporation_id"": 98000001, ""access"": ""Blocked"" } ],
                    ""characters"": [ { ""character_id"": 90000001, ""access"": ""Admin"" } ]
                }
            }";

            var detail = JsonSerializer.Deserialize<AccessListDetail>(json);

            Assert.NotNull(detail);
            Assert.Equal(1, detail.Id);
            Assert.Equal("Fuel Managers", detail.Name);
            Assert.False(detail.Membership.AllowEveryone);
            Assert.Equal("Allowed", detail.Membership.Alliances[0].Access);
            Assert.Equal("Blocked", detail.Membership.Corporations[0].Access);
            Assert.Equal(90000001, detail.Membership.Characters[0].CharacterId);
        }
    }
}
