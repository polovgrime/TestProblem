using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyInput
{
    public class CurrencyParser
    {
		private readonly string[] digits = " one two three four five six seven eight nine".Split();
		private readonly string[] teens = " eleven twelve thir# four# fif# six# seven# eigh# nine#".Replace("#", "teen").Split();
		private readonly string[] tens = " ten twenty thirty forty fifty sixty seventy eighty ninety".Split();
		private readonly string[] bigNumberPrefix = " thousand m# b# tr# quadr# quint# sext# sept# oct#".Replace("#", "illion").Split();

		private decimal _sourceAmount;
        public CurrencyParser(decimal value)
        {
            this._sourceAmount = value;
        }

        private string ReadThreeDigits(decimal source, int part)
        {
			var hundred = (part / 100);
			var tensPart = (part - hundred * 100) / 10;
			var digitPart = (part - hundred * 100 - tensPart * 10);
			var partResult = string.Empty;

			if (hundred > 0)
			{
				partResult = digits[hundred] + " hundred";

				if (tensPart > 0 || digitPart > 0)
				{
					partResult += " and ";
				}
			}

			if (tensPart > 0)
			{
				if (tensPart == 1 && digitPart > 0)
				{
					partResult += $"{teens[digitPart]}";
				}
				else if (tensPart > 0)
				{
					partResult += $"{tens[tensPart]}";

					if (digitPart > 0)
					{
						partResult += $"-";
					}
				}

			}

			if (tensPart != 1 && digitPart > 0)
			{
				partResult += $"{digits[digitPart]}";
			}

			partResult = (((source > 1000) && (hundred == 0) && (part == 0)) ? " and " : (source > 1000) ? ", " : "") + partResult;

			return partResult;
		}

        private string ReadInteger(decimal source)
		{
			if (source == 0) return "zero ";
			var numberDirection = (source < 0) ? "minus " : "";
			var result = "";
			var partIndex = 0;
			source = Math.Abs(source);

			while (source > 0)
			{
				var part = (int)(source % 1000);

				if (part > 0)
				{
					result = ReadThreeDigits(source, part) + " " + bigNumberPrefix[partIndex] + result;
				}

				source = source / 1000;
				partIndex++;
			}

			return numberDirection + result;
		}

		private string ReadDecimalPart(decimal source)
        {
			if (source == 0) return string.Empty;

            source = decimal.Round(Math.Abs(source));
			return $"AND {ReadInteger(source)}";
        }

        public string GetParsed()
        {
			var decimalPart = _sourceAmount % 1;
			var integerPart = _sourceAmount - decimalPart; // ReadInteger() doesn't even read decimal part, might be useless here
			decimalPart = decimalPart * 100;

			var dollars = "DOLLAR" + (integerPart > 1 ? "S" : string.Empty);
			var cents = "CENT" + (decimalPart > 1 ? "S" : string.Empty);

			return $"{ReadInteger(integerPart)}{dollars} {ReadDecimalPart(decimalPart)} {cents}";
        }

    }
}
