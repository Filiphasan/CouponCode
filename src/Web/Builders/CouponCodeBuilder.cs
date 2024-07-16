using System.Security.Cryptography;

namespace Web.Builders;

public class CouponCodeBuilder
{
    private List<CouponCharModel> _availableCharModelList = [];
    private int _length = 0;
    private int _count = 1;

    public CouponCodeBuilder SetAvailableChars(string? availableChars)
    {
        if (availableChars is null or { Length: < 4 })
        {
            throw new InvalidOperationException("Available chars length must be greater than 4 and not null");
        }

        _availableCharModelList = availableChars.ToCharArray()
            .Distinct()
            .Select((item, index) => new CouponCharModel(item, index))
            .ToList();
        return this;
    }

    public CouponCodeBuilder SetLength(int length)
    {
        if (length <= 4)
        {
            throw new InvalidOperationException("Length must be greater than 4");
        }

        _length = length;
        return this;
    }

    public CouponCodeBuilder SetCount(int count)
    {
        if (count <= 0)
        {
            throw new InvalidOperationException("Count must be greater than 0");
        }

        _count = count;
        return this;
    }

    public IEnumerable<string> Build()
    {
        var generatedCodes = new HashSet<string>();
        for (int i = 0; i < _count; i++)
        {
            string code;
            do
            {
                code = GenerateCode();
            } while (!generatedCodes.Add(code));
            yield return code;
        }
    }

    public bool Validate(string code)
    {
        if (string.IsNullOrWhiteSpace(code) || code.Length != _length)
        {
            return false;
        }

        var allCharsValid = code.All(ch => _availableCharModelList.Exists(x => x.Char == ch));
        if (!allCharsValid)
        {
            return false;
        }

        var firstChar = _availableCharModelList.First(x => x.Char == code[0]);
        var lastChar = _availableCharModelList.First(x => x.Char == code[^1]);
        var otherChars = code[1..^1];
        var charsSum = otherChars.Sum(x => x);
        var remainCharsSum = charsSum % _availableCharModelList.Count;
        var firstCharValid = firstChar.Index == remainCharsSum;
        var lastCharValid = lastChar.Index == _availableCharModelList.Count - remainCharsSum - 1;
        return firstCharValid && lastCharValid;
    }

    private string GenerateCode()
    {
        var availableCharsCount = _availableCharModelList.Count - 1;
        var actualLength = _length - 2;
        var chars = new char[actualLength];
        for (int i = 0; i < actualLength; i++)
        {
            var randomIndex = RandomNumberGenerator.GetInt32(0, _availableCharModelList.Count);
            chars[i] = _availableCharModelList.First(x => x.Index == randomIndex).Char;
        }

        var charsSum = chars.Sum(x => x);
        var remainCharsSum = charsSum % _availableCharModelList.Count;
        var firstChar = _availableCharModelList.First(x => x.Index == remainCharsSum).Char;
        var lastChar = _availableCharModelList.Last(x => x.Index == availableCharsCount - remainCharsSum).Char;

        return new string([firstChar, ..chars, lastChar]);
    }
}

public record CouponCharModel(char Char, int Index);