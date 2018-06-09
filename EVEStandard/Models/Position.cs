namespace EVEStandard.Models
{
    public class Position : ModelBase<Position>
    {
        /// <summary>
        /// Gets or sets the x.
        /// </summary>
        /// <value>
        /// The x.
        /// </value>
        public long X { get; set; }

        /// <summary>
        /// Gets or sets the y.
        /// </summary>
        /// <value>
        /// The y.
        /// </value>
        public long Y { get; set; }

        /// <summary>
        /// Gets or sets the z.
        /// </summary>
        /// <value>
        /// The z.
        /// </value>
        public long Z { get; set; }
    }
}
