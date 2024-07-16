# Coupon Code

Coupon Code Generator and Validator, without saving generated code. 
Generate multiple codes and validate them one by one. No need to save the generated codes.

## Endpoints
- Check endpoints ➡️ [CouponCodeEndpoint](src/Web/Endpoints/CouponCodeEndpoint.cs)

## Dependencies
- Dotnet 8 or higher SDK (https://dotnet.microsoft.com/download)

## Install
````shell
git clone https://github.com/Filiphasan/CouponCode.git
````

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

Validate Code

````csharp
var isValid = new CouponCodeBuilder()
                .SetAvailableChars("0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ") // Available characters for coupon code, same as generated codes
                .SetLength(12) // Length of per coupon code, same as generated codes
                .Validate(code); // Validate coupon code
````


# Bill OCR

Simulate Bill OCR process

## Endpoints
- Check endpoints ➡️ [BillOcrEndpoint](src/Web/Endpoints/BillOcrEndpoint.cs)

## Description
````json
{
    "description": "SAAT",
    "boundingPoly": {
      "vertices": [
        {
          "x": 50,
          "y": 272
        },
        {
          "x": 98,
          "y": 273
        },
        {
          "x": 97,
          "y": 290
        },
        {
          "x": 50,
          "y": 289
        }
      ]
    }
  }
````

- description: Description of the text
- boundingPoly: Bounding of the text in the bill image
- vertices: Vertices of the boundingPoly
- vertices first item: Left top corner
- vertices second item: Right top corner
- vertices third item: Right bottom corner
- vertices fourth item: Left bottom corner