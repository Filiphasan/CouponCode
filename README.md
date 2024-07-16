# Information ⬇️
This repository contains below projects, Click on the project name to go to the project.
- [Coupon Code Generator and Validator](#coupon-code)
- [Bill OCR](#bill-ocr)

## Dependencies
- Dotnet 8 or higher SDK [Download SDK](https://dotnet.microsoft.com/download)

## Install
Run the following command to install the project.
````shell
git clone https://github.com/Filiphasan/CouponCode.git
````

## Project Usage
Run the following commands to get started with the project.

### Restore
````shell
dotnet restore
`````

### Build
````shell
dotnet build
````

### Run
````shell
dotnet run --project src/Web
````

### Test
````shell
dotnet test
````
------

# Coupon Code

Coupon Code Generator and Validator, without saving generated code. 
Generate multiple codes and validate them one by one. No need to save the generated codes.

## Endpoints
- Check endpoints ➡️ [CouponCodeEndpoint](src/Web/Endpoints/CouponCodeEndpoint.cs)

## Benchmark
Generate and Validate 10000000 Codes in under 1 minute

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

---
# Bill OCR

Simulate Bill OCR process

## Endpoints
- Check endpoints ➡️ [BillOcrEndpoint](src/Web/Endpoints/BillOcrEndpoint.cs)

## OCR Response Information
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

## Bill OCR Endpoint Output
````
TEŞEKKÜRLER
GUNEYDOĞU TEKS. GIDA INS SAN. LTD.STI.
ORNEKTEPE MAH.ETIBANK CAD.SARAY APT.
N:43-1 BEYOĞLU/ISTANBUL
GÜNEŞLİ V.D. 4350078928 V. NO.
TARIH : 26.08.2020
SAAT : 15:27
FİŞ NO : 0082 15:27
54491250
2 ADx 2,75
CC.COCA COLA CAM 200 08 *5,50
2701084
1,566 KGx 1,99
MANAV DOMATES PETEME *3,32
2701076
0,358 KGx 4,99
MANAV BIBER CARLISTO 08 *1,79
4
EKMEK CIFTLI 01 *1,25
TOPKDV *0,80
TOPLAM *11,86
NAKİT *20,00
KDV KDV TUTARI KDV'LI TOPLAM
01 *0,01 *1,25
08 *0,79 *10,61
KASİYER : SUPERVISOR
00 0001/020/000084/1//82/
PARA USTÜ *8,14
KASİYER: 1
2 NO:1330 EKÜ NO:0001
MF YAB 15017876
````