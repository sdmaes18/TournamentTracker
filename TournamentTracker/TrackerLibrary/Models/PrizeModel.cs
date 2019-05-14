namespace TrackerLibrary
{
    /// <summary>
    /// Represents the prize.
    /// </summary>
    public class PrizeModel
    {
        /// <summary>
        /// Initializes a new instance of the PrizeModel class.
        /// </summary>
        public PrizeModel()
        {
        }

        /// <summary>
        /// Initializes a new instance of the PrizeModel class as the over loaded constructor.
        /// </summary>
        /// <param name="placeName">Name of the place.</param>
        /// <param name="placeNumber">Place taken.</param>
        /// <param name="prizeAmount">Amount of prize.</param>
        /// <param name="prizePercentage">Percentage of prize.</param>
        public PrizeModel(string placeName, string placeNumber, string prizeAmount, string prizePercentage)
        {
            this.PlaceName = placeName;

            // Validating our input. Should be a string.
            int placeNumberValue = 0;
            int.TryParse(placeNumber, out placeNumberValue);
            this.PlaceNumber = placeNumberValue;

            // Validating our input. Should be a string.
            decimal prizeAmountValue = 0;
            decimal.TryParse(prizeAmount, out prizeAmountValue);
            this.PrizeAmount = prizeAmountValue;

            // Validating our input. Should be a string.
            double prizePercentageValue = 0;
            double.TryParse(prizePercentage, out prizePercentageValue);
            this.PrizePercentage = prizePercentageValue;
        }

        /// <summary>
        /// Gets or sets the id of the model.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the place the prize is for.
        /// </summary>
        public int PlaceNumber { get; set; }

        /// <summary>
        /// Gets or sets the name of the place of the prize.
        /// </summary>
        public string PlaceName { get; set; }

        /// <summary>
        /// Gets or sets the prize amount.
        /// </summary>
        public decimal PrizeAmount { get; set; }

        /// <summary>
        /// Gets or sets the price percentage.
        /// </summary>
        public double PrizePercentage { get; set; }
    }
}
