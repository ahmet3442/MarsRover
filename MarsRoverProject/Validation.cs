using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MarsRoverProject
{
    public enum ValidationType
    {
        Area,
        StartingPosition
    }
    public interface IValidation
    {
        bool Validate(ValidationType type, string input);
    }

    public class Validation : IValidation
    {
        public bool Validate(ValidationType type, string input)
        {
            bool result = false;
            switch (type)
            {
                case ValidationType.Area:
                    result = ValidatePlateauArea(input);
                    break;
                case ValidationType.StartingPosition:
                    result = ValidateStartingPosition(input);
                    break;
                default:
                    return result;
            }
            return result;
        }
        public bool ValidatePlateauArea(string input)
        {
            Regex rg = new Regex(@"^(-?\d+) \s*(-?\d+)$");
            return rg.IsMatch(input);
        }
        public bool ValidateStartingPosition(string input)
        {
            Regex rg = new Regex(@"^(-?\d+) \s*(-?\d+) \s*[NWES]");
            return rg.IsMatch(input);
        }
    }
}
