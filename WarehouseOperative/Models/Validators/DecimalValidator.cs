using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseOperative.Models.Validators
{
    public class DecimalValidator : Validator
    {
        #region Methods

        public static string IsNotNegative(decimal value) => value < 0 ? "Value cannot be negative!" : string.Empty;

        public static string IsPercentCorrect(decimal value) => value >= 0 && value <= 100 ? string.Empty : "This value must be 0-100";

        #endregion
    }
}
