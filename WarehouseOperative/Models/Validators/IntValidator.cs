namespace WarehouseOperative.Models.Validators
{
    public class IntValidator : Validator
    {
        #region Methods

        public static string IsNegative(int value) => value < 0 ? "Value cannot be negative" : string.Empty;

        #endregion
    }
}
