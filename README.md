# Coupon Code

Coupon Code Generator and Validator, without saving code. 
Generate multiple codes and validate them one by one. No need to save the generated codes.

## Dependencies
- Dotnet 8 or higher SDK (https://dotnet.microsoft.com/download)

## Benchmark
Generate and Validate 10000000 Codes in under 1 minute

## Project Usage
Restore
````shell
dotnet restore
`````

Build
````shell
dotnet build
````

Run
````shell
dotnet run --project src/Web
````

Test
````shell
dotnet test
````

## CodeUsage

Generate Codes

````csharp
var codes = new CouponCodeBuilder()
            .SetAvailableChars("0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ") // Available characters for coupon code
            .SetLength(12) // Length of per coupon code
            .SetCount(count) // Count of generated coupon codes
            .Build() // Build coupon codes
            .ToList();
````

Validate Codes

````csharp
var isValid = new CouponCodeBuilder()
                .SetAvailableChars("0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ") // Available characters for coupon code, same as generated codes
                .SetLength(12) // Length of per coupon code, same as generated codes
                .Validate(code);
````
