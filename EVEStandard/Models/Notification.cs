using System;
using Newtonsoft.Json;

namespace EVEStandard.Models
{
    public class Notification : ModelBase<Notification>
    {
        /// <summary>
        /// notification_id integer
        /// </summary>
        /// <value>notification_id integer</value>
        [JsonProperty("notification_id")]
        public long? NotificationId { get; set; }

        /// <summary>
        /// sender_id integer
        /// </summary>
        /// <value>sender_id integer</value>
        [JsonProperty("sender_id")]
        public int? SenderId { get; set; }
        /// <summary>
        /// sender_type string
        /// </summary>
        /// <value>sender_type string</value>
        public enum SenderTypeEnum
        {
            character = 1,
            corporation = 2,
            alliance = 3,
            faction = 4,
            other = 5
        }

        /// <summary>
        /// sender_type string
        /// </summary>
        /// <value>sender_type string</value>
        [JsonProperty("sender_type")]
        public SenderTypeEnum? SenderType { get; set; }

        /// <summary>
        /// timestamp string
        /// </summary>
        /// <value>timestamp string</value>
        [JsonProperty("timestamp")]
        public DateTime? Timestamp { get; set; }

        /// <summary>
        /// is_read boolean
        /// </summary>
        /// <value>is_read boolean</value>
        [JsonProperty("is_read")]
        public bool? IsRead { get; set; }

