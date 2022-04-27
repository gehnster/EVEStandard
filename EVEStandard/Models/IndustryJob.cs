using System;
using System.Text.Json.Serialization;

namespace EVEStandard.Models
{
    public class IndustryJob : ModelBase<IndustryJob>
    {
        #region Enums

        /// <summary>
        /// status string
        /// </summary>
        /// <value>status string</value>
        public enum StatusEnum
        {
            active = 1,
            cancelled = 2,
            delivered = 3,
            paused = 4,
            ready = 5,
            reverted = 6
        }

        #endregion Enums

        #region Properties

        /// <summary>
        /// Job activity ID
        /// </summary>
        /// <value>Job activity ID</value>
        [JsonPropertyName("activity_id")]
        public int ActivityId { get; set; }

        /// <summary>
        /// blueprint_id integer
        /// </summary>
        /// <value>blueprint_id integer</value>
        [JsonPropertyName("blueprint_id")]
        public long BlueprintId { get; set; }

        /// <summary>
        /// Location ID of the location from which the blueprint was installed. Normally a station ID, but can also be an asset (e.g. container) or corporation facility
        /// </summary>
        /// <value>Location ID of the location from which the blueprint was installed. Normally a station ID, but can also be an asset (e.g. container) or corporation facility</value>
        [JsonPropertyName("blueprint_location_id")]
        public long BlueprintLocationId { get; set; }

        /// <summary>
        /// blueprint_type_id integer
        /// </summary>
        /// <value>blueprint_type_id integer</value>
        [JsonPropertyName("blueprint_type_id")]
        public int BlueprintTypeId { get; set; }

        /// <summary>
        /// ID of the character which completed this job
        /// </summary>
        /// <value>ID of the character which completed this job</value>
        [JsonPropertyName("completed_character_id")]
        public int? CompletedCharacterId { get; set; }

        /// <summary>
        /// Date and time when this job was completed
        /// </summary>
        /// <value>Date and time when this job was completed</value>
        [JsonPropertyName("completed_date")]
        public DateTime? CompletedDate { get; set; }

        /// <summary>
        /// The sume of job installation fee and industry facility tax
        /// </summary>
        /// <value>The sume of job installation fee and industry facility tax</value>
        [JsonPropertyName("cost")]
        public double? Cost { get; set; }

        /// <summary>
        /// Job duration in seconds
        /// </summary>
        /// <value>Job duration in seconds</value>
        [JsonPropertyName("duration")]
        public int Duration { get; set; }

        /// <summary>
        /// Date and time when this job finished
        /// </summary>
        /// <value>Date and time when this job finished</value>
        [JsonPropertyName("end_date")]
        public DateTime EndDate { get; set; }

        /// <summary>
        /// ID of the facility where this job is running
        /// </summary>
        /// <value>ID of the facility where this job is running</value>
        [JsonPropertyName("facility_id")]
        public long FacilityId { get; set; }

        /// <summary>
        /// ID of the character which installed this job
        /// </summary>
        /// <value>ID of the character which installed this job</value>
        [JsonPropertyName("installer_id")]
        public int InstallerId { get; set; }

        /// <summary>
        /// Unique job ID
        /// </summary>
        /// <value>Unique job ID</value>
        [JsonPropertyName("job_id")]
        public int JobId { get; set; }
        /// <summary>
        /// Number of runs blueprint is licensed for
        /// </summary>
        /// <value>Number of runs blueprint is licensed for</value>
        [JsonPropertyName("licensed_runs")]
        public int? LicensedRuns { get; set; }

        /// <summary>
        /// Location ID of the location to which the output of the job will be delivered. Normally a station ID, but can also be a corporation facility
        /// </summary>
        /// <value>Location ID of the location to which the output of the job will be delivered. Normally a station ID, but can also be a corporation facility</value>
        [JsonPropertyName("output_location_id")]
        public long OutputLocationId { get; set; }

        /// <summary>
        /// Date and time when this job was paused (i.e. time when the facility where this job was installed went offline)
        /// </summary>
        /// <value>Date and time when this job was paused (i.e. time when the facility where this job was installed went offline)</value>
        [JsonPropertyName("pause_date")]
        public DateTime? PauseDate { get; set; }

        /// <summary>
        /// Chance of success for invention
        /// </summary>
        /// <value>Chance of success for invention</value>
        [JsonPropertyName("probability")]
        public float? Probability { get; set; }

        /// <summary>
        /// Type ID of product (manufactured, copied or invented)
        /// </summary>
        /// <value>Type ID of product (manufactured, copied or invented)</value>
        [JsonPropertyName("product_type_id")]
        public int? ProductTypeId { get; set; }

        /// <summary>
        /// Number of runs for a manufacturing job, or number of copies to make for a blueprint copy
        /// </summary>
        /// <value>Number of runs for a manufacturing job, or number of copies to make for a blueprint copy</value>
        [JsonPropertyName("runs")]
        public int Runs { get; set; }

        /// <summary>
        /// Date and time when this job started
        /// </summary>
        /// <value>Date and time when this job started</value>
        [JsonPropertyName("start_date")]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// ID of the station where industry facility is located
        /// </summary>
        /// <value>ID of the station where industry facility is located</value>
        [JsonPropertyName("station_id")]
        public long StationId { get; set; }
        /// <summary>
        /// status string
        /// </summary>
        /// <value>status string</value>
        [JsonPropertyName("status")]
        public StatusEnum Status { get; set; }
        /// <summary>
        /// Number of successful runs for this job. Equal to runs unless this is an invention job
        /// </summary>
        /// <value>Number of successful runs for this job. Equal to runs unless this is an invention job</value>
        [JsonPropertyName("successful_runs")]
        public int? SuccessfulRuns { get; set; }

        #endregion Properties
    }
}
