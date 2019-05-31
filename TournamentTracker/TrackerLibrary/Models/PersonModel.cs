namespace TrackerLibrary
{
    /// <summary>
    /// Represents a person.
    /// </summary>
    public class PersonModel
    {
        /// <summary>
        /// Gets the full name of the first.
        /// </summary>
        public string FullName
        {
            get
            {
                return $"{this.FirstName} {this.LastName}";
            }
        }

        /// <summary>
        /// Gets or sets the id of the model.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the persons first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the person.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the person email address.
        /// </summary>
        public string EmailAddress { get; set; }

        /// <summary>
        /// Gets or sets the cell phone number of the person.
        /// </summary>
        public string CellphoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the users password.
        /// </summary>
        public string Password { get; set; }
    }
}