        /// <summary>
        /// text string
        /// </summary>
        /// <value>text string</value>
        [JsonProperty("text")]
        public string Text { get; set; }
        /// <summary>
        /// type string
        /// </summary>
        /// <value>type string</value>
        public enum TypeEnum
        {
            AcceptedAlly = 1,
            AcceptedSurrender = 2,
            AllAnchoringMsg = 3,
            AllMaintenanceBillMsg = 4,
            AllStrucInvulnerableMsg = 5,
            AllStructVulnerableMsg = 6,
            AllWarCorpJoinedAllianceMsg = 7,
            AllWarDeclaredMsg = 8,
            AllWarInvalidatedMsg = 9,
            AllWarRetractedMsg = 10,
            AllWarSurrenderMsg = 11,
            AllianceCapitalChanged = 12,
            AllyContractCancelled = 13,
            AllyJoinedWarAggressorMsg = 14,
            AllyJoinedWarAllyMsg = 15,
            AllyJoinedWarDefenderMsg = 16,
            BattlePunishFriendlyFire = 17,
            BillOutOfMoneyMsg = 18,
            BillPaidCorpAllMsg = 19,
            BountyClaimMsg = 20,
            BountyESSShared = 21,
            BountyESSTaken = 22,
            BountyPlacedAlliance = 23,
            BountyPlacedChar = 24,
            BountyPlacedCorp = 25,
            BountyYourBountyClaimed = 26,
            BuddyConnectContactAdd = 27,
            CharAppAcceptMsg = 28,
            CharAppRejectMsg = 29,
            CharAppWithdrawMsg = 30,
            CharLeftCorpMsg = 31,
            CharMedalMsg = 32,
            CharTerminationMsg = 33,
            CloneActivationMsg = 34,
            CloneActivationMsg2 = 35,
            CloneMovedMsg = 36,
            CloneRevokedMsg1 = 37,
            CloneRevokedMsg2 = 38,
            ContactAdd = 39,
            ContactEdit = 40,
            ContainerPasswordMsg = 41,
            CorpAllBillMsg = 42,
            CorpAppAcceptMsg = 43,
            CorpAppInvitedMsg = 44,
            CorpAppNewMsg = 45,
            CorpAppRejectCustomMsg = 46,
            CorpAppRejectMsg = 47,
            CorpDividendMsg = 48,
            CorpFriendlyFireDisableTimerCompleted = 49,
            CorpFriendlyFireDisableTimerStarted = 50,
            CorpFriendlyFireEnableTimerCompleted = 51,
            CorpFriendlyFireEnableTimerStarted = 52,
            CorpKicked = 53,
            CorpLiquidationMsg = 54,
            CorpNewCEOMsg = 55,
            CorpNewsMsg = 56,
            CorpOfficeExpirationMsg = 57,
            CorpStructLostMsg = 58,
            CorpTaxChangeMsg = 59,
            CorpVoteCEORevokedMsg = 60,
            CorpVoteMsg = 61,
            CorpWarDeclaredMsg = 62,
            CorpWarFightingLegalMsg = 63,
            CorpWarInvalidatedMsg = 64,
            CorpWarRetractedMsg = 65,
            CorpWarSurrenderMsg = 66,
            CustomsMsg = 67,
            DeclareWar = 68,
            DistrictAttacked = 69,
            DustAppAcceptedMsg = 70,
            EntosisCaptureStarted = 71,
            FWAllianceKickMsg = 72,
            FWAllianceWarningMsg = 73,
            FWCharKickMsg = 74,
            FWCharRankGainMsg = 75,
            FWCharRankLossMsg = 76,
            FWCharWarningMsg = 77,
            FWCorpJoinMsg = 78,
            FWCorpKickMsg = 79,
            FWCorpLeaveMsg = 80,
            FWCorpWarningMsg = 81,
            FacWarCorpJoinRequestMsg = 82,
            FacWarCorpJoinWithdrawMsg = 83,
            FacWarCorpLeaveRequestMsg = 84,
            FacWarCorpLeaveWithdrawMsg = 85,
            FacWarLPDisqualifiedEvent = 86,
            FacWarLPDisqualifiedKill = 87,
            FacWarLPPayoutEvent = 88,
            FacWarLPPayoutKill = 89,
            GameTimeAdded = 90,
            GameTimeReceived = 91,
            GameTimeSent = 92,
            GiftReceived = 93,
            IHubDestroyedByBillFailure = 94,
            IncursionCompletedMsg = 95,
            IndustryTeamAuctionLost = 96,
            IndustryTeamAuctionWon = 97,
            InfrastructureHubBillAboutToExpire = 98,
            InsuranceExpirationMsg = 99,
            InsuranceFirstShipMsg = 100,
            InsuranceInvalidatedMsg = 101,
            InsuranceIssuedMsg = 102,
            InsurancePayoutMsg = 103,
            JumpCloneDeletedMsg1 = 104,
            JumpCloneDeletedMsg2 = 105,
            KillReportFinalBlow = 106,
            KillReportVictim = 107,
            KillRightAvailable = 108,
            KillRightAvailableOpen = 109,
            KillRightEarned = 110,
            KillRightUnavailable = 111,
            KillRightUnavailableOpen = 112,
            KillRightUsed = 113,
            LocateCharMsg = 114,
            MadeWarMutual = 115,
            MercOfferedNegotiationMsg = 116,
            MissionOfferExpirationMsg = 117,
            MissionTimeoutMsg = 118,
            MoonminingAutomaticFracture = 119,
            MoonminingExtractionCancelled = 120,
            MoonminingExtractionFinished = 121,
            MoonminingLaserFired = 122,
            NPCStandingsGained = 123,
            NPCStandingsLost = 124,
            OfferedSurrender = 125,
            OfferedToAlly = 126,
            OldLscMessages = 127,
            OperationFinished = 128,
            OrbitalAttacked = 129,
            OrbitalReinforced = 130,
            OwnershipTransferred = 131,
            ReimbursementMsg = 132,
            ResearchMissionAvailableMsg = 133,
            RetractsWar = 134,
            SeasonalChallengeCompleted = 135,
            SovAllClaimAquiredMsg = 136,
            SovAllClaimLostMsg = 137,
            SovCommandNodeEventStarted = 138,
            SovCorpBillLateMsg = 139,
            SovCorpClaimFailMsg = 140,
            SovDisruptorMsg = 141,
            SovStationEnteredFreeport = 142,
            SovStructureDestroyed = 143,
            SovStructureReinforced = 144,
            SovStructureSelfDestructCancel = 145,
            SovStructureSelfDestructFinished = 146,
            SovStructureSelfDestructRequested = 147,
            SovereigntyIHDamageMsg = 148,
            SovereigntySBUDamageMsg = 149,
            SovereigntyTCUDamageMsg = 150,
            StationAggressionMsg1 = 151,
            StationAggressionMsg2 = 152,
            StationConquerMsg = 153,
            StationServiceDisabled = 154,
            StationServiceEnabled = 155,
            StationStateChangeMsg = 156,
            StoryLineMissionAvailableMsg = 157,
            StructureAnchoring = 158,
            StructureCourierContractChanged = 159,
            StructureDestroyed = 160,
            StructureFuelAlert = 161,
            StructureItemsDelivered = 162,
            StructureLostArmor = 163,
            StructureLostShields = 164,
            StructureOnline = 165,
            StructureServicesOffline = 166,
            StructureUnanchoring = 167,
            StructureUnderAttack = 168,
            TowerAlertMsg = 169,
            TowerResourceAlertMsg = 170,
            TransactionReversalMsg = 171,
            TutorialMsg = 172,
            WarAllyOfferDeclinedMsg = 173,
            WarSurrenderDeclinedMsg = 174,
            WarSurrenderOfferMsg = 175,
            notificationTypeMoonminingExtractionStarted = 176
        }

        /// <summary>
        /// type string
        /// </summary>
        /// <value>type string</value>
        [JsonProperty("type")]
        public TypeEnum? Type { get; set; }
    }
}
