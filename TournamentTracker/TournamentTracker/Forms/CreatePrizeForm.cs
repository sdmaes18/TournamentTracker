﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TournamentTracker;
using TrackerLibrary;

namespace TrackerUI
{
    /// <summary>
    /// Create the prize with form.
    /// </summary>
    public partial class CreatePrizeForm : Form
    {
        /// <summary>
        /// Stores the information about the prize.
        /// </summary>
        public IPrizeRequest CallingForm;

        /// <summary>
        /// Initializes a new instance of the CreatePrizeForm class.
        /// </summary>
        /// <param name="caller">Caller from the create team form.</param>
        public CreatePrizeForm(IPrizeRequest caller)
        {
            this.CallingForm = caller;
            this.InitializeComponent();
        }

        /// <summary>
        /// Creates a new prize.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The arguments of the event.</param>
        private void CreatePrizeButton_Click(object sender, EventArgs e)
        {
            if (this.ValidateForm())
            {
                // Creates a new prize model based on user input.
                PrizeModel model = new PrizeModel(
                    this.PlaceNameValue.Text,
                    this.PlaceNumberValue.Text,
                    this.PrizeAmountValue.Text,
                    this.PrizePercentageValue.Text);

                GlobalConfig.Connection.CreatePrize(model);

                this.CallingForm.PrizeComplete(model);

                this.Close();
            }
            else
            {
                MessageBox.Show("Form is invalid. Please try again.");
            }
        }

        /// <summary>
        /// Validates the create prize form and it's information input.
        /// </summary>
        /// <returns>A true of false value if the form is valid or not.</returns>
        private bool ValidateForm()
        {
            bool output = true;
            int placeNumber = 0;

            // Determine if the place number is actually a number or not.
            bool placeNumberValidation = int.TryParse(this.PlaceNumberValue.Text, out placeNumber);

            if (!placeNumberValidation)
            {
                output = false;
            }

            // If entered number is less than 1 it's invalid.
            if (placeNumber < 1)
            {
                output = false;
            }

            // Making sure the name length is greater than zero.
            if (this.PlaceNameValue.Text.Length == 0)
            {
                output = false;
            }

            decimal prizeAmount = 0;
            double prizePercentage = 0;

            // Tries to validate entered user information.
            bool prizeAmountValid = decimal.TryParse(this.PrizeAmountValue.Text, out prizeAmount);
            bool prizePercentageValid = double.TryParse(this.PrizePercentageValue.Text, out prizePercentage);

            if (!prizeAmountValid || !prizePercentageValid)
            {
                output = false;
            }

            if (prizeAmount < 0 && prizePercentage < 0)
            {
                output = false;
            }

            if (prizePercentage < 0 || prizePercentage > 100)
            {
                output = false;
            }

            return output;
        }
    }
}
